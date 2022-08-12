using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDestroy : MonoBehaviour
{
    [SerializeField] GameObject Battery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
         
            Destroy(Battery);
            PlayerData.pickedup = false;
            Debug.Log("Destroyed");
        
        
    }
}
