/*****************************************************************************
// File Name : enemyAiPatrol.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 22, 2025
//
// Brief Description : Allows for gameobjects with this script and navmesh to patrol areas using navmesh.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAiPatrol : MonoBehaviour
{
    [SerializeField] private GameObject player;

    NavMeshAgent agent;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destPoint;
    bool walkPointSet;
    [SerializeField] float Range;

    //state change
    [SerializeField] float sightRange;
    private bool playerInSight;

    /// <summary>
    /// sets variables
    /// </summary>
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// allows enemy to patrol or chase if player is within line of sight
    /// </summary>
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        if (!playerInSight) Patrol();
        if (playerInSight) Chase();
    }
    /// <summary>
    /// makes enemy chase player if within line of sight
    /// </summary>
    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }
    /// <summary>
    /// makes enemy patrol when not chasing player
    /// </summary>
    void Patrol()
    {
        if (!walkPointSet) SearchForDest();
        if (walkPointSet) agent.SetDestination(destPoint);
        if(Vector3.Distance(transform.position, destPoint) < 10) walkPointSet = false;
    }
    /// <summary>
    /// sets destiation for where enemy patrols
    /// </summary>
    void SearchForDest()
    {
        float Z = Random.Range(-Range, Range);
        float X = Random.Range(-Range, Range);

        destPoint = new Vector3(transform.position.x + X, transform.position.y, transform.position.z + Z);

        if(Physics.Raycast(destPoint,Vector3.down,groundLayer))
        {
            walkPointSet = true;
        }
    }
}
