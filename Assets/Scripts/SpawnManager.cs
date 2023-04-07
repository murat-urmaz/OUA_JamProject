using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawn edilecek d��man prefab'�
    public float spawnRadius = 5f;  // D��manlar�n spawn edilece�i yar��ap
    public int maxEnemies = 10;     // Ayn� anda en fazla ka� d��man spawn edilebilece�i
    public float spawnDelay = 1f;   // D��manlar�n spawn edilme aral���

    private List<GameObject> enemies = new List<GameObject>();  // Spawn edilmi� d��manlar�n listesi

    void Start()
    {
        StartCoroutine(SpawnEnemies());  // D��manlar�n spawn edilmesi i�in coroutine ba�lat�l�r
    }

    IEnumerator SpawnEnemies()
    {
        while (true)  // Sonsuz d�ng� i�erisinde spawn i�lemi devam eder
        {
            if (enemies.Count < maxEnemies)  // Ayn� anda en fazla ka� d��man spawn edilebilece�i kontrol edilir
            {
                // Rastgele bir pozisyon ve rotasyon hesaplan�r
                Vector2 randomPos = Random.insideUnitCircle.normalized * spawnRadius;
                

                // D��man prefab'� spawn edilir
                GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);

                // Spawn edilen d��man�n listeye eklenir
                enemies.Add(enemy);
            }

            yield return new WaitForSeconds(spawnDelay);  // D��manlar�n spawn edilme aral��� beklenir
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);  // D��man listesinden d��man silinir
        Destroy(enemy);         // D��man GameObject'i yok edilir
    }
}
