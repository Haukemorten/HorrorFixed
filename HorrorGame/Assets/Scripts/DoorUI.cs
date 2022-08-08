using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUI : MonoBehaviour
{
    [SerializeField] GameObject opendoorUI;
    [SerializeField] private int timetoShowUI = 1;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShowDoorLocked());
    }
    IEnumerator ShowDoorLocked()
    {
        opendoorUI.SetActive(true);
        yield return new WaitForSeconds(timetoShowUI);
        opendoorUI.SetActive(false);
    }
}
