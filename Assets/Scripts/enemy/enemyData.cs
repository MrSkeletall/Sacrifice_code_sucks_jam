using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyData : MonoBehaviour
{
    AIDestinationSetter aiTarget;
    GameManager gameManager;

    int health = 20;
    int currentHealth;
    public int pointValue;
    [SerializeField] GameObject corpse;

    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        aiTarget = GetComponent<AIDestinationSetter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        
        aiTarget.target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dealDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        Debug.Log("Enemy took: " + damageTaken + " current health is: " + currentHealth);
        if (currentHealth <= 0)
        {
            enemyDeath();
        }
    }

    void enemyDeath()
    {
        Instantiate(corpse, transform.position, Quaternion.identity);
        gameManager.score(pointValue);
        Destroy(gameObject);
    }

}
