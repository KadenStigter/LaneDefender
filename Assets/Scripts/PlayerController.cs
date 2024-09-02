/*****************************************************************************
// File Name : PlayerController.cs
// Author : Kaden Stigter
// Creation Date : August 27, 2024
//
// Brief Description : Sets up the main controls for the player in the game
*****************************************************************************/
using System;
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
    private InputAction restart;
    private InputAction quit;
    private bool isPlayerMoving;
    private bool firing = false;
    private bool ableToFire = true;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _playerSpeed = 5;
    [SerializeField] private GameObject _missle;
    [SerializeField] private int _missleSpeed;
    private int missleDirection = 1;
    private float moveDirection;
    private GameController gameController;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        shoot = playerInput.currentActionMap.FindAction("Shoot");
        restart = playerInput.currentActionMap.FindAction("Restart");
        quit = playerInput.currentActionMap.FindAction("Quit");

        move.started += Move_started;
        move.canceled += Move_canceled;
        shoot.started += Shoot_started;
        shoot.canceled += Shoot_canceled;
        restart.started += Restart_started;
        quit.started += Quit_started;

        isPlayerMoving = false;
    }

    /// <summary>
    /// allows the player to fire a laser
    /// </summary>
    /// <param name="context"></param>
    private void Shoot_started(InputAction.CallbackContext context)
    {
        var projectile = Instantiate(_missle, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(_missleSpeed * missleDirection, 0);
        firing = true;
        ableToFire = false;
    }

    private void Shoot_canceled(InputAction.CallbackContext context)
    {
        firing = false;
        ableToFire = true;
    }

    /// <summary>
    /// prevents any issues with certain inputs
    /// </summary>
    private void OnDestroy()
    {
        move.started -= Move_started;
        move.canceled -= Move_canceled;
        shoot.started -= Shoot_started;
        shoot.canceled -= Shoot_canceled;
        restart.started -= Restart_started;
        quit.started -= Quit_started;
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
    /// resets the game
    /// </summary>
    private void Restart_started(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// ends the game when the player presses q
    /// </summary>
    private void Quit_started(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.LoseALife(); //taken from GameContorller script
            Destroy(collision.gameObject);
        }
    }


    /// <summary>
    /// sets up the player to move in a certain direction
    /// </summary>
    private void FixedUpdate()
    {
        /*controls the player's speed*/
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
