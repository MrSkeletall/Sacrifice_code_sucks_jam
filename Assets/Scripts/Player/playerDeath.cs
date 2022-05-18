using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerDeath : MonoBehaviour
{
    // Start is called before the first frame update

    int health = 3;
    bool canTakeDam = true;
    TMP_Text  healthUi;



    void Start()
    {
        healthUi = GameObject.Find("Health").GetComponent<TMP_Text>();
    }

    // Update is called once per frame

    private void Update()
    {
        die();
        healthUi.text = "Health [" + health.ToString() + "]";
    }

    void die()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene("End");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(canTakeDam == true)
            {
                
                health--;
                healthUi.text = "Health [" + health.ToString() + "]";
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
