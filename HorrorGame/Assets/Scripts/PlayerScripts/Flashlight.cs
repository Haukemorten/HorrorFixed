using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public bool On;
    [SerializeField] float DrainRate;
    [SerializeField] float currentEnergy;
    [SerializeField] float maxEnergy;
    [SerializeField] float minEnergy = 0;
    public bool Drained;
     
  

    // Start is called before the first frame update
    void Start()
    {

        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        if (currentEnergy <= 0)
        {
            if (On) 
            {
                StartCoroutine(TurnOff()); 
            }
            return;   
        
            
        
        }
        if (On) 
        {
            
            currentEnergy -= Time.deltaTime * DrainRate;
             
             
        }
        if (PlayerData.BatteryPower > 0.0f) 
        { 
        if (Input.GetKeyDown("f") & On == true )
        {
            StartCoroutine(TurnOff());
           
        }

        if (Input.GetKeyDown("f") & On == false)
        {
            flashlight.SetActive(true);

            On = true; PlayerData.FlashlightOn = true;
        } if(PlayerData.BatteryPower <= 0.0f) 
            {
                StartCoroutine(TurnOff());
               
            }  
            
        }
    }

    IEnumerator TurnOff()
    {

        yield return new WaitForSeconds(0.1f);
        flashlight.SetActive(false);
        On = false;
    }
}
