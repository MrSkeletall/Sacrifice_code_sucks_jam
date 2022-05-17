using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyData : MonoBehaviour
{
    AIDestinationSetter aiTarget;

    int health = 20;
    int currentHealth;
    public float pointValue;
    [SerializeField] GameObject corpse;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        aiTarget = GetComponent<AIDestinationSetter>();
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
        Destroy(gameObject);
    }

}
