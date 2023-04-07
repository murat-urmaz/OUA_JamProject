using ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] SpawnPoint;
    [SerializeField] private Transform playerTrasform;
    [SerializeField] float spawnDelay;
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            GameObject newEnemy = ObjectPooler.instance.SpawnFromPool("Enemy", SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyStatus>().enemyHealty = 100;
            newEnemy.GetComponent<EnemyMove>().targetTransform = playerTrasform;
        }

    }
}
