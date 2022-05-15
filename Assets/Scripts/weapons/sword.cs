using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    Animation ani;

    private void Awake()
    {
        ani = GetComponent<Animation>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.Play();
        }
        
    }

    public void onSwordAttack()
    {
        
        Collider2D[] swordHits = Physics2D.OverlapCircleAll(transform.position + transform.up, 2);

        foreach(Collider2D hit in swordHits)
        {
            Debug.Log("you hit: " + hit);
        }
    }

}
