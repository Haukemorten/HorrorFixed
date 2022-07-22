using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] GameObject[] light;
    private bool on = false;
    private void OnTriggerStay(Collider other)
    {

        for (int i = 0; i < light.Length; i++)
        {
            if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !on)
            {
                light[i].SetActive(true);
                on = true;
            }
            else if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && on)
            {
                light[i].SetActive(false);
                on = false;
            }
        }







       

    }
}
