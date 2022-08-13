using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFreeze : MonoBehaviour
{
    private bool enemyHit = false;
    // Start is called before the first frame update
    
   private void OnTriggerExit(Collider other)
    {
        
        EnemyAttack.FindObjectOfType<EnemyAttack>().enabled = true;
            Debug.Log("Walking");
         
    }private void OnTriggerStay()
    {
        
        EnemyAttack.FindObjectOfType<EnemyAttack>().enabled = false;
        enemyHit = true;
            Debug.Log("EnemyHit");
         
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
