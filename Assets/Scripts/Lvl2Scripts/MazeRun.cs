/*****************************************************************************
// File Name : MazeRun.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script triggers the enemy chasing you in the second level maze
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRun : MonoBehaviour
{
    private HealthController Health;
    private MovePoints Move;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private AudioSource Crumble;


    private void Start()
    {
        Move = GameObject.FindObjectOfType<MovePoints>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            Crumble.Play();
            Move.speed = 65;
            wall.gameObject.SetActive(false);
            //Enemy.gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        wall.gameObject.SetActive(true);
        //Enemy.gameObject.SetActive(false);
        Enemy.gameObject.transform.position = new Vector3(398, 0, 567);

    }
}
