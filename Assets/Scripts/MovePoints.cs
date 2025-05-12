/*****************************************************************************
// File Name : MovePoints.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script allows the GameObject it is attached to to move from one point to another(points are also GameObjects)
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] public float speed;
    private int currentIndex;

    private bool canmove = true;

    /// <summary>
    /// Sets currentIndex
    /// </summary>
    void Start()
    {
        speed = 0;
        currentIndex = 0;
    }

    public void IndexReset()
    {
        canmove = false;
        currentIndex = 0;
        Invoke("moveTrue", 5);
    }

    void moveTrue()
    {
        canmove=true;
    }

    /// <summary>
    /// Moves the gameobject and rotates it when moving
    /// </summary>
    void Update()
    {
        if(canmove == true)
        {
            Vector3 targetPosition = movePoints[currentIndex].transform.position;
            Vector3 moveDirection = targetPosition - transform.position;

            // Move the GameObject
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Rotate to face the direction of movement
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f); // 5f is a turn speed factor
            }

            // Check if it's close enough to move to the next point
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentIndex++;
                if (currentIndex == movePoints.Length)
                {
                    currentIndex = 0;
                }
            }
        }
        
    }
}
