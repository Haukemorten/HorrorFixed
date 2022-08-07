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

    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
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
            if (TargetNumber > 2) 
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
    
    }
}
