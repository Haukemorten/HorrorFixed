using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class PlayerData  : MonoBehaviour ,IDAtaPersistence
{
    public  static float BatteryPower = 100f;
    
    public  static int Batterycount = 0;
   
    public  static    float Health = 1;
    public static  bool  enemyHit=false;
    public  static bool FlashlightOn = false; 
    public  static bool pickedup = false;
    public  static bool Newgame = false;
    public  static bool Loadedgame = false;

    public void LoadData(GameDAta data) 


    {
        PlayerData.Batterycount = data.Batterycount;
        PlayerData.BatteryPower = data.BatteryPower;
    }

    public void SaveData(ref GameDAta data) 
    {
        data.Batterycount = PlayerData.Batterycount;
        data.BatteryPower = PlayerData.BatteryPower;    
    }

}
 