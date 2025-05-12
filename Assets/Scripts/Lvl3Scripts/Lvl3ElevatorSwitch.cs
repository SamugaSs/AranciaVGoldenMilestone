/*****************************************************************************
// File Name : Lvl3ElevatorSwitch.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script allows the player to call back the elevator
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3ElevatorSwitch : MonoBehaviour
{

    private Lvl3Elevator Elevator;
    [SerializeField] private AudioSource Interact;

    // Start is called before the first frame update
    void Start()
    {
        Elevator = GameObject.FindObjectOfType<Lvl3Elevator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Elevator.Switch();
        Interact.Play();
    }
}
