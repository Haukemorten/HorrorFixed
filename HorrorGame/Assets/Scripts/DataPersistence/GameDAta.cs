using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameDAta  
{
    public   float BatteryPower = 100f;

    public   int Batterycount = 0;
    public Vector3 playerPosition;

    public Dictionary<string, bool> batteriesCollected;
   

    public GameDAta() 
    {
         this.BatteryPower = 100f;

         this.Batterycount = 0;
         playerPosition = Vector3.zero;
         batteriesCollected = new Dictionary<string, bool>();
           
     

     }

     


}
