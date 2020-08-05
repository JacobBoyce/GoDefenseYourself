using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveController : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public GameObject[] enemies = new GameObject[1];

    public GameObject spawnList, enemyContainer;
    private int numEnemiesToSpawnPerWave = 5, currentEnemySpawn, spawnPlace = 0, savedSpawnPlace = 0;
    public int enemiesLeft, currentWave = 0;
    private bool allspawnedFlag = false;
    private float timeBetweenSpawn = 2f;
    public Text waveInfo, countdown, enemiesLeftText;
    
	// Use this for initialization
	void Start ()
    {
        //reset wave counter for next playthrough
        PlayerPrefs.SetInt("waveNum", currentWave);

        //get all spawnpoints gathered in list
        foreach(Transform t in spawnList.transform)
        {
            spawnPoints.Add(t.gameObject);
        }
        StartWaves();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //set wave text info at the top -LEAVE-
        waveInfo.text =  "Wave\n" + currentWave;
        //set money text -LEAVE-
        enemiesLeftText.text = "$ " + GameObject.Find("Controller").GetComponent<UpgradeGuns>().money;
        
        if(allspawnedFlag)
        {
            if(enemiesLeft == 0)
            {
                Debug.Log("init next wave");
                InitWave();
            }
        }
	}

    public void StartWaves()
    {
        //call method that calls itself until fully spawned
        InitWave();
        //method that inits wave starting and sets variables
        //then calls spawn enemy
    }

    public void InitWave()
    {
        allspawnedFlag = false;

        currentWave++;
        PlayerPrefs.SetInt("waveNum", PlayerPrefs.GetInt("waveNum") +1);

        enemiesLeft = numEnemiesToSpawnPerWave;
        
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        //chooses spawn point and makes sure it isnt same spot as last time
        spawnPlace = Random.Range(0, spawnPoints.Count);
        while(spawnPlace == savedSpawnPlace)
        {
            spawnPlace = Random.Range(0, spawnPoints.Count);
        }
        savedSpawnPlace = spawnPlace;

        //create enemy and place it in position
        //PUT HERE SPAWNING OPTIONS OR SPAWNING METHOD TO HANDLE THAT
        GameObject tempEnemy = Instantiate(enemies[0], enemyContainer.transform, false);
        tempEnemy.transform.position = spawnPoints[spawnPlace].transform.position;

        //increment enemies spawned to eventually stop spawning
        currentEnemySpawn++;

        yield return new WaitForSeconds(timeBetweenSpawn);

        //if all enemies havent spawned, keep spawning
        if(currentEnemySpawn < numEnemiesToSpawnPerWave)
        {
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            //if done spawning turn on listener var in update?
            //increment vars
            allspawnedFlag = true;
            numEnemiesToSpawnPerWave += 1;
        } 
    }
}