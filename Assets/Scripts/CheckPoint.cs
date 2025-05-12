/*****************************************************************************
// File Name : CheckPoint.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script allows player to return back to checkpoint triggers
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private BoxCollider trigger;


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name.Contains("Player"))
        {
            HealthController.Instance.respawnPoint = transform;
            trigger.enabled = false;
        }
    }
}
