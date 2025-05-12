/*****************************************************************************
// File Name : Lvl3EnemyDelete.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script deletes the enemys in lvl 3 once they hit this trigger
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3EnemyDelete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Langsat"))
        {
            Destroy(other.gameObject);
        }
    }
}
