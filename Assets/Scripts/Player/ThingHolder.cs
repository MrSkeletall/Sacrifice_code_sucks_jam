using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingHolder : MonoBehaviour
{
    bool enemyHeld = false;

    [SerializeField] float throwPower = 10f;

    GameObject currentHeld;
    LayerMask grabMask;

    // Start is called before the first frame update
    void Start()
    {
        grabMask = LayerMask.GetMask("Grab");
    }

    // Update is called once per frame
    void Update()
    {
        GrabEnemy();

        

    }


    void GrabEnemy()
    {

        switch (enemyHeld)
        {
            case false:
                if (Input.GetMouseButtonDown(1))
                {

                    Collider2D targetObject = Physics2D.OverlapCircle(transform.position, 3f, grabMask);

                    if (targetObject)
                    {
                        Debug.Log("grabbed " + targetObject);
                        enemyHeld = true;
                        Rigidbody2D enemyRb = targetObject.gameObject.GetComponent<Rigidbody2D>();
                        enemyRb.isKinematic = true;
                        currentHeld = targetObject.gameObject;
                        //targetObject.enabled = false;

                    }
                }
                break;

            case true:
                if (Input.GetMouseButtonUp(1))
                {

                    Rigidbody2D enemyRb = currentHeld.GetComponent<Rigidbody2D>();
                    enemyRb.isKinematic = false;
                    enemyRb.velocity = transform.right * throwPower;
                    enemyHeld = false;


                }
                if (currentHeld)
                {
                    currentHeld.transform.position = transform.position;
                    currentHeld.transform.rotation = transform.rotation;
                }
                break;
        }
        
        

        



    }
}
