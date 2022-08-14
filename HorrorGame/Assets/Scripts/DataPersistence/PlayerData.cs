using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData  
{
    public  static float BatteryPower = 100f;
    
    public  static int Batterycount = 0;
   
    public  static    float Health = 1;
    public static  bool  enemyHit=false;
    public  static bool FlashlightOn = false; 
    public  static bool pickedup = false;
    public  static bool Newgame = false;
    public  static bool Loadedgame = false;
    
   // public GameData ()
   //{ 


 





   // }
    //private void Start()
    //{
    //    if (Newgame == true) 
    //    {  BatteryPower = 100f;

    //       Batterycount = 0;

    //       Health = 1;
    //       enemyHit = false;
    //       FlashlightOn = false;
    //       pickedup = false;
 




    //    }

    //    if (Loadedgame == true) 
    //    {
            
    //        BatteryPower = PlayerPrefs.GetFloat("PBatteryPower");
    //        Batterycount = PlayerPrefs.GetInt("NumberedBatteries");
    //        Health = PlayerPrefs.GetFloat("HealthP");
    //        if (PlayerPrefs.GetInt("Light") ==1) 
    //        {
    //            FlashlightOn = true;
    //        }
    //        if (PlayerPrefs.GetInt("HitsE") == 1)
    //        {
    //            enemyHit = true;
    //        }
    //        if (PlayerPrefs.GetInt("tookit") == 1)
    //        {
    //            pickedup = true;
    //        }

    //    }
    //}
    


}
 