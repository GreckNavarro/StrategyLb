using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{

    public StrategySO currentStrategy;
    public Animator myAnim;

    private void Start()
    {
        currentStrategy.SetTransform(transform);
        myAnim.SetBool("IsSleep", currentStrategy.SetBoolAnim());
    }

    public void SetStrategy(StrategySO strategySO)
    {
        currentStrategy = strategySO;
        currentStrategy.SetTransform(transform);
        myAnim.SetBool("IsSleep", currentStrategy.SetBoolAnim());

    }

    private void Update()
    {

        currentStrategy.BuildBehaviour();
    }
}
