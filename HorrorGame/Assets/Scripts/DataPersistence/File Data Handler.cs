using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class FileDataHandler 
{
    private string dataDirPath = "";
    private string dataFileName = ""; 

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }
    public GameDAta Load() 
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameDAta loadedData = null;
        if (File.Exists(fullPath)) 
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open)) 
                {
                    using (StreamReader reader = new StreamReader(stream)) 
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                
                }
                loadedData = JsonUtility.FromJson<GameDAta>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.Log("Error loading " + fullPath + "\n" + e);
            }
        
        
        }
        return loadedData;
    }

    public void Save(GameDAta data) 
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data ,true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) 
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                {
                    writer.Write(dataToStore);
                
                }
            
            
            }

        }
        catch (Exception e)
        {
            Debug.Log("Error occured when trying to save data to file" + fullPath+ "\n"+e );
        }
    }
}
