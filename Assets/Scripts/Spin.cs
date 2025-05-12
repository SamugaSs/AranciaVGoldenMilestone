/*****************************************************************************
// File Name : Spin.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script spins the object this script is attached to
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;
    [SerializeField] private float zSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * xSpeed * Time.deltaTime, 360 * ySpeed * Time.deltaTime, 360 * zSpeed * Time.deltaTime);
    }
}
