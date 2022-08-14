using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public static bool On;
    [SerializeField] float DrainRate;
    [SerializeField] float currentEnergy;
    [SerializeField] float maxEnergy;
    [SerializeField] float minEnergy = 0;
    [SerializeField] float distance = 4;
    [SerializeField] LayerMask layerMaskEnemy;
    public bool Drained;
    RaycastHit hit;
    private float RaycastDistance;











    // Start is called before the first frame update
    void Start()
    {

        flashlight.SetActive(false);
        RaycastDistance=distance  ;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (currentEnergy <= 0)
        {
             
            if (PlayerData.Batterycount <=0 && On||On) 
            {
                StartCoroutine(TurnOff()); 
                
            }
            if (Input.GetKeyDown("r")&&PlayerData.Batterycount>=0) 
            {
                currentEnergy =maxEnergy ;
                PlayerData.Batterycount--;
                Debug.Log("Reloaded");
            }
            return;   
        
            
        
        }
        if (On)
        {
            
            s
            { 
               PlayerData.enemyHit = true;
            Debug.Log("hit");
                    
            
            }
            
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
    //private void OnTrigger(Collider other)
    //{
    //    if(On == true) { 
    //    EnemyAttack.FindObjectOfType<EnemyAttack>().enabled = false;
    //    enemyHit = true;
    //    Debug.Log("EnemyHit");}
    //}
    //private void OnTriggerExit(Collider other)
    //{

    //    EnemyAttack.FindObjectOfType<EnemyAttack>().enabled = true;
    //    Debug.Log("Walking");

    //}


    IEnumerator TurnOff()
    {

        yield return new WaitForSeconds(0.1f);
        flashlight.SetActive(false);
        On = false;
        PlayerData.enemyHit = false;
    }
}
