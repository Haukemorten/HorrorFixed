using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFreeze : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    private bool enemyHit = false;
    // Start is called before the first frame update
    
   private void OnTriggerStay()
    {
         
        
       
            Debug.Log("EnemyHit");

    }
    private void OnTriggerExit(Collider other) 
    {
        EnemyAttack.FindObjectOfType<EnemyAttack>().enabled = true;
            Debug.Log("Walking");
          }


   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
