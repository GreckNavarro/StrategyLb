using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{

    public StrategySO currentStrategy;


    private void Start()
    {
        currentStrategy.SetTransform(transform);
    }

    public void SetStrategy(StrategySO strategySO)
    {
        currentStrategy = strategySO;
        currentStrategy.SetTransform(transform);
    }

    private void Update()
    {

        currentStrategy.BuildBehaviour();
    }
}
