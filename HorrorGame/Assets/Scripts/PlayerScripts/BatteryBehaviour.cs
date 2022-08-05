using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBehaviour : MonoBehaviour
{
    [SerializeField] float DrainRate=15f;
    [SerializeField] float Power;
    
    [SerializeField] Image BatteryUI;
    // Start is called before the first frame update
     

    // Update is called once per frame
    void Update()
    {
        if (PlayerData.FlashlightOn == true) 
        {
            PlayerData.BatteryPower = Power; 
            Power = BatteryUI.fillAmount;
            BatteryUI.fillAmount -= 1.0f /  DrainRate * Time.deltaTime;
           
            
        }
    }
}
