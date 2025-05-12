/*****************************************************************************
// File Name : StartScript.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script makes the start button on the main menu work
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
