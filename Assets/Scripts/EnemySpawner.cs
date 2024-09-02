/*****************************************************************************
// File Name : EnemySpawner.cs
// Author : Kaden Stigter
// Creation Date : August 31, 2024
//
// Brief Description : Spawns random enemies at specific points at random points
*****************************************************************************/

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float SpawnRate;
    [SerializeField] private GameObject[] _enemy;
    private bool canSpawn = true;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        StartCoroutine(Spawner());
    }

    /// <summary>
    /// helps spawn the enemies
    /// </summary>
    /// <returns></returns>
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(SpawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, _enemy.Length);
            int randPos = Random.Range(0, 4);
            GameObject enemyToSpawn = _enemy[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }
}
