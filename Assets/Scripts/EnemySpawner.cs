/*****************************************************************************
// File Name : EnemySpawner.cs
// Author : Kaden Stigter
// Creation Date : August 31, 2024
//
// Brief Description : Spawns random enemies at specific points at random points
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 5.0f;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private bool _isSpawning = true;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        StartCoroutine(Spawner());
    }

    /// <summary>
    /// spawns the enemies
    /// </summary>
    /// <returns></returns>
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnRate);
        while (_isSpawning)
        {
            yield return wait;
            int rand = Random.Range(0, _enemies.Length);
            GameObject enemyToSpawn = _enemies[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
