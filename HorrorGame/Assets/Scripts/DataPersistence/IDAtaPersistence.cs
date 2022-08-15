using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDAtaPersistence  
{
    void LoadData(GameDAta data);
    void SaveData(ref GameDAta data);
     
}
