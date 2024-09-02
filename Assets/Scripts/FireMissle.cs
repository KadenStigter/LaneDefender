/*****************************************************************************
// File Name : FireMissle.cs
// Author : Kaden Stigter
// Creation Date : August 31, 2024
//
// Brief Description : Allows a missle to be fired when space is pressed
*****************************************************************************/

using UnityEngine;

public class FireMissle : MonoBehaviour
{
    private GameController gameController;

    /// <summary>
    /// Allows the bullet to move in a horizontal direciton when shot
    /// </summary>
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if(GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
    }
}
