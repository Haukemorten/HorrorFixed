using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    private GameDAta gameData;
    public static DataPersistanceManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null) 
        {
            Debug.LogError("More than one DPM in scene ");
        }
        Instance = this;
    }
    public void NewGame() 
    {
        this.gameData = new GameDAta();
    
    }
    public void LoadGame() 
    {
        if (this .gameData == null)
        {
            Debug.Log("No fata found loading default");
            NewGame();
        }
    
    
    }
    public void SaveGame() 
    {

    
    
    }
}
