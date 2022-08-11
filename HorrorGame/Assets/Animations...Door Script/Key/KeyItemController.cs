using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KeySystem
{



    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool BlackDoor = false;
        [SerializeField] private bool RedDoor = false;
        [SerializeField] private bool BlueDoor = false;
        [SerializeField] private bool GreenDoor = false;

        [SerializeField] private bool BlackKey = false;
        [SerializeField] private bool RedKey = false;
        [SerializeField] private bool BlueKey = false;
        [SerializeField] private bool GreenKey = false;
        [SerializeField] private KeyInventory _keyInventory = null;
        private KeyDoorController doorObject;
        private void Start()
        {
           if(BlackDoor || RedDoor || BlueDoor || GreenDoor)
            {
                doorObject = GetComponent<KeyDoorController>();
            }
            
        }
        public void ObjectInteractions()
        {
            if(BlackDoor || RedDoor || BlueDoor ||GreenDoor)
            {
                doorObject.PlayAnimation(); 

            }
            else if(BlackKey || RedKey || BlueKey ||GreenKey)
            {
                _keyInventory.hasBlackKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
