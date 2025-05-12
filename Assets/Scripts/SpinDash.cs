/*****************************************************************************
// File Name : SpinDash.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script allows the player to spindash.(Mostly just the Dashing script but working only on ground,
// multitap & much more powerful)
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpinDash : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private playerMovement pm;

    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerCam;
    private Rigidbody rb;

    [SerializeField] private float dashForce;
    [SerializeField] private float dashUpwardsForce;
    [SerializeField] private float dashDuration;
    [SerializeField] private float maxDashYSpeed;

    [SerializeField] private float dashCD;
    private float dashCDTimer;
    private Vector3 delayedForceToApply;

    private void Start()
    {
        pm = GameObject.FindObjectOfType<playerMovement>();
        rb = GameObject.FindObjectOfType<Rigidbody>();
    }


    private void Update()
    {
         if(dashCDTimer > 0)
        {
            dashCDTimer -= Time.deltaTime;
        }
    }

    private void OnSpindash()
    {
        if(pm.grounded)
        {
            //Debug.Log("Spindashing");

            if (dashCDTimer > 0) return;
            else dashCDTimer = dashCD;

            pm.dashing = true;
            pm.maxYSpeed = maxDashYSpeed;

            Transform forwardT;

            if (pm.useCameraForward)
            {
                forwardT = playerCam;
            }
            else
            {
                forwardT = orientation;
            }
            Vector3 direction = GetDirection(forwardT);


            Vector3 forceToApply = direction * dashForce + orientation.up * dashUpwardsForce;

            if (pm.disableGravity)
            {
                rb.useGravity = false;
            }

            delayedForceToApply = forceToApply;
            Invoke(nameof(DelayedDashForce), 0.025f);

            Invoke(nameof(ResetDash), dashDuration);
        }
    }


    private void DelayedDashForce()
    {
        if (pm.resetVel)
        {
            rb.velocity = Vector3.zero;
        }
        rb.AddForce(delayedForceToApply, ForceMode.Impulse);
    }

    private void ResetDash()
    {
        pm.dashing = false;
        pm.maxYSpeed = 0;
        if (pm.disableGravity)
        {
            rb.useGravity = true;
        }
    }

    private Vector3 GetDirection(Transform forwardT)
    {
        Vector3 direction = new Vector3();

        if (pm.allowAllDirections)
        {
            direction = forwardT.forward * pm.playerMove.y + forwardT.right * pm.playerMove.x;
        }
        else
        {
            direction = forwardT.forward;
        }
        if (pm.playerMove.y == 0 && pm.playerMove.x == 0)
        {
            direction = forwardT.forward;
        }
        return direction.normalized;
    }
}
