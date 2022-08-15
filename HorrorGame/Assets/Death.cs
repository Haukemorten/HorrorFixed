using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    
    private bool done= false;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(PlayerData.Health == 0) 
        {
            SceneManager.LoadScene("Menu");
         
            Debug.Log("data");

        }
    }

    private void OnTriggerEnter(Collider other)
    { if (Input.GetKeyDown(KeyCode.F)) 
        {
            SceneManager.LoadScene("MenU");
        
        }
        SceneManager.LoadScene("GameDone");
       done = true;
        Debug.Log("trigger");   

    }





     
}


