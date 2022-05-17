using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //enemySpawns
    public Transform[] enemySpawns;

    public GameObject[] weaponDrops;
    public Transform[] weaponSpawns;
    


    public GameObject enemy;

    public int maxEnemys = 2;

    GameObject[] currentEnemys;

    //scoreing event
    public int scoreEvent = 100;
    

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
        int i = 0;
        int m = i % 10;
        while(currentEnemys.Length < maxEnemys + m)
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            spawnWeapon();
        }
    }

    public void score(int points)
    {
        scoreSystem.AddScore(points);

        if(scoreSystem.SliderValue >= 100)
        {
            Debug.Log("spawning weapon");
            spawnWeapon();
            scoreSystem.SliderValue = 0;
        }
    }

    void spawnWeapon()
    {
        Vector3 spawnOffset = new Vector3(Random.Range(-2, 2), 0, 0);
        int weaponIndex = Random.Range(0, weaponDrops.Length);
        Transform spawnPoint = weaponSpawns[Random.Range(0, weaponSpawns.Length)];
        spawnPoint.position = spawnPoint.position;
        
       
        Instantiate(weaponDrops[weaponIndex], spawnPoint, false);

    }

    
    

}
