/*****************************************************************************
// File Name : CheckPoint.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script respawns powerups(or items overall)
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnItem : MonoBehaviour
{

    [SerializeField] private GameObject item;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnSpeed;
    private void Start()
    {
        StartCoroutine(Respawn());
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Respawn()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject M = Instantiate(item, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnSpeed);

            StartCoroutine(Respawn());
        }
    }
}
