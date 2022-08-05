using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBehaviour : MonoBehaviour
{
    [SerializeField] float DrainRate=15f;
    
    [SerializeField] Image BatteryUI;
    // Start is called before the first frame update
     

    // Update is called once per frame
    void Update()
    {
        BatteryUI.fillAmount -= 1.0f / DrainRate * Time.deltaTime;
    }
}
