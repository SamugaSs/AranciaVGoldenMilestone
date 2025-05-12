/*****************************************************************************
// File Name : HealthController.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script is where Health is tracked along with player death
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    private CheckPoint checkPoint;
    private Lvl1EnemySpawn Spawn;
    private MazeRun Run;
    private MovePoints Points;
    private WaterRise RisingWater;
    private MovePoints Move;
    private int health;
    private int deathTime = 5;
    private Vector3 CheckpointLocation;
    [SerializeField] private AudioSource Collect;
    [SerializeField] private AudioSource nextLevel;
    [SerializeField] private float loadDelay = 1.5f;
    [SerializeField] private GameObject player;

    [SerializeField] public Transform respawnPoint;
    public static HealthController Instance;

    #region Hearts
    [SerializeField] private GameObject Heart1;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private GameObject Heart3;
    [SerializeField] private GameObject Heart4;
    [SerializeField] private GameObject Heart5;
    [SerializeField] private GameObject HeartBroke1;
    [SerializeField] private GameObject HeartBroke2;
    [SerializeField] private GameObject HeartBroke3;
    [SerializeField] private GameObject HeartBroke4;
    [SerializeField] private GameObject HeartBroke5;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        checkPoint = GameObject.FindObjectOfType<CheckPoint>();
        Spawn = GameObject.FindObjectOfType<Lvl1EnemySpawn>();
        Run = GameObject.FindObjectOfType<MazeRun>();
        Points = GameObject.FindObjectOfType<MovePoints>();
        RisingWater = GameObject.FindObjectOfType<WaterRise>();
        Move = GameObject.FindObjectOfType<MovePoints>();
        Instance = this;
    
    }

    private void Update()
    {
        if (health == 5)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(true);
            Heart4.gameObject.SetActive(true);
            Heart5.gameObject.SetActive(true);
            HeartBroke1.gameObject.SetActive(false);
            HeartBroke2.gameObject.SetActive(false);
            HeartBroke3.gameObject.SetActive(false);
            HeartBroke4.gameObject.SetActive(false);
            HeartBroke5.gameObject.SetActive(false);
        }
        else if (health == 4)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(true);
            Heart4.gameObject.SetActive(true);
            Heart5.gameObject.SetActive(false);
            HeartBroke1.gameObject.SetActive(false);
            HeartBroke2.gameObject.SetActive(false);
            HeartBroke3.gameObject.SetActive(false);
            HeartBroke4.gameObject.SetActive(false);
            HeartBroke5.gameObject.SetActive(true);
        }
        else if (health == 3)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(true);
            Heart4.gameObject.SetActive(false);
            Heart5.gameObject.SetActive(false);
            HeartBroke1.gameObject.SetActive(false);
            HeartBroke2.gameObject.SetActive(false);
            HeartBroke3.gameObject.SetActive(false);
            HeartBroke4.gameObject.SetActive(true);
            HeartBroke5.gameObject.SetActive(true);
        }
        else if (health == 2)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(false);
            Heart4.gameObject.SetActive(false);
            Heart5.gameObject.SetActive(false);
            HeartBroke1.gameObject.SetActive(false);
            HeartBroke2.gameObject.SetActive(false);
            HeartBroke3.gameObject.SetActive(true);
            HeartBroke4.gameObject.SetActive(true);
            HeartBroke5.gameObject.SetActive(true);
        }
        else if (health == 1)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);
            Heart4.gameObject.SetActive(false);
            Heart5.gameObject.SetActive(false);
            HeartBroke1.gameObject.SetActive(false);
            HeartBroke2.gameObject.SetActive(true);
            HeartBroke3.gameObject.SetActive(true);
            HeartBroke4.gameObject.SetActive(true);
            HeartBroke5.gameObject.SetActive(true);
        }
        else
        {
            Heart1.gameObject.SetActive(false);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);
            Heart4.gameObject.SetActive(false);
            Heart5.gameObject.SetActive(false);
            HeartBroke1.gameObject.SetActive(true);
            HeartBroke2.gameObject.SetActive(true);
            HeartBroke3.gameObject.SetActive(true);
            HeartBroke4.gameObject.SetActive(true);
            HeartBroke5.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("End"))
        {
            GetComponent<playerMovement>().enabled = false;

            GetComponent<PlayerInput>().enabled = false;

            nextLevel.Play();
            Invoke("Onward", loadDelay);
        }
        if (other.gameObject.name.Contains("Enemy"))
        {
            UpdateHealth();
        }
        if (other.gameObject.name.Contains("Langsat"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            PCveDied();
        }
        if (other.gameObject.name.Contains("Spikes"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            PCveDied();
        }
        if (other.gameObject.name.Contains("Pit"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            pitDied();
        }
        if (other.gameObject.name.Contains("PCve"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            PCveDied();
        }
        if (other.gameObject.name.Contains("Humongous"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            pitDied();
        }
  
        if(other.gameObject.name.Contains("MzeEn"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            MczEnDied();
        }
        if(other.gameObject.name.Contains("Sean"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            PCveDied();
        }
        if(other.gameObject.name.Contains("Ocean"))
        {
            health = 0;
            GetComponent<playerMovement>().enabled = false;
            GetComponent<PlayerInput>().enabled = false;
            OceanDied();
        }
        if (other.gameObject.name.Contains("Cheese"))
        {
            RegainHealth();
            Collect.Play();
            Destroy(other.gameObject);
        }
    }

    private void RegainHealth()
    {
        health += 2;

        if(health > 5)
        {
            health = 5;
        }
    }
    private void UpdateHealth()
    {
            health--;
            //an sfx for when hit?

            if (health <= 0)
            {
                GetComponent<playerMovement>().enabled = false;
                GetComponent<PlayerInput>().enabled = false;

                Invoke("Died", deathTime);


                //sfx for dying

            }
      
    }
    public void Respawn()
    {
        player.transform.position = respawnPoint.position;
    }
    private void Onward()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Died()
    {
        //restart the player at the last checkpoint
        Respawn();

        // Resert movement
        GetComponent<playerMovement>().enabled = true;
        GetComponent<PlayerInput>().enabled = true;

        //reset health
        health = 5;
    }


    public void PCveDied()
    {
        Invoke("Died", deathTime);
    }

    public void MczEnDied()
    {
        Invoke("MazeDeath", deathTime);
    }
    public void OceanDied()
    {
        Invoke("OceanDeath", deathTime);
    }


    public void pitDied()
    {
        Invoke("PitDeath", deathTime);
    }
    void PitDeath()
    {
        
        Spawn.Reset();
        //restart the player at the last checkpoint
        Respawn();

        // Resert movement
        GetComponent<playerMovement>().enabled = true;
        GetComponent<PlayerInput>().enabled = true;

        //reset health
        health = 5;
    }
    void MazeDeath()
    {
        Move.speed = 0;
        Points.IndexReset();
        Run.Reset();
        
        //restart the player at the last checkpoint
        Respawn();

        // Resert movement
        GetComponent<playerMovement>().enabled = true;
        GetComponent<PlayerInput>().enabled = true;

        //reset health
        health = 5;
    }

    void OceanDeath()
    {
        RisingWater.Reset();
        //restart the player at the last checkpoint
        Respawn();

        // Resert movement
        GetComponent<playerMovement>().enabled = true;
        GetComponent<PlayerInput>().enabled = true;

        //reset health
        health = 5;
    }

    /// <summary>
    /// For when player falls off the map
    /// </summary>
    /* void Update()
     {
         if (transform.position.y < dyingYValue && !isDead)
         {
             //kills
             UpdateHealth();
         }
     }*/
}


