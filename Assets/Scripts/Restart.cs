/*****************************************************************************
// File Name : Restart.cs
// Author : Gabriel Flores-Martinez
// Creation Date : April 8, 2025
//
// Brief Description : This script is used to restart the game ( no longer in use)
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void OnRestart(InputAction.CallbackContext callbackContext)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
