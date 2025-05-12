/*****************************************************************************
// File Name : Lvl1BigEnemies.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script 
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1BigEnemies : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    /// <summary>
    /// Moves Enemy forward
    /// </summary>
    void Update()
    {
        rb.velocity = new Vector3(85, 0, 0);
    }



}
