/*****************************************************************************
// File Name : EndScript.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script quits the game
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
