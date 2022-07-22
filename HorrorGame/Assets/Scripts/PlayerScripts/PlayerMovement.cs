using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //  HeadBobbing||Climb(?)||GrappelHook||Gliding
    [Header("Movement")] // [header] gibt eine überschrift zum SerializedField
    [SerializeField] float MovementSpeed;
    [SerializeField] float WalkSpeed;
    [SerializeField] float SprintSpeed;

    public MovementState State;

    float HorizontalInput;
    float VerticalInput;
    [SerializeField] Transform Orientation;
    Vector3 MoveDirection;
    Rigidbody Rb;

    [Header("GroundCheck")]
    [SerializeField] private float Playerheight;
    [SerializeField] private float GroundDrag;
    public LayerMask ground;
    bool grounded;


    [Header("Jump")]
    [SerializeField] private float JumpForce;
    [SerializeField] private float JumpCooldown;
    [SerializeField] private float AirMultiplier;
    bool jumpReady = true;


    [Header("Crouch")]
    [SerializeField] float CrouchSpeed;
    [SerializeField] float CrouchYScale;
    private float StartYScale;

    [Header("Keybind(s)")]
    public KeyCode JumpKey = KeyCode.Space;
    public KeyCode SprintKey = KeyCode.LeftShift;
    public KeyCode CrouchKey = KeyCode.C;
    public enum MovementState
    {
        Walking,
        Sprinting,
        Air,
        Crouching,


    }

    [Header("Slope Behaviour")]
    private RaycastHit slopeHit;
    [SerializeField] float maxSlopeAngle;
    private bool SlopeJump;


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.freezeRotation = true;
        StartYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        DragHandler();
        SpeedLimiter();
    }
    private void FixedUpdate()
    {
        Movement();
        GroundCheck();
        StateHandler();
    }
    private void PlayerInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(JumpKey) && jumpReady && grounded)
        {
            jumpReady = false;
            Jump();

            Invoke(nameof(JumpReset), JumpCooldown);

        }
        // crouch
        if (Input.GetKeyDown(CrouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, CrouchYScale, transform.localScale.z); // shrink
            Rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(CrouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, StartYScale, transform.localScale.z);// enlarge
        }


    }
    private void Movement()
    {
        // Richtung calculation
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizontalInput;

        if (SlopeHandling() && !SlopeJump)
        {
            Rb.AddForce(SlopeMoveDirection() * MovementSpeed * 20f, ForceMode.Force);
            if (Rb.velocity.y > 0)
                Rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        if (grounded)                                               //am boden 
            Rb.AddForce(MoveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);

        else if (!grounded)                                        // in der luft 
            Rb.AddForce(MoveDirection.normalized * MovementSpeed * 10f * AirMultiplier, ForceMode.Force);

        //gravity turnoff on slope
        Rb.useGravity = !SlopeHandling();

    }
    private void GroundCheck()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, Playerheight * 0.5f + 0.2f, ground);
    }
    private void DragHandler()
    {
        if (grounded)
            Rb.drag = GroundDrag;
        else Rb.drag = 0;


    }
    private void SpeedLimiter()
    {
        if (SlopeHandling() && !SlopeJump)
        {
            if (Rb.velocity.magnitude > MovementSpeed)
                Rb.velocity = Rb.velocity.normalized * MovementSpeed;
        }


        //Speed limit wenn benötigt
        else
        {
            Vector3 rawVel = new Vector3(Rb.velocity.x, 0f, Rb.velocity.z);
            if (rawVel.magnitude > MovementSpeed)
            {
                Vector3 limitedVel = rawVel.normalized * MovementSpeed;
                Rb.velocity = new Vector3(limitedVel.x, Rb.velocity.y, limitedVel.z);
            }
            //calculated was die max vel wäre und apllied wenn benötigt

        }

    }
    private void Jump()
    {
        SlopeJump = false;
        // reset y vel 
        Rb.velocity = new Vector3(Rb.velocity.x, 0f, Rb.velocity.z);

        Rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);

    }
    private void JumpReset()
    {
        jumpReady = true;
        SlopeJump = true;
    }
    private void StateHandler()
    {
        if (Input.GetKey(CrouchKey) && grounded)
        {
            State = MovementState.Crouching;
            MovementSpeed = CrouchSpeed;



        }
        else if (grounded && Input.GetKey(SprintKey))
        {
            State = MovementState.Sprinting;
            MovementSpeed = SprintSpeed;
        }
        else if (grounded)
        {
            State = MovementState.Walking;
            MovementSpeed = WalkSpeed;

        }
        else
        {
            State = MovementState.Air;

        }
    }
    private bool SlopeHandling()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, Playerheight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;

        }
        return false;
    }
    private Vector3 SlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(MoveDirection, slopeHit.normal);


    }

}