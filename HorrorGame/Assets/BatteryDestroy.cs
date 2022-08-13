using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryDestroy : MonoBehaviour
{
    [SerializeField] GameObject Battery;
    public bool kill = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerData.pickedup == true)
        {
             
            PlayerData.pickedup = false;
            Debug.Log("Destroyed");
            kill = true;
        }
        while (kill== true)
        {
            Destroy(Battery);
            kill = false;
        
        }
    }


}
