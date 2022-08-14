using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class GameDAta  
{
    public   float BatteryPower = 100f;

    public   int Batterycount = 0;

    public float Health ;
    public   bool enemyHit ;
    public  bool FlashlightOn  ;
    public  bool pickedup  ;
    public   bool Newgame  ;
    public  bool Loadedgame  ;

    public GameDAta() 
    {
         this.BatteryPower = 100f;

         this.Batterycount = 0;

          this.Health= 1;
        this.enemyHit = false;
     

     }




}
