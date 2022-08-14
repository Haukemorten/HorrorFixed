using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KeySystem
{


    public class KeyDoorController : MonoBehaviour
    {
        private Animator anim;
        private bool doorOpen = false;
        [SerializeField] private int timetoShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;
        [SerializeField] private KeyInventory _keyInventory = null;
        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        [Header("Audio")]
        [SerializeField] AudioSource doorCloseAudio;
        [SerializeField] AudioSource doorOpenAudio;
        [SerializeField] AudioSource doorIsLockedAudio;
        private float openDelayed = 0f;
        private float closeDelayed = 0.6f;
        
        private void Awake()
        {
            anim = gameObject.GetComponent<Animator>();
        }
        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }
        public void PlayAnimation()
        {
            if (_keyInventory.hasBlackKey)
            {
                OpenDoor();
            
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
                doorIsLockedAudio.PlayDelayed(openDelayed);
            }
            

        }
        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timetoShowUI);
            showDoorLockedUI.SetActive(false);
        }
        private void OpenDoor()
        {
            if (!doorOpen && !pauseInteraction)
            {
                anim.Play("DoorOpen", 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
                doorOpenAudio.PlayDelayed(openDelayed);
            }
            else if (doorOpen && !pauseInteraction)
            {
                anim.Play("DoorClose", 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
                doorCloseAudio.PlayDelayed(closeDelayed);   
            }
        }
    }
}
