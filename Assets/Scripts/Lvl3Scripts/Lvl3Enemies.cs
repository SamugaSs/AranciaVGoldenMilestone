/*****************************************************************************
// File Name : CheckPoint.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script sets the move direction and rotation of the 3rd level enemies
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Enemies : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Collider Enemy;

    /// <summary>
    /// Sets rotation
    /// </summary>
    private void Start()
    {
        Enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    
    /// <summary>
    /// Continously moves enemy forward
    /// </summary>
    void Update()
    {
        Enemy.transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }


}