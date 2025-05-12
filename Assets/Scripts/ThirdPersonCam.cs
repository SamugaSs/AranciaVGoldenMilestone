/*****************************************************************************
// File Name : ThirdPersonCam.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script allows the player to move in the direction they are facing
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private playerMovement movePlayer;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;

    [SerializeField] private float rotationSpeed;

    float XInput;
    float YInput;

    // Start is called before the first frame update
    void Start()
    {
        movePlayer = GameObject.FindObjectOfType<playerMovement>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //Vector3 inputDir = orientation.forward * YInput + orientation.right * XInput;
        Vector3 inputDir = orientation.forward * movePlayer.playerMove.y + orientation.right * movePlayer.playerMove.x;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
        //For some reason, the player won't rotate. Ill leave it for now but I should look to fix this later
        //Possibly has something to do with x rotation being locked. But unlocking it has 
    }
}
