using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Strategy", menuName = "ScriptableObjects/PatrolSO", order = 2)]
public class PatrolSO : StrategySO
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 100f;
    public Vector3[] patrolPoints; // Puntos de patrulla del NPC
    private int currentPatrolIndex = 0; // Índice del punto de patrulla actual
    private Vector3 destination;

    public override void SetTransform(Transform newtransform)
    {
        base.SetTransform(newtransform);
        SetInitialDestination();
    }
    public override bool SetBoolAnim()
    {
        return base.SetBoolAnim();
    }

    public override void BuildBehaviour()
    {
        Debug.Log("Patrol");
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("No hay puntos de patrulla definidos.");
            return;
        }


        Vector3 direction = destination - myTransfom.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        myTransfom.rotation = Quaternion.RotateTowards(myTransfom.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        myTransfom.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Vector3.Distance(myTransfom.position, patrolPoints[currentPatrolIndex]) < 0.5f)
        {
            AdvancePatrol();
        }
    }

    void SetInitialDestination()
    {
        if (patrolPoints.Length > 0)
        {
            destination = patrolPoints[currentPatrolIndex];
        }
        else
        {
            Debug.LogWarning("No hay puntos de patrulla definidos.");
        }
    }

    void AdvancePatrol()
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        destination = patrolPoints[currentPatrolIndex];
    }

}
