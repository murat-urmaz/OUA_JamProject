using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;  // Spawn edilecek düþman prefab'ý
    public float spawnRadius = 5f;  // Düþmanlarýn spawn edileceði yarýçap
    public int maxEnemies = 10;     // Ayný anda en fazla kaç düþman spawn edilebileceði
    public float spawnDelay = 1f;   // Düþmanlarýn spawn edilme aralýðý

    private List<GameObject> enemies = new List<GameObject>();  // Spawn edilmiþ düþmanlarýn listesi

    void Start()
    {
        StartCoroutine(SpawnEnemies());  // Düþmanlarýn spawn edilmesi için coroutine baþlatýlýr
    }

    IEnumerator SpawnEnemies()
    {
        while (true)  // Sonsuz döngü içerisinde spawn iþlemi devam eder
        {
            if (enemies.Count < maxEnemies)  // Ayný anda en fazla kaç düþman spawn edilebileceði kontrol edilir
            {
                // Rastgele bir pozisyon ve rotasyon hesaplanýr
                Vector2 randomPos = Random.insideUnitCircle.normalized * spawnRadius;
                

                // Düþman prefab'ý spawn edilir
                GameObject enemy = Instantiate(enemyPrefab, randomPos, Quaternion.identity);

                // Spawn edilen düþmanýn listeye eklenir
                enemies.Add(enemy);
            }

            yield return new WaitForSeconds(spawnDelay);  // Düþmanlarýn spawn edilme aralýðý beklenir
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);  // Düþman listesinden düþman silinir
        Destroy(enemy);         // Düþman GameObject'i yok edilir
    }
}
