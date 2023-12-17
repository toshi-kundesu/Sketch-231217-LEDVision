using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TrussJointPoints))]
public class TrussJointPointsEditor : Editor
{
    private const float ConeSize = 0.2f; // コーンのサイズを定義
    private Vector3? firstClickedConeDirection = null;
    private Transform firstClickedConeParent = null; // 追加
    private int? firstClickedJointIndex = null; // 追加
    private float colorIntensity = 0.8f; // 色の強度を制御する変数

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // デフォルトのインスペクターUIを描画
    }
    
    private void OnSceneGUI()
    {
        // シーン内のすべての TrussJointPoints オブジェクトに対してコーンを描画
        foreach (TrussJointPoints tjp in FindObjectsOfType<TrussJointPoints>())
        {
            DrawConeForJoint(tjp);
        }
    }

    private void DrawConeForJoint(TrussJointPoints tjp)
    {
        // 色の配列を作成
        Color[] colors = { Color.cyan, Color.magenta, Color.yellow, Color.red, Color.green, Color.blue };

        // すべてのジョイントを取得
        for (int i = 0; i < tjp.Joints.Count; i++)
        {
            TrussJointData joint = tjp.Joints[i];

            // ジョイントのローカル位置をワールド座標に変換
            Vector3 worldJointPosition = tjp.transform.TransformPoint(joint.LocalJointPosition);
            // ジョイントのローカル回転をクォータニオンに変換
            Quaternion localJointRotation = Quaternion.Euler(joint.LocalJointRotationEuler);
            // ジョイントのローカル回転をワールド回転に変換
            Quaternion worldJointRotation = tjp.transform.rotation * localJointRotation;

            // コーンが向いている方向にレイを描画（赤色）
            Vector3 coneDirection = worldJointRotation * Vector3.forward;
            Vector3 normalizedConeDirection = Vector3.Normalize(coneDirection);
            // Debug.DrawRay(worldJointPosition, coneDirection, Color.red);

            // コーンの色を設定
            Color coneColor = colors[i % colors.Length] * colorIntensity;
            Handles.color = (firstClickedConeParent == tjp.transform && firstClickedJointIndex == i) ? coneColor * 2 : coneColor;
            // コーンのサイズを設定
            float coneSize = (firstClickedConeParent == tjp.transform && firstClickedJointIndex == i) ? ConeSize * 1.5f : ConeSize;

            // コーンを描画し、クリックされたら処理を実行
            if (Handles.Button(worldJointPosition, worldJointRotation, coneSize, coneSize, Handles.ConeHandleCap))
            {
                if (firstClickedConeDirection == null)
                {
                    // 最初にクリックしたコーンの向きと親オブジェクトを保存
                    firstClickedConeDirection = coneDirection;
                    firstClickedConeParent = tjp.transform;
                    firstClickedJointIndex = i; // 追加

                    // 最初にクリックしたコーンのワールド座標をログに出力
                    Debug.Log("First clicked cone world position: " + worldJointPosition);
                }
                else
                {
                    // 2回目にクリックしたコーンのワールド座標をログに出力
                    Debug.Log("Second clicked cone world position: " + worldJointPosition);

                    // 2回目にクリックしたコーンの向きの逆ベクトルを目標とする
                    Vector3 targetDirection = -coneDirection;

                    // 目標のベクトルと最初にクリックしたコーンの向きのベクトルの差分をとる
                    Quaternion rotation = Quaternion.FromToRotation(firstClickedConeDirection.Value, targetDirection);

                    // 最初にクリックしたコーンの親オブジェクトの回転を更新
                    firstClickedConeParent.rotation = rotation * firstClickedConeParent.rotation;

                    // 最初にクリックしたコーンの親オブジェクトの回転後の位置をログに出力
                    if (firstClickedJointIndex.HasValue)
                    {
                        Debug.Log("firstClickedJointIndex: " + firstClickedJointIndex.Value);
                        // tjp.Joints.Countをデバックしてみる
                        Debug.Log("tjp.Joints.Count: " + tjp.Joints.Count);
                        Debug.Log("firstClickedConeParent.Joints.Count: " + firstClickedConeParent.GetComponent<TrussJointPoints>().Joints.Count);
                        Vector3 firstConePositionAfterRotation = firstClickedConeParent.GetComponent<TrussJointPoints>().Joints[firstClickedJointIndex.Value].LocalJointPosition;
                        Debug.Log("First cone position after rotation: " + firstConePositionAfterRotation);
                        // firstConePositionAfterRotationのワールド座標をデバック
                        Vector3 worldFirstConePositionAfterRotation = firstClickedConeParent.TransformPoint(firstConePositionAfterRotation);
                        Debug.Log("worldFirstConePositionAfterRotation: " + worldFirstConePositionAfterRotation);
                        // Debug.Log("First cone position after rotation: " + firstConePositionAfterRotation); // 追加

                        // コーンを持つ親オブジェクトの位置をログに出力
                        Debug.Log("Parent position: " + firstClickedConeParent.position);

                        // 回転後のコーンの位置と２つ目にクリックしたコーンの位置の差を計算
                        Vector3 difference = worldFirstConePositionAfterRotation - worldJointPosition;
                        Debug.Log("Difference: " + difference);
                        // コーンを持つ親オブジェクトをx軸の正方向に移動
                        firstClickedConeParent.position -= difference;
                    }

                    // 最初にクリックしたコーンの向きと親オブジェクトをリセット
                    firstClickedConeDirection = null;
                    firstClickedConeParent = null;
                    firstClickedJointIndex = null; // 追加
                }
            }
        }
    }
}
