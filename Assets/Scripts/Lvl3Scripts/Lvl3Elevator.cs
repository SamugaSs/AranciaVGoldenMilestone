/*****************************************************************************
// File Name : Lvl3Elevator.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script is used for the elevator present on Level3
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Elevator : MonoBehaviour
{

    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;

    /// <summary>
    /// Sets currentIndex
    /// </summary>
    void Start()
    {
        currentIndex = 0;
        speed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            speed = 5;
        }
    }

    public void Switch()
    {
        speed = 5;
    }

    /// <summary>
    /// Moves the gameobject and rotates it when moving
    /// </summary>
    void Update()
    {
            Vector3 targetPosition = movePoints[currentIndex].transform.position;
            Vector3 moveDirection = targetPosition - transform.position;

            // Move the GameObject
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                speed = 0;
                
                currentIndex++;
                if (currentIndex == movePoints.Length)
                {
                    //Invoke("MoveAgain", 5 * Time.deltaTime);
                    currentIndex = 0;
                }
            }

    }


}
