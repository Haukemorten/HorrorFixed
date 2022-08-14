using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    public float audioDelay;
    private void OnTriggerEnter(Collider other)
    {
        audio.PlayDelayed(audioDelay);  
    }
    private void OnTriggerExit(Collider collision)
    {
        DestroyObject(this);    
    }
}
