using ObjectPooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] SpawnPoint;
    [SerializeField] private Transform playerTrasform;
    [SerializeField] float[] spawnDelay;
    [SerializeField] PlayerController playerController;
    [SerializeField] float[] enemyBornTime;
    

    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {

        while (true)
        {
            if (playerController.playerLevel==5)
            {
                spawnDelay[0] = Random.Range(spawnDelay[0], spawnDelay[0] + enemyBornTime[0]);
            }
            if (playerController.playerLevel == 10)
            {
                spawnDelay[1] = Random.Range(spawnDelay[1], spawnDelay[1] + enemyBornTime[1]);
            }
            if (playerController.playerLevel == 15)
            {
                spawnDelay[2] = Random.Range(spawnDelay[2], spawnDelay[2] + enemyBornTime[2]);
            }


            yield return new WaitForSeconds(spawnDelay[0]);

            GameObject newEnemy = ObjectPooler.instance.SpawnFromPool("Enemy", SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyStatus>().enemyHealty = 100;
            newEnemy.GetComponent<EnemyMove>().targetTransform = playerTrasform;
        }

    }
   
}
