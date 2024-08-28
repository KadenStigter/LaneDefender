/*****************************************************************************
// File Name : PlayerController.cs
// Author : Kaden Stigter
// Creation Date : August 27, 2024
//
// Brief Description : Sets up the main controls for the player in the game
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    public PlayerInput playerInput;
    private InputAction move;
    private InputAction shoot;
    private bool isPlayerMoving = false;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _playerSpeed = 5;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        shoot = playerInput.currentActionMap.FindAction("Shoot");

        move.started += Move_started;
        shoot.started += Shoot_started;
    }

    /// <summary>
    /// Allows the player to move the character
    /// </summary>
    /// <param name="context"></param>
    private void Move_started(InputAction.CallbackContext context)
    {
        isPlayerMoving = true;
    }

    /// <summary>
    /// allows the player to fire a laser
    /// </summary>
    /// <param name="context"></param>
    private void Shoot_started(InputAction.CallbackContext context)
    {

    }
    
    private void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    private void OnQuit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
