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
    private float moveDirection;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        shoot = playerInput.currentActionMap.FindAction("Shoot");

        move.started += Move_started;
        move.canceled += Move_canceled;
        shoot.started += Shoot_started;
    }

    /// <summary>
    /// prevents any issues with certain inputs
    /// </summary>
    private void OnDestroy()
    {
        move.started -= Move_started;
        move.canceled -= Move_canceled;
        shoot.started -= Shoot_started;
    }

    /// <summary>
    /// Allows the player to move the character
    /// </summary>
    /// <param name="context"></param>
    private void Move_started(InputAction.CallbackContext context)
    {
        isPlayerMoving = true;
    }
    private void Move_canceled(InputAction.CallbackContext context)
    {
        isPlayerMoving = false;
    }

    /// <summary>
    /// allows the player to fire a laser
    /// </summary>
    /// <param name="context"></param>
    private void Shoot_started(InputAction.CallbackContext context)
    {

    }
    
    /// <summary>
    /// resets the game
    /// </summary>
    private void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// ends the game when the player presses q
    /// </summary>
    private void OnQuit()
    {
        Application.Quit();
    }

    /// <summary>
    /// sets up the player to move in a certain direction
    /// </summary>
    private void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            _player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _playerSpeed * moveDirection);
        }
        else
        {
            _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (isPlayerMoving)
        {
            moveDirection = move.ReadValue<float>();
        }
    }
}
