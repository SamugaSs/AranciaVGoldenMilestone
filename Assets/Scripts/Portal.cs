/*****************************************************************************
// File Name : Portal.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script allows the Portals to function and teleport the player
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private playerMovement Movement;
    [SerializeField] Transform destination;
    [SerializeField] private AudioSource Teleport;



    private void Start()
    {
        Movement = GameObject.FindObjectOfType<playerMovement>();
    }
    /// <summary>
    /// teleports player to Destination child
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Teleport.Play();
            Movement.Teleport(destination.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(destination.position, .4f);
        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position, direction);
    }
}
