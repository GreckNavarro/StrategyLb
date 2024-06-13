using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/WanderSO", order = 1)]
public class WanderSO : StrategySO
{
    public float moveSpeed = 3f; 
    public float rotationSpeed = 100f; 
    private Vector3 randomDirection; 
    private Vector3 destination;

    public override void SetTransform(Transform newtransform)
    {
        base.SetTransform(newtransform);
        SetRandomDestination();
    }
    public override bool SetBoolAnim()
    {
        return base.SetBoolAnim();
    }
    public override void BuildBehaviour()
    {
        Debug.Log("Wander");
        Vector3 direction = destination - myTransfom.position ;


        Quaternion targetRotation = Quaternion.LookRotation(direction);
        myTransfom.rotation = Quaternion.RotateTowards(myTransfom.rotation, targetRotation, rotationSpeed * Time.deltaTime);


        myTransfom.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    
        if (Vector3.Distance(myTransfom.position, destination) < 0.5f)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {

        randomDirection = Random.insideUnitSphere * 10f;
        destination = myTransfom.position + randomDirection;
        destination.y = 1.3f;
    }

}
