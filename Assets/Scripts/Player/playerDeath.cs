using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDeath : MonoBehaviour
{
    // Start is called before the first frame update

    int health = 3;
    bool canTakeDam = true;
    Animation anim;


    void Start()
    {
        GetComponent<Animation>();
    }

    // Update is called once per frame
   

    void die()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(canTakeDam == true)
            {
                anim.Play();
                health--;
                canTakeDam = false;
                Invoke("allowHits", 2f);
            }
            die();
        }
    }

    void allowHits()
    {
        canTakeDam = true;
    }

}
