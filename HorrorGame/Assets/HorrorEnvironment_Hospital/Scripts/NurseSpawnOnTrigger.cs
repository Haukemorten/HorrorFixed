using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseSpawnOnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Spawnpoint;
    [SerializeField] GameObject Prefab;
    void Start()
    {
        
    }

    void OnTriggerEnter() 
    {
        Instantiate (Prefab,Spawnpoint.position,Spawnpoint.rotation);
    
    }
}
