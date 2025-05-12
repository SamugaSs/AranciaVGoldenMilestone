/*****************************************************************************
// File Name : CheckPoint.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script ensures that the sewer water continously flows up and down on a set timer
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Water : MonoBehaviour
{
    private int timer = 5;
    [SerializeField] private float speed;
    [SerializeField] private Collider Collide;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        Invoke("Rise", timer);
    }

    private void Update()
    {
        Collide.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
    }

    void Rise()
    {
        speed = 1.25f;
        Invoke("Pause", timer);
    }

    void Pause()
    {
        speed = 0f;
        Invoke("Fall", timer);
    }

    void Fall()
    {
        speed = -1.25f;
        Invoke("Pause2", timer);
    }

    void Pause2()
    {
        speed = 0f;
        Invoke("Rise", timer);
    }
}
