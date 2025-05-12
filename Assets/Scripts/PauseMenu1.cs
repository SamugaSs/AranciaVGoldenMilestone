/*****************************************************************************
// File Name : PauseMenu1.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script is for the PauseMenu
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    public void OnPause(InputAction.CallbackContext callbackContext)
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;

        //ensure once I implement cursor locking that I implement here that the cursor is freed 
    }

    /*public void OnResume(InputAction.CallbackContext callbackContext)
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OnHome(InputAction.CallbackContext callbackContext)
    {
        SceneManager.LoadScene(0);
    }
    public void OnRestart(InputAction.CallbackContext callbackContext)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
    public void Resume()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}