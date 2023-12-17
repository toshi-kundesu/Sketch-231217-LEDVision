using UnityEngine;

public class HandleTester : MonoBehaviour
{
    [Tooltip("Rotation snap in degrees for each axis")]
    public Vector3 rotationSnap = new Vector3(30f, 30f, 30f); // 各軸の回転スナップ角度を指定するフィールドを追加

    [Tooltip("Movement snap in units for each axis")]
    public Vector3 movementSnap = new Vector3(1f, 1f, 1f); // 各軸の移動スナップ単位を指定するフィールドを追加
}