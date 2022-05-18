using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCol : MonoBehaviour
{
    [SerializeField] int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<enemyData>().dealDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Level"))
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 9);
        
    }

}
