using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionSave: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private void Start()
    {
        if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("LoadingTime") == 1) 
        { 
        float pX = Player.transform.position.x;
        float pY = Player.transform.position.y;

        pX = PlayerPrefs.GetFloat("pX");
        pY = PlayerPrefs.GetFloat("pY");
        PlayerPrefs.SetInt("LoadingTime", 1);
        PlayerPrefs.Save();
        }

    }
    public void PlayerPSave() 
    {
        PlayerPrefs.SetFloat ("pX",Player.transform.position.x);
        PlayerPrefs.SetFloat("pY",Player.transform.position.y);
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPositionLoad() 
    {
        PlayerPrefs.SetInt("LoadingTime", 1);
        PlayerPrefs.Save ();
    
    }

}
