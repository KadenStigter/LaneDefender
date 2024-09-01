/*****************************************************************************
// File Name : FireMissle.cs
// Author : Kaden Stigter
// Creation Date : August 31, 2024
//
// Brief Description : Allows a missle to be fired when space is pressed
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class FireMissle : MonoBehaviour
{
    private GameController gameController;
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if(GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
