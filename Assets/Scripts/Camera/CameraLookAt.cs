using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target; // 追跡するオブジェクト
    [Range(0.0f, 5.0f)]
    public float damping = 5.0f; // ダンピングの値
    [Range(-20f, 90.0f)]
    public float minFov = 5.0f; // 最小視野角
    [Range(0f, 90.0f)]
    public float maxFov = 60.0f; // 最大視野角
    [Range(0.0f, 1.0f)]
    public float zoomSpeed = 0.1f; // ズームの速度
    private Camera cam; // カメラコンポーネント
    private float time; // パーリンノイズの時間パラメータ

    void Start()
    {
        cam = GetComponent<Camera>();
        time = Random.Range(0f, 100f); // ランダムな初期時間
    }

    void LateUpdate()
    {
        if (target)
        {
            // ターゲットを見つめる
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * damping);

            // パーリンノイズに基づいてズーム
            time += Time.deltaTime * zoomSpeed;
            float noise = Mathf.PerlinNoise(time, 0f);
            cam.fieldOfView = Mathf.Lerp(minFov, maxFov, noise);
            // 0より小さい値を許容しない
            cam.fieldOfView = Mathf.Max(cam.fieldOfView, 0.1f);
        }
    }
}