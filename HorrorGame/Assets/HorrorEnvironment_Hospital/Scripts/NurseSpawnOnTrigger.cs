using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSpawnOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Spawnpoint;
    [SerializeField] GameObject Prefab;
    [SerializeField] GameObject DeSpawnPoint;
    private bool Spawned = false;

    
    private float spawnCount = 0;
    void Start()
    {
        
    }

    void OnTriggerEnter() 
    {
        if(Spawned == false) 
        { 
        Instantiate (Prefab,Spawnpoint.position,Spawnpoint.rotation);
        spawnCount++;
            Destroy(Prefab,10);
        Spawned = true;
        }
        
    }
     

}
