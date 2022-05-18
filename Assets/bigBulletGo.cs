using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBulletGo : MonoBehaviour
{
    

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyData>().dealDamage(30);

        }
        if (collision.gameObject.CompareTag("Level"))
        {
            Destroy(gameObject);
        }

        Destroy(gameObject, 9);
    }





}
