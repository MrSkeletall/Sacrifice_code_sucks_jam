using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyData : MonoBehaviour
{
    int health = 20;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
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
        Debug.Log(gameObject.name + " in theroy would be dead");
    }

}
