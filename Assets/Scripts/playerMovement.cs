/*****************************************************************************
// File Name : CheckPoint.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script allows the player to move
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    #region Field
    [SerializeField] private PlayerInput playerInput;
    [HideInInspector] private float moveSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float playerHeight;
    [SerializeField] private float groundDrag;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashSpeedChangeFactor;
    [SerializeField] private float supJump = 1;
    [SerializeField] private Transform orientation;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float maxSlopeAngle;
    [SerializeField] private float SupRunTimer;
    #endregion

    #region variables
    private SuperJump JumpSuper;
    private RaycastHit slopeHit;
    private bool exitingSlope;
    public bool dashing;
    public MovementState state;
    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;
    private MovementState laststate;
    private bool keepMomentum;
    private float speedChangeFactor;
    public bool useCameraForward = true;
    public bool allowAllDirections = true;
    public bool disableGravity = false;
    public bool resetVel = true;
    public float maxYSpeed;
    public bool inAir = false;
    [HideInInspector] public int supJumpsAmount = 0;
    #endregion

    #region extras
    float XInput;
    float YInput;
    public bool grounded;
    bool readyToJump;
    private Vector3 moveDirection;
    Rigidbody rb;
    private Vector3 PMovement;
    [HideInInspector] public Vector3 playerMove;
    [SerializeField] GameObject Menu;
    [SerializeField] private AudioSource JumpSound;
    /* [SerializeField] private GameObject backSword;
     [SerializeField] private GameObject forwardSword;*/
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        JumpSuper = GameObject.FindObjectOfType<SuperJump>();
        //rb.freezeRotation = true;
        readyToJump = true;
    }


    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.8f + 0.2f, Ground);

        SpeedControl();
        StateHandler();

        if (state == MovementState.running)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void OnMovement(InputValue iValue)
    {
        Vector2 inputMovementValue = iValue.Get<Vector2>();
        playerMove.x = inputMovementValue.x;
        playerMove.y = inputMovementValue.y;
        /*XInput = inputMovementValue.x;
        YInput = inputMovementValue.y;*/
    }

    public enum MovementState
    {
        dashing,
        running,
        air
    }

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;

        float boostFactor = speedChangeFactor;

        while (time < difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);
            
            time += Time.deltaTime * boostFactor;

            yield return null;
        }

        moveSpeed = desiredMoveSpeed;
        speedChangeFactor = 1f;
        keepMomentum = false;
    }
    private void StateHandler()
    {
        if(dashing)
        {
            /*backSword.gameObject.SetActive(false);
            forwardSword.gameObject.SetActive(true); */
            state = MovementState.dashing;
            desiredMoveSpeed = dashSpeed;
            speedChangeFactor = dashSpeedChangeFactor;
        }
        else if (grounded)
        {
            /*forwardSword.gameObject.SetActive(false);
            backSword.gameObject.SetActive(true);*/
            inAir = false;
            state = MovementState.running;
            desiredMoveSpeed = runningSpeed;
        }
        else
        {
            /*forwardSword.gameObject.SetActive(false);
            backSword.gameObject.SetActive(true); */
            inAir = true;
            state = MovementState.air;
        }

        bool desiredMoveSpeedHasChanged = desiredMoveSpeed != lastDesiredMoveSpeed;
        if(laststate == MovementState.dashing) keepMomentum = true;

        if(desiredMoveSpeedHasChanged)
        {
            if (keepMomentum)
            {
                StopAllCoroutines();
                StartCoroutine(SmoothlyLerpMoveSpeed());
            }
            else
            {
                StopAllCoroutines();
                moveSpeed = desiredMoveSpeed;
            }
        }

        lastDesiredMoveSpeed = desiredMoveSpeed;
        laststate = state;
    }
    private void MovePlayer()
    {
        if (state == MovementState.dashing) return;

        moveDirection = orientation.forward * playerMove.y + orientation.right * playerMove.x;

        if(OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

            if(rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if(!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        rb.useGravity = !OnSlope();
        
    }

    private void SpeedControl()
    {
        if(OnSlope() && !exitingSlope)
        {
            if(rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            //limits velocity
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }    
        
        if(maxYSpeed != 0 && rb.velocity.y > maxYSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxYSpeed, rb.velocity.z);
        }
    }

    private void OnJump()
    {
        //Debug.Log("Recieving");
       
        if(readyToJump && grounded)
        {
            JumpSound.Play();
            exitingSlope = true;
            //Debug.Log("Jumping");
            readyToJump = false;
            //resets the Y velocity, ensuring consistency between jumps
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce * supJump, ForceMode.Impulse);

            Invoke(nameof(ResetJump), jumpCooldown);

            if (supJump == 2)
            {
                supJumpsAmount--;
                JumpSuper.JumpUI();
                
                if (supJumpsAmount <= 0)
                {
                    supJump = 1f;
                    supJumpsAmount = 4;
                }
            }
        }
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.8f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
            
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    public void SuperJumpActive()
    {
        supJump = 2f;
        supJumpsAmount = 4;
    }

    public void SuperRunActive()
    {
        runningSpeed = 100f;

        Invoke(nameof(SupRunOff), SupRunTimer);

    }

    public void SupRunOff()
    {
        runningSpeed = 80f;
    }

    /// <summary>
    /// Is used to teleport player
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    public void Teleport(Vector3 position)
    {
        transform.position = position;
        Physics.SyncTransforms();
        PMovement = Vector3.zero;
    }

    void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnQuit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void OnPause()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
    }
}
