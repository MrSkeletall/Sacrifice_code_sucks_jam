using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //enemySpawns
    public Transform[] weaponSpawns;
    public Transform[] enemySpawns;

    public GameObject enemy;

    public int maxEnemys = 2;
    GameObject[] currentEnemys;

    //scoreing event
    public int scoreEvent = 100;
    int nextEventThreshold;

    //components to grab
    //Canvas uiCanvas;
    public scoreSystem scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
       
        
        StartCoroutine(SpawnCorutine(enemySpawns));
        
    }

    IEnumerator SpawnCorutine(Transform[] spawnPoints)
    {
        currentEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        while(currentEnemys.Length < maxEnemys)
        {
            Vector3 spawnPoint = spawnPoints[Random.Range(0, enemySpawns.Length)].position;
            Instantiate(enemy, spawnPoint, Quaternion.identity);
            int delay = Random.Range(2, 6);
            Debug.Log("spawned enemy: waiting " + delay);
            yield return new WaitForSeconds(delay);
        }
        //Debug.Log("done spawning");

        yield return new WaitForSeconds(3);
    }

    void scoreEvents()
    {

    }
    

}
