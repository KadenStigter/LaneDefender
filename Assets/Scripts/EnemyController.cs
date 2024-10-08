/*****************************************************************************
// File Name : FireMissle.cs
// Author : Kaden Stigter
// Creation Date : August 31, 2024
//
// Brief Description : Controls the speed and the hitpoints of each enemy
*****************************************************************************/

using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private int _speed;
    private int moveDirection = -1;
    [SerializeField] private int _health;
    private Rigidbody2D enemyRb;
    [SerializeField] private AudioClip _hit;
    [SerializeField] private AudioClip _death;
    public Animator animator;

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
            AudioSource.PlayClipAtPoint(_hit, transform.position);
            Destroy(collision.gameObject);
            if (_health <= 0)
            {
                animator.SetBool("IsDead", true);
                Destroy(gameObject);
                gameController.UpdateScore();
                AudioSource.PlayClipAtPoint(_death, transform.position);
            }
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.LoseALife();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// what happens when the enemy takes damage
    /// </summary>
    /// <returns></returns>
    IEnumerator enemyDamage()
    {
        animator.SetBool("IsHit", true);
        enemyRb.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsHit", false);
        enemyRb.velocity = new Vector2(_speed * moveDirection, 0);

    }
}
