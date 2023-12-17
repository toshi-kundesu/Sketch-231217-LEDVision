using System.Collections.Generic;
using UnityEngine;

public class TrussJointPoints : MonoBehaviour
{
    [SerializeField]
    public List<TrussJointData> Joints = new List<TrussJointData>();
}

[System.Serializable]
public class TrussJointData
{
    [SerializeField]
    public Vector3 LocalJointPosition;
    [SerializeField]
    public Vector3 LocalJointRotationEuler = Vector3.zero;

    public TrussJointData(Vector3 localJointPosition, Vector3 localJointRotationEuler)
    {
        LocalJointPosition = localJointPosition;
        LocalJointRotationEuler = localJointRotationEuler;
    }
}