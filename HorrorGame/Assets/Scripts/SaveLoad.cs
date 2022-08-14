using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    
     [SerializeField]public int  DataExist = 0;  
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.F5)) 
        {
            saveGame();
        
        
        
        }
        if (Input.GetKeyDown(KeyCode.F7)&&DataExist > 0) 
        {
            LoadGameData();
        
        }
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void LoadGameData() 
    {
        PlayerData.Loadedgame = true;
    }
    public void saveGame() 
    {
        PlayerPrefs.GetFloat("PBatteryPower",PlayerData.BatteryPower);
        PlayerPrefs.GetFloat("HealthP", PlayerData.Health);
        PlayerPrefs.GetInt("NumberedBatteries", PlayerData.Batterycount);
        if(PlayerData.enemyHit == true) 
        {
            PlayerPrefs.SetInt("HitsE", 1);
        
        }
        if (PlayerData.FlashlightOn == true)
        {
            PlayerPrefs.SetInt("Light", 1);

        }
        if (PlayerData.pickedup == true)
        {
            PlayerPrefs.SetInt("tookit", 1);

        }
        DataExist += 10;
    }
}
