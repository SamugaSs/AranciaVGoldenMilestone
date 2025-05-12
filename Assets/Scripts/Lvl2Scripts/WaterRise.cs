/*****************************************************************************
// File Name : WaterRise.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script makes the water rise in the second level
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    //[SerializeField] private Rigidbody rb;
    [SerializeField] private Collider Collide;
    [SerializeField] private GameObject water;
    public int Speed = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            Speed = 2;
        }
        
    }

    private void Update()
    {
        //rb.useGravity = false;
        //rb.velocity = new Vector3(0, Speed, 0);
        //Collide.transform.position = new Vector3 (0, Speed, 0);
        Collide.transform.Translate(new Vector3(0, Speed * Time.deltaTime, 0));
    }

    public void Reset()
    {
        Speed = 0;
        water.gameObject.transform.position = new Vector3(425, -59, 1164);
    }
}
