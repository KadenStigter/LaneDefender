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

    /// <summary>
    /// what happens when an enemy is hit by a missile
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            _health -= 1;
            StartCoroutine(enemyDamage());
            Destroy(collision.gameObject);
            if (_health <= 0)
            {
                Destroy(gameObject);
                gameController.UpdateScore();
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator enemyDamage()
    {
        enemyRb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        enemyRb.velocity = new Vector2(_speed * moveDirection, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //enemyRb.velocity = new Vector2(_speed * moveDirection, 0);
    }
}
