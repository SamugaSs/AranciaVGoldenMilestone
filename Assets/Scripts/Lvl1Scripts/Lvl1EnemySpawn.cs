/*****************************************************************************
// File Name : Lvl1EnemySpawn.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : This script set's the active state for Gameobjects
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1EnemySpawn : MonoBehaviour
{

    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Hole;
    [SerializeField] private GameObject InvisibleWall;
    [SerializeField] private AudioSource Collapse;
    #region Wood
    [SerializeField] private GameObject Wood;
    [SerializeField] private GameObject Wood2;
    [SerializeField] private GameObject Wood3;
    [SerializeField] private GameObject Wood4;
    [SerializeField] private GameObject Wood5;
    [SerializeField] private GameObject Wood6;
    [SerializeField] private GameObject Wood7;
    [SerializeField] private GameObject Wood8;
    [SerializeField] private GameObject Wood9;
    [SerializeField] private GameObject Wood10;
    [SerializeField] private GameObject Wood11;
    [SerializeField] private GameObject Wood12;
    [SerializeField] private GameObject Wood13;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player"))
        {
            Collapse.Play();
            InvisibleWall.gameObject.SetActive(true);
            Enemy1.gameObject.SetActive(true);
            Enemy2.gameObject.SetActive(true);
            Hole.gameObject.SetActive(true);
            Wood.gameObject.SetActive(true);
            Wood2.gameObject.SetActive(true);
            Wood3.gameObject.SetActive(true);
            Wood4.gameObject.SetActive(true);
            Wood5.gameObject.SetActive(true);
            Wood6.gameObject.SetActive(true);
            Wood7.gameObject.SetActive(true);
            Wood8.gameObject.SetActive(true);
            Wood9.gameObject.SetActive(true);
            Wood10.gameObject.SetActive(true);
            Wood11.gameObject.SetActive(true);
            Wood12.gameObject.SetActive(true);
            Wood13.gameObject.SetActive(true);
        }
    }


    public void Reset()
    {
        InvisibleWall.gameObject.SetActive(false);
        Enemy1.gameObject.SetActive(false);
        Enemy2.gameObject.SetActive(false);
        Enemy1.gameObject.transform.position = new Vector3(-345.83f, -0.46f, 790.12f);
        Enemy2.gameObject.transform.position = new Vector3(-345.83f, -0.46f, 804.69f);
        Hole.gameObject.SetActive(false);
        Wood.gameObject.SetActive(false);
        Wood2.gameObject.SetActive(false);
        Wood3.gameObject.SetActive(false);
        Wood4.gameObject.SetActive(false);
        Wood5.gameObject.SetActive(false);
        Wood6.gameObject.SetActive(false);
        Wood7.gameObject.SetActive(false);
        Wood8.gameObject.SetActive(false);
        Wood9.gameObject.SetActive(false);
        Wood10.gameObject.SetActive(false);
        Wood11.gameObject.SetActive(false);
        Wood12.gameObject.SetActive(false);
        Wood13.gameObject.SetActive(false);
    }
}
