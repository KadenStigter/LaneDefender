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
    [SerializeField] private float _spawnRate = 1.0f;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private bool _isSpawning = true;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnRate);
        while (true)
        {
            yield return wait;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
