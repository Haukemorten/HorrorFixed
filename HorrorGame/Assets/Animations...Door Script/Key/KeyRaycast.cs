using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace KeySystem
{


    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLenght = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string  excludeLayerName = null;
        private KeyItemController raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;
        [SerializeField] private Image Crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;
        private string interactebleObject = "InteractiveObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            
            if (Physics.Raycast(transform.position, fwd, out hit, rayLenght))
            {
                if (hit.collider.CompareTag(interactebleObject))
                {
                    if (!doOnce)
                    {
                       raycastedObject = hit.collider.gameObject.GetComponent<KeyItemController>();
                      //  CrosshairChange(true);
                    }
                    isCrosshairActive = true;
                    doOnce = true;
                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObject.ObjectInteractions();
                    }
                }
            }
            else
            {
                if (isCrosshairActive)
                {
                   // CrosshairChange(false);
                    doOnce = false;

                }
            }
        }

        void CrosshairChange(bool on)
        {
            if(on && !doOnce)
            {
                Crosshair.color = Color.green;
            }
            else
            {
                Crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }
    }
}