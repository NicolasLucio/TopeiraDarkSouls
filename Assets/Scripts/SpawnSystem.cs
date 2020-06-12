using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemyPrefab;
    public float spawnTimer;
    private float newX, newZ;
    void Start()
    {
        if (spawnTimer != 0)
        {
            StartCoroutine(SpawnEnemyTimer());
        }
    }    

    IEnumerator SpawnEnemyTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            Spawn();
        }        
    }

    void Spawn()
    {
        // mudar z e x
        newX = Random.Range(0.0f, 60.0f);
        newZ = Random.Range(0.0f, 60.0f);
        Vector3 spawnPosition = new Vector3((spawnPoint.transform.position.x + newX), spawnPoint.transform.position.y, (spawnPoint.transform.position.z - newZ));
        GameObject enemyObj = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);        
    }
}
