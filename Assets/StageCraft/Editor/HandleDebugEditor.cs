using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HandleDebug))]
public class HandleDebugEditor : Editor
{
    void OnSceneGUI()
    {
        HandleDebug t = (HandleDebug)target;
        float handleSize = 0.8f; // ハンドルのサイズを半分にします

        // Y軸
        // Debug.DrawRay(t.transform.position, t.transform.up, Color.green);
        Handles.color = Color.cyan;
        Quaternion newRotationY = Handles.Disc(t.transform.rotation, t.transform.position, t.transform.up, handleSize, false, 1.0f);
                // X軸
        // Debug.DrawRay(t.transform.position, t.transform.right, Color.red);
        // Handles.color = Color.red;
        Quaternion newRotationX = Handles.Disc(t.transform.rotation, t.transform.position, t.transform.right, handleSize, false, 1.0f);

        // Z軸
        // Debug.DrawRay(t.transform.position, t.transform.forward, Color.blue);
        // Handles.color = Color.blue;
        Quaternion newRotationZ = Handles.Disc(t.transform.rotation, t.transform.position, t.transform.forward, handleSize, false, 1.0f);

        // いったんオイラー角に変換
        // Vector3 newRotationY_euler = newRotationY.eulerAngles;

        // // 0はイコールも含む
        // if (newRotationY_euler.y >= 0.0f && newRotationY_euler.y < 30.0f)
        // {
        //     Debug.Log("///// 0-30 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }

        // if (newRotationY_euler.y > 30.0f && newRotationY_euler.y < 60.0f)
        // {
        //     Debug.Log("///// 30-60 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 60.0f && newRotationY_euler.y < 90.0f)
        // {
        //     Debug.Log("///// 60-90 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // // これを360度に対して行う
        // if (newRotationY_euler.y > 90.0f && newRotationY_euler.y < 120.0f)
        // {
        //     Debug.Log("///// 90-120 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 120.0f && newRotationY_euler.y < 150.0f)
        // {
        //     Debug.Log("///// 120-150 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 150.0f && newRotationY_euler.y < 180.0f)
        // {
        //     Debug.Log("///// 150-180 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 180.0f && newRotationY_euler.y < 210.0f)
        // {
        //     Debug.Log("///// 180-210 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 210.0f && newRotationY_euler.y < 240.0f)
        // {
        //     Debug.Log("///// 210-240 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 240.0f && newRotationY_euler.y < 270.0f)
        // {
        //     Debug.Log("///// 240-270 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 270.0f && newRotationY_euler.y < 300.0f)
        // {
        //     Debug.Log("///// 270-300 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 300.0f && newRotationY_euler.y < 330.0f)
        // {
        //     Debug.Log("///// 300-330 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
        // if (newRotationY_euler.y > 330.0f && newRotationY_euler.y < 360.0f)
        // {
        //     Debug.Log("///// 330-360 /////");
        //     Debug.Log("newRotationY_euler.y: " + newRotationY_euler.y);
        // }
  
        // DEBUG
        // Debug.Log("newRotationY_euler: " + newRotationY_euler);
        // 再度クォータニオンに変換
        // Quaternion _newPositionY = Quaternion.Euler(newRotationY_euler.x, newRotationY_euler.y, newRotationY_euler.z);
        // 同じ値になるかチェック
        // Debug.Log("newRotationY: " + newRotationY);
        // Debug.Log("_newPositionY: " + _newPositionY);


        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(t.transform, "Transform Change");
            // t.transform.rotation = newRotationY; // Y軸の回転を設定     
            t.transform.rotation = Quaternion.Lerp(newRotationY, Quaternion.Lerp(newRotationX, newRotationZ, 0.5f), 0.5f);   
        }
    }
}