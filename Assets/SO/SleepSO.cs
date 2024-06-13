using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/SleepSO", order = 3)]
public class SleepSO : StrategySO
{
    public override void SetTransform(Transform newtransform)
    {
        base.SetTransform(newtransform);
    }
    public override void BuildBehaviour()
    {
        Debug.Log("Durmiendo");
    }

}
