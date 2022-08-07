using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorOnTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent BoxTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            BoxTrigger.Invoke();
        }
    }
}
