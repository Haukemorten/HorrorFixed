using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
    
{
    private NavMeshAgent agent;
    private Transform Target;
    private float TargetDistance;
    private int TargetNumber = 1;

    [SerializeField] int MaxTargets =8;
    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] Transform Target3;
    [SerializeField] Transform Target4;
    [SerializeField] Transform Target5;
    [SerializeField] Transform Target6;
    [SerializeField] Transform Target7;
    [SerializeField] Transform Target8;

    [SerializeField] float StopDistance = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = Target1;
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetDistance = Vector3.Distance(Target.position,transform.position);
        if(TargetDistance > StopDistance)
        {
            agent.SetDestination(Target.position);
        }
        if (TargetDistance < StopDistance)
        {
            TargetNumber++;
            if (TargetNumber > MaxTargets) 
            {
                TargetNumber =1;
            }
            SetTarget();
        }

    }
    void SetTarget() 
    {
        if (TargetNumber == 1) 
        {
            Target = Target1;
        }
        if (TargetNumber == 2)
        {
            Target = Target2;
        }
        if (TargetNumber == 3)
        {
            Target = Target3;
        }
        if (TargetNumber == 4)
        {
            Target = Target4;
        }
        if (TargetNumber == 5)
        {
            Target = Target5;
        }
        if (TargetNumber == 6)
        {
            Target = Target6;
        }
        if (TargetNumber == 7)
        {
            Target = Target7;
        }
        if (TargetNumber == 8)
        {
            Target = Target8;
        }

    }
}
