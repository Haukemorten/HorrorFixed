using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray (transform .position, transform.forward);
        RaycastHit hit;
        bool hitsmth = Physics.Raycast(ray ,out hit ,3);
        Debug.Log(hit.transform.name);
    }
}
    