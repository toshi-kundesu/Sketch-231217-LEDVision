using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HandleTester))]
public class HandleTesterEditor : Editor
{
    private Vector3 lastRotation;

    private float handleSize = 1.2f; // ハンドルのサイズを制御する変数
    private float colorIntensity = 0.9f; // 色の強度を制御する変数

    void OnSceneGUI()
    {
        Tools.hidden = true; // UnityのデフォルトのTransformハンドルを非表示にする

        HandleTester t = (HandleTester)target;
        EditorGUI.BeginChangeCheck();
        Vector3 axisX = t.transform.right; // X軸回転を追加
        Vector3 axisY = t.transform.up; // Y軸回転
        Vector3 axisZ = t.transform.forward; // Z軸回転

        Handles.color = Color.red * colorIntensity; // X軸のハンドルの色を設定
        Quaternion newRotationX = Handles.Disc(t.transform.rotation, t.transform.position, axisX, handleSize, false, 1.0f); // X軸回転のハンドルを追加

        Handles.color = Color.green * colorIntensity; // Y軸のハンドルの色を設定
        Quaternion newRotationY = Handles.Disc(t.transform.rotation, t.transform.position, axisY, handleSize, false, 1.0f);

        Handles.color = Color.blue * colorIntensity; // Z軸のハンドルの色を設定
        Quaternion newRotationZ = Handles.Disc(t.transform.rotation, t.transform.position, axisZ, handleSize, false, 1.0f);

        Handles.color = Color.cyan * colorIntensity; // ハンドルの色を設定
        Vector3 newPositionX = Handles.Slider(t.transform.position, Vector3.right, handleSize, Handles.ArrowHandleCap, t.movementSnap.x); // X軸に沿って移動できるようにするハンドルを追加
        Vector3 newPositionY = Handles.Slider(t.transform.position, Vector3.up, handleSize, Handles.ArrowHandleCap, t.movementSnap.y); // Y軸に沿って移動できるようにするハンドルを追加
        Vector3 newPositionZ = Handles.Slider(t.transform.position, Vector3.forward, handleSize, Handles.ArrowHandleCap, t.movementSnap.z); // Z軸に沿って移動できるようにするハンドルを追加        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(t.transform, "Transform Change");
            Vector3 rotationChange = new Vector3(
                Mathf.Round((newRotationX.eulerAngles.x - lastRotation.x) / t.rotationSnap.x) * t.rotationSnap.x,
                Mathf.Round((newRotationY.eulerAngles.y - lastRotation.y) / t.rotationSnap.y) * t.rotationSnap.y,
                Mathf.Round((newRotationZ.eulerAngles.z - lastRotation.z) / t.rotationSnap.z) * t.rotationSnap.z
            );
            t.transform.rotation = Quaternion.Euler(t.transform.rotation.eulerAngles + rotationChange); // X軸、Y軸、Z軸の回転をHandleTesterのrotationSnapに基づいて設定
            Vector3 positionInUnits = new Vector3(
                Mathf.Round((newPositionX - t.transform.position).x / t.movementSnap.x) * t.movementSnap.x,
                Mathf.Round((newPositionY - t.transform.position).y / t.movementSnap.y) * t.movementSnap.y,
                Mathf.Round((newPositionZ - t.transform.position).z / t.movementSnap.z) * t.movementSnap.z
            );
            t.transform.position = t.transform.position + positionInUnits; // 新しい位置をHandleTesterのmovementSnapに基づいて設定
        }
        lastRotation = t.transform.rotation.eulerAngles;

    }
}