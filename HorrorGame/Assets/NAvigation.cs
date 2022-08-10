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

    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform target3;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = target1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
