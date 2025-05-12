/*****************************************************************************
// File Name : SuperRun.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 16, 2025
//
// Brief Description : This script is used for the SuperRun powerup
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuperRun : MonoBehaviour
{
    private playerMovement playerMovement;
    private RespawnItem respawnItem;

    [SerializeField] private AudioSource Collect;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<playerMovement>();
        respawnItem = GameObject.FindObjectOfType<RespawnItem>();
    }

    private void OnTriggerEnter(Collider thingIHit)
    {
        //If i collide with powerup, destroy powerup and activate
        if (thingIHit.gameObject.CompareTag("SupRun"))
        {

            Destroy(thingIHit.gameObject);

            Collect.Play();
            playerMovement.SuperRunActive();
            //StartCoroutine(respawnItem.Respawn());
            //this is what is causing "Object reference not set" but why?

        }
    }
}
