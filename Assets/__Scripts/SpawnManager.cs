using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public int totalNumberOfEnemiesToSpawn;
    public GameObject[] enemies;

    public float maxtimeBetweenSpawn;
    public float mintimeBetweenSpawn;

    public GameObject winPanel;
    public Slider wave;

    public GameObject boss;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        wave.maxValue = totalNumberOfEnemiesToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        wave.value = totalNumberOfEnemiesToSpawn;

        if(totalNumberOfEnemiesToSpawn == 0 && GameObject.FindGameObjectWithTag("Player") != null && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Instantiate(boss, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            totalNumberOfEnemiesToSpawn = -1;
        }

        if(totalNumberOfEnemiesToSpawn == -1 && GameObject.FindGameObjectWithTag("Player") != null && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            winPanel.SetActive(true);
        }
    }

    void Spawn()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            totalNumberOfEnemiesToSpawn--;
        }        
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(Random.Range(mintimeBetweenSpawn, maxtimeBetweenSpawn));
        if(totalNumberOfEnemiesToSpawn > 0)
        {
            Spawn();
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            
        }
        
    }
}
