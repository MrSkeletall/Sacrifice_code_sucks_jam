using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceBullet : MonoBehaviour
{
    int timesBounced = 0;
    int maxBounces = 10;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(rb.velocity);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyData>().dealDamage(20);
            
        }
        if (collision.gameObject.CompareTag("Level"))
        {
            timesBounced++;
            

            if(timesBounced > maxBounces)
            {
                Destroy(gameObject);
            }

        }
    }
}
