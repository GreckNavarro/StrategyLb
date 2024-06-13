using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/RoadStrategySO", order = 0)]
public abstract class StrategySO : ScriptableObject
{

    protected Transform myTransfom;

    public virtual void SetTransform(Transform newtransform)
    {
        myTransfom = newtransform;
    }
    public virtual void BuildBehaviour()
    {
       
    }
}
