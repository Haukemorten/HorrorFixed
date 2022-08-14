using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    [SerializeField] private GameObject footSteps;
    
    
    // Start is called before the first frame update
    void Start()
    {
        footSteps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            AudioOn();
        }
      else
        {
            AudioOff();
        }
    }
    private void AudioOn()
    {
        footSteps.SetActive(true);
    }
    private void AudioOff()
    {
        footSteps.SetActive(false);
    }

}
