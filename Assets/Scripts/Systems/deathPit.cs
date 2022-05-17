using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathPit : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other + " hit collider");
        if(other.CompareTag("DeadEnemy"))
        {
            gameManager.score(20);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("End");
        }

    }
}
