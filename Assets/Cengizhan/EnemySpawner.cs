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

    [SerializeField] string[] EnemyTypes;

    public GameObject GameManagerReference;

    private bool isGameStarted = false;
    private float spawnTime = 1;
    

    void Start()
    {
        //StartCoroutine(SpawnTimer());
    }

    public void StartGame(){
        //isGameStarted = true;
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {

        while (true)
        {
            if (playerController.playerLevel<=5)
            {
                spawnTime = Random.Range(spawnDelay[0], spawnDelay[0] + enemyBornTime[0]);
            }
            else if (playerController.playerLevel <= 10)
            {
                spawnTime = Random.Range(spawnDelay[1], spawnDelay[1] + enemyBornTime[1]);
            }
            else if (playerController.playerLevel <= 15)
            {
                spawnTime = Random.Range(spawnDelay[2], spawnDelay[2] + enemyBornTime[2]);
            }
            else if (playerController.playerLevel <= 20)
            {
                spawnTime = Random.Range(spawnDelay[3], spawnDelay[3] + enemyBornTime[3]);
            }
            else if (playerController.playerLevel <= 25)
            {
                spawnTime = Random.Range(spawnDelay[4], spawnDelay[4] + enemyBornTime[4]);
            }
            else
            {
                spawnTime = 0.25f;
            }


            yield return new WaitForSeconds(spawnTime);

            GameObject newEnemy = ObjectPooler.instance.SpawnFromPool(EnemyTypes[Random.Range(0, EnemyTypes.Length)], SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyStatus>().SetGameManagerReference(GameManagerReference);
            newEnemy.GetComponent<EnemyMove>().targetTransform = playerTrasform;
        }

    }
   
}
