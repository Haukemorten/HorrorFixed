using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator anim;
    private bool doorOpen = false;
    
    [Header("Audio")]
    [SerializeField] AudioSource doorCloseAudio = null;
    [SerializeField] AudioSource doorOpenAudio = null;
    private float closedelayed = 0.6f; 
    private float opendelayed = 0f;
    
    
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
          
        
    }
    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            anim.Play("DoorOpen", 0, 0.0f);
            doorOpen = true;
            doorOpenAudio.PlayDelayed(opendelayed);
            
        }
        else
        {
            anim.Play("DoorClose", 0, 0.0f);
            doorOpen = false;
            doorCloseAudio.PlayDelayed(closedelayed);
            
            
        }
    }
}
