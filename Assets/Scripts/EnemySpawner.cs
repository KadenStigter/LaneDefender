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
    private float spawnX = 7.0f;
    private float[] spawnY;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        StartCoroutine(Spawner());
        spawnY = new float[5];
        spawnY = new float[] { 0.0f, 1.0f, 2.0f, 3.0f, 4.0f };
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
            Vector3 newPosObs = new Vector3();
            newPosObs.x = spawnX;
            int randPos = Random.Range(0, spawnY.Length);
            newPosObs.y = spawnY[randPos];
            Instantiate(enemyToSpawn, newPosObs, Quaternion.identity);
        }
    }
}
