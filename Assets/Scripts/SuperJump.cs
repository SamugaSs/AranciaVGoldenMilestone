/*****************************************************************************
// File Name : SuperJump.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script is used for the SuperJump powerup
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SuperJump : MonoBehaviour
{
    private playerMovement playerMovement;
    private RespawnItem respawnItem;
    [SerializeField] private GameObject SupJump1;
    [SerializeField] private GameObject SupJump2;
    [SerializeField] private GameObject SupJump3;
    [SerializeField] private GameObject SupJump4;
    [SerializeField] private GameObject SupJumpBackground;

    [SerializeField] private AudioSource Collect;


    private void Start()
    {
        SupJump3.SetActive(false);
        SupJump3.SetActive(false);
        SupJump3.SetActive(false);
        SupJump3.SetActive(false);
        SupJumpBackground.SetActive(false);
        playerMovement = GameObject.FindObjectOfType<playerMovement>();
        respawnItem = GameObject.FindObjectOfType<RespawnItem>();
    }

    private void OnTriggerEnter(Collider thingIHit)
    {
        //If i collide with powerup, destroy powerup and activate
        if (thingIHit.gameObject.CompareTag("SupJump"))
        { 
            Destroy(thingIHit.gameObject);
            
            Collect.Play();
            //StartCoroutine(respawnItem.Respawn());

            playerMovement.SuperJumpActive();
            JumpUI();
            //this is what is causing "Object reference not set" but why?
        }
    }

    public void JumpUI()
    {
        if (playerMovement.supJumpsAmount == 4)
        {
            SupJump1.SetActive(true);
            SupJump2.SetActive(true);
            SupJump3.SetActive(true);
            SupJump4.SetActive(true);
            SupJumpBackground.SetActive(true);
        }
        else if (playerMovement.supJumpsAmount == 3)
        {
            SupJump4.SetActive(false);
        }
        else if (playerMovement.supJumpsAmount == 2)
        {
            SupJump3.SetActive(false);
        }
        else if (playerMovement.supJumpsAmount == 1)
        {
            SupJump2.SetActive(false);
        }
        else if(playerMovement.supJumpsAmount == 0)
        {
            SupJump1.SetActive(false);
            SupJumpBackground.SetActive(false);
        }
    }
}
