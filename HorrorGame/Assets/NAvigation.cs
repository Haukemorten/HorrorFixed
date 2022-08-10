using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NAvigation : MonoBehaviour
{ 
     private NavMeshAgent agent;
     private Transform currentTarget;
     private float DistanceToTarget;
     private int targetNumber = 1;

    [SerializeField] float stopDistance = 2.0f;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform target3;
    [SerializeField] Transform target4;
    [SerializeField] Transform target5;
    [SerializeField] Transform target6;
    [SerializeField] Transform target7;
    [SerializeField] Transform target8;
    [SerializeField] int MaxTargets =8;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = target1;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceToTarget = Vector3.Distance(currentTarget.position,transform.position);
        if(DistanceToTarget > stopDistance) 
        {
            agent.SetDestination(currentTarget.position);
        }
        if (DistanceToTarget < stopDistance)
        {
            targetNumber++;
            if(targetNumber > MaxTargets)
            {
                targetNumber = 1;
            }
            SetTarget();
        }
    }
    void  SetTarget() 
    {
        if (targetNumber == 1)
        { 
         currentTarget = target1;
        }
        if (targetNumber == 2)
        {
            currentTarget = target2;
        }
        if (targetNumber == 3)
        {
            currentTarget = target3;
        }
        if (targetNumber == 4)
        {
            currentTarget = target4;
        }
        if (targetNumber == 5)
        {
            currentTarget = target5;
        }
        if (targetNumber == 6)
        {
            currentTarget = target6;
        }
        if (targetNumber == 7)
        {
            currentTarget = target7;
        }
        if (targetNumber == 8)
        {
            currentTarget = target8;
        }
    }
}
