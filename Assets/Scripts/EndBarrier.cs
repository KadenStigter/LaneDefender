/*****************************************************************************
// File Name : EndBarrier.cs
// Author : Kaden Stigter
// Creation Date : September 1, 2024
//
// Brief Description : What happens when an enemy collides with the end of the screen
*****************************************************************************/

using UnityEngine;

public class EndBarrier : MonoBehaviour
{
   private GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameController.LoseALife();
        }
    }
}
