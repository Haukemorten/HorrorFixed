using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string filename;
    private GameDAta gameData;
    public static DataPersistanceManager Instance { get; private set; }
    private List<IDAtaPersistence> dAtaPersistences;
    private FileDataHandler dataHandler;
    private void Awake()
    {
        if (Instance != null) 
        {
            Debug.LogError("More than one DPM in scene ");
        }
        Instance = this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename);
        this.dAtaPersistences = FindALLdAtaPersistences();
        LoadGame();
    }
    public void NewGame() 
    {
        this.gameData = new GameDAta();
    
    }
    public void LoadGame() 
    {
        this.gameData = dataHandler.Load();
        if (this .gameData == null)
        {
            Debug.Log("No fata found loading default");
            NewGame();
        }
          foreach (IDAtaPersistence persistence in dAtaPersistences) 
        {

            persistence.LoadData(gameData);
        }
        Debug.Log("Loaded BAttery count =" + gameData.Batterycount);
    
    }
    public void SaveGame() 
    {
        foreach (IDAtaPersistence persistences in dAtaPersistences) 
        {
            persistences.SaveData(ref gameData);
            
        }
    Debug.Log("Save wörk"+gameData.Batterycount);
        dataHandler.Save(gameData);
    
    }
    private void OnApplicationQuit() 
    {
        SaveGame();
    }
    private List<IDAtaPersistence> FindALLdAtaPersistences() 
    {
        IEnumerable<IDAtaPersistence> dAtaPersistences = FindObjectsOfType<MonoBehaviour>().OfType<IDAtaPersistence>();
        return new List<IDAtaPersistence>(dAtaPersistences);
    }
}
