using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    [SerializeField] private bool enable = true;
    [SerializeField, Range(0, 0.1f)] private float amp = 0.015f;
    [SerializeField, Range(0, 30)] private float freq = 10.0f;

    [SerializeField] private Transform camera = null;
    [SerializeField] private Transform cameraHolder = null;

    private float toggleSpeed = 3.0f;
    private Vector3 startPos;
    private Rigidbody controller;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        controller = GetComponent<Rigidbody>();
        startPos = camera.localPosition;
        new PlayerMovement();

    }
    private void Update()
    {
        if (!enable) return;

        CheckMotion();
        ResetPosition();
        camera.LookAt(FocusTarget());
    }
    private void CheckMotion()
    {
        float speed = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;

        if (speed < toggleSpeed) return;
        //if (!Rigidbody.grounded) return;

        PlayMotion(FootStepMotion());

    }
    private Vector3 FootStepMotion()
    {

        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * freq) * amp;
        pos.x += Mathf.Cos(Time.time * freq / 2) * amp * 2;
        return pos;
    }
    private void ResetPosition()
    {
        if (camera.localPosition == startPos) return;
        camera.localPosition = Vector3.Lerp(camera.localPosition, startPos, 1 * Time.deltaTime);
    }
    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;
    }
    private void PlayMotion(Vector3 motion)
    {
        camera.localPosition += motion;
    }

}
