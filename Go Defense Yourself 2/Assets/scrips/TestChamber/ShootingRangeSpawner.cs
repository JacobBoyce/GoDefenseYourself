using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingRangeSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject[] enemies = new GameObject[1];
    public GameObject spawnList, enemyContainer;
    private int spawnPlace, savedSpawnPlace, currentEnemySpawn, numEnemiesToSpawnPerWave;
    private float timeBetweenSpawn;

    #region Spawning UI Vars
        public GameObject spawnUIObj;

        public TMP_InputField inputNumEnemies, spawnDelay;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in spawnList.transform)
        {
            spawnPoints.Add(t.gameObject);
        }
    }

    public void SpawnEnemy()
    {
        currentEnemySpawn = 0;
        numEnemiesToSpawnPerWave = int.Parse(inputNumEnemies.text);
        timeBetweenSpawn = int.Parse(spawnDelay.text);
        StartCoroutine(SpawnEnemyD());
    }

    IEnumerator SpawnEnemyD()
    {
        //find spot to spawn
        spawnPlace = Random.Range(0, spawnPoints.Count);
        while(spawnPlace == savedSpawnPlace)
        {
            spawnPlace = Random.Range(0, spawnPoints.Count);
        }
        savedSpawnPlace = spawnPlace;

        //spawn enemy
        GameObject tempEnemy = Instantiate(enemies[0], enemyContainer.transform, false);
        tempEnemy.transform.position = spawnPoints[spawnPlace].transform.position; 

        currentEnemySpawn++;

        yield return new WaitForSeconds(timeBetweenSpawn); 

        if(currentEnemySpawn < numEnemiesToSpawnPerWave)
        {
            StartCoroutine(SpawnEnemyD());
        }
    }
}