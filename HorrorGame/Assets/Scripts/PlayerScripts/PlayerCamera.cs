using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float SenseY;
    [SerializeField] float SenseX;

    public Transform Orientation;

    [SerializeField] float RotationX;
    [SerializeField] float RotationY;
    [SerializeField] float FoVGrowth;
    [SerializeField] Camera cam;
    [SerializeField] PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        CursorBehaviour();

    }

    // Update is called once per frame
    void Update()
    {
        GetInputAndRotations();
        FoVChange();

    }
    private void CursorBehaviour()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Cursor Locked in der mitte des bildschirms
        Cursor.visible = false;    // Cursor unsichtbar
    }
    private void GetInputAndRotations()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * SenseX;
        float MouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * SenseY;

        RotationY += MouseX; // wieso? muss aber 
        RotationX -= MouseY;
        RotationX = Mathf.Clamp(RotationX, -70f, 70f);

        //Cam Rotation und Orientierung 
        transform.rotation = Quaternion.Euler(RotationX, RotationY, 0);
        Orientation.rotation = Quaternion.Euler(0, RotationY, 0);

    }
    private void FoVChange()
    {
        GetInputAndRotations();
        //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 90, FoVGrowth * Time.deltaTime);
        if (player.State == PlayerMovement.MovementState.Sprinting)
        {
            cam.fieldOfView = Mathf.SmoothStep(cam.fieldOfView, 90, FoVGrowth * Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = Mathf.SmoothStep(cam.fieldOfView, 60, FoVGrowth * Time.deltaTime);
        }
    }
}
