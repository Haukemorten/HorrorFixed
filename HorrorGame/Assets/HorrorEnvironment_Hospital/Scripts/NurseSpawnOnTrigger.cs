using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSpawnOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Spawnpoint;
    [SerializeField] GameObject Prefab;
    GameObject clone;
    [SerializeField] float DespawnTimer;
     
    private bool Spawned = false;

    
    private float spawnCount = 0;
    void Start()
    {
        
    }

    void OnTriggerEnter() 
    {
        if(Spawned == false) 
        { 
       clone = Instantiate (Prefab,Spawnpoint.position,Spawnpoint.rotation);
             
            spawnCount++;
            StartCoroutine(Destroyer());
        Spawned = true;
        }
        
    }
     IEnumerator Destroyer() 
    
    {
        yield return new WaitForSeconds (DespawnTimer);
        Destroy(clone);
    
    
    }

}
