using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBehaviour : MonoBehaviour
{
    
     RaycastHit hit ;
     [SerializeField] float distance = 4f;
    //[SerializeField] GameObject PickupMassage;

     private float RayDistance;
     private bool CanSeeBattery = false;
     




    // Start is called before the first frame update
    private void Start()
    {
         //PickupMassage.gameObject.SetActive(false);
         RayDistance = distance;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward,out hit,RayDistance)) 
        {
            if (hit.transform.tag == "Battery") 
            {
                CanSeeBattery = true;          
                        
            }
            else 
            {
                CanSeeBattery = false;
            }
        
        }
        if (CanSeeBattery == true) 
        {
            //PickupMassage.gameObject.SetActive(true);
            RayDistance = 1000f;
          
            if (Input.GetMouseButtonDown(0)) 
            {
                Destroy(hit.transform.gameObject);
                PlayerData.Batterycount+=1; 
            
            }
        
        }
        if (CanSeeBattery == false)
        {
            //PickupMassage.gameObject.SetActive(false);
            RayDistance = distance;
            
        }


    }
}
