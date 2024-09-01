/*****************************************************************************
// File Name : FireMissle.cs
// Author : Kaden Stigter
// Creation Date : August 31, 2024
//
// Brief Description : Controls the speed and the hitpoints of each enemy
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private int _speed;
    private int moveDirection = -1;
    [SerializeField] private int _health;
    private Rigidbody2D enemyRb;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.velocity = new Vector2(_speed * moveDirection, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //enemyRb.velocity = new Vector2(_speed * moveDirection, 0);
    }
}
