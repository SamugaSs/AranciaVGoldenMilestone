/*****************************************************************************
// File Name : StopWater.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script stops the water from rising in the second level
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWater : MonoBehaviour
{
    private WaterRise Rise;
    void Start()
    {
        Rise = GameObject.FindObjectOfType<WaterRise>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            Rise.Speed = 0;
        }
    }
}
