/*****************************************************************************
// File Name : scoreController.cs
// Author : Gabriel Flores-Martinez
// Creation Date : March 31, 2025(Created before, but had this header places on the 31th)
//
// Brief Description : This Script tracks score
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreController : MonoBehaviour
{

    //refurbish this into a point system code and not coin code
    //and for enemy death and such, ensure the code for them has it so when they die they have a reference here that makes
    //it so that it triggers a function here that updates score

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioSource collectCoin;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter(Collider thingIHit)
    {
        //If i collide with coin, destroys coin
        if(thingIHit.gameObject.CompareTag("Coin"))
        {
            score += 10;
            collectCoin.Play();
            UpdateScore();
            Destroy(thingIHit.gameObject);
           
        }
        /*if (thingIHit.gameObject.CompareTag("Enemy") && !SpinDash.SpinDashing)
        {
            score += 100;
            //KillEnemy.Play();
            UpdateScore();
            Destroy(thingIHit.gameObject); or instead of destroying here. On enemy's, have a script that dramatifies their death while Invoking something that would Destroy() after.

        }*/
    }
    /// <summary>
    /// If player dies, this will remove points.(Might remove this now that player cant really die unless stuff like running into obstacles or falling off map can have to kill the player
    /// </summary>
    public void PlayerDie()
    {
        score -= 500;
        UpdateScore();
    }
}
