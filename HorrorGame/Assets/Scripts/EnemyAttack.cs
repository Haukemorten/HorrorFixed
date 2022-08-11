using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent ;
    private NavMeshHit hit ;
    private bool blocked = false;
    private bool runToPlayer = false;
    private float distanceToPlayer;
    private bool checking = true;
    private int failedChecks = 0;
    

    [SerializeField] Transform Player;
    [SerializeField] GameObject Enemy;
    [SerializeField] float MaxRange = 35.0f;
    [SerializeField] int MaxChecks = 3;
    [SerializeField] float ChaseSpeed = 8.5f;
    [SerializeField] float WalkSpeed = 1.6f;
    [SerializeField] float AttackDistance = 2.3f;
    [SerializeField] float RotationSpeed = 1.0f;
    [SerializeField] float CheckTime = 3.0f;
    

    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
        if ( distanceToPlayer < MaxRange) 
        {
            if (checking== true) 
            {
                checking = false;

                blocked = NavMesh.Raycast(transform.position, Player.position, out hit, NavMesh.AllAreas);

                if (blocked == false) 
                {
                    Debug.Log("Can see the player ");
                    runToPlayer = true;
                    failedChecks = 0;
                }
                if(blocked == true) 
                {
                    Debug.Log("I am blind");
                    runToPlayer = false;
                    failedChecks++;
                }

                StartCoroutine(TimeChecked());
            }
        }

        if (runToPlayer == true) 
        {
            //Enemy.GetComponent<EMovement>().enabled = false;
            if (distanceToPlayer > AttackDistance) 
            {    
                agent.isStopped = false;
                agent.acceleration = 8;
                agent.SetDestination(Player.position);
                agent.speed = ChaseSpeed;

            
            }
            if (distanceToPlayer < AttackDistance)
            {   

                agent.isStopped = true;
                Debug.Log("Commencing attack");
                
                agent.acceleration = 180;               
                
            }
        }
        else if (runToPlayer == false) 
        {
            //Enemy.GetComponent<EMovement>().enabled = true;
            agent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            runToPlayer = true;
        }
    }


    IEnumerator TimeChecked() 
    {
        yield return new WaitForSeconds(CheckTime);
        checking = true;

        if (failedChecks > MaxChecks) 
        {
            //Enemy.GetComponent<EMovement>().enabled = true;
            agent.isStopped = false;
            agent.speed = WalkSpeed;
            failedChecks = 0;

        
        }


    }
}
