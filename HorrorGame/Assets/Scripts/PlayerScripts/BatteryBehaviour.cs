using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBehaviour : MonoBehaviour
{
    
    [SerializeField] private int rayLenght = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private KeyCode PickUp = KeyCode.Mouse0;
    private string interactableObject= "Battery";
    
     

    
    // Start is called before the first frame update
     

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 look = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, look, out hit, rayLenght)) 
        {
             hit.collider.CompareTag(interactableObject);
             PlayerData.Batterycount++;
             PlayerData.pickedup = true;
             
        
        }

            
            
        
    }
}
