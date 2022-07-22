using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public bool On;

    // Start is called before the first frame update
    void Start()
    {
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("f") & On == true)
        {
            StartCoroutine(TurnOff());
        }

        if (Input.GetKeyDown("f") & On == false)
        {
            flashlight.SetActive(true);

            On = true;
        }
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(0.1f);
        flashlight.SetActive(false);
        On = false;
    }
}
