using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingHolder : MonoBehaviour
{
    ///----------------explanation----------
    ///this script is on the hand of the player, and is intended to manage the active weapon, 
    ///and allow the player to pick up dead enemys and throw them

    WeaponManager wManager;
    
    

    //SerializeField sounds scarey, but it just allows you to see private vairables in the editor, so you can change it there
    [SerializeField] float throwPower = 10f;
    public Transform armPivot;


    //active item in hand
    private GameObject currentHeld;
    public GameObject CurrentHeld
    {
        get
        {
            return currentHeld;
        }
        set
        {
            Destroy(currentHeld);
            currentHeld = value; 
        }
    }


    GameObject storedWeapon;
    bool enemyHeld = false;
    bool pointedLeft = false;


    //for the GrabEnemy(); function, needed because the circle check would return the player collider instead of the enemys collider
    //specifys a layer to operate on, so only objects on that layer can be returned
    LayerMask grabMask;
    Vector3 holdOffset = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //the enemys are on a layer called grab
        grabMask = LayerMask.GetMask("Grab");
        
        

    }

    // Update is called once per frame
    void Update()
    {
        GrabEnemy();

        

    }


    void GrabEnemy()
    {
        //switch statement, because e f f i c e n t c y 
        switch (enemyHeld)
        {
            case false:
                holdWeapon();
                if (Input.GetMouseButtonDown(1))
                {
                    //check for enemys to grab
                    Collider2D targetObject = Physics2D.OverlapCircle(transform.position, 3f, grabMask);
                    //if an enemy is in the collider 
                    if (targetObject)
                    {
                        //store what weapon was being used
                        storedWeapon = currentHeld;
                        storedWeapon.SetActive(false);

                        //says what ya grabbed... not needed 
                        Debug.Log("grabbed " + targetObject);
                        enemyHeld = true;

                        //disable the rigidbody while holding because it would collide with the player and do weird things
                        //Rigidbody2D enemyRb = targetObject.gameObject.GetComponent<Rigidbody2D>();
                        //enemyRb.isKinematic = true;
                        //sets enemy as the held object
                        currentHeld = targetObject.gameObject;
                        

                    }
                }
                break;

            case true:

                //this is the t h r o w i n g system
                if (Input.GetMouseButtonUp(1))
                {

                    Rigidbody2D enemyRb = currentHeld.GetComponent<Rigidbody2D>();
                    //enemyRb.isKinematic = false;
                    enemyRb.velocity = transform.right * throwPower;
                    enemyHeld = false;
                    storedWeapon.SetActive(true);
                    currentHeld = storedWeapon;


                }
                if (currentHeld)
                {
                    //this glues the enemy to the players hand with a small offset
                    currentHeld.transform.position = transform.position + transform.right;
                    
                    currentHeld.transform.rotation = transform.rotation;
                }
                break;
        }
        
        

    }

    void holdWeapon()
    {
        currentHeld.transform.position = transform.position;

        currentHeld.transform.rotation = transform.rotation;
        flipWeapon();
    }

    //massive pain in the ass but it works,  there was probably a better way... rip 6 hours and any hopes of finishing this
    void flipWeapon()
    {
        float currentRot = armPivot.transform.rotation.eulerAngles.z;

        //check if current rot is within a particular range
        pointedLeft = currentRot >= 90f && currentRot <= 270;

        //Debug.Log("local rot:" + currentRot + "pointed left = " + pointedLeft);
        
        switch (pointedLeft)
        {
            case true:
                currentHeld.transform.localScale = -Vector3.one;
                break;

            default:
                currentHeld.transform.localScale = Vector3.one;
                break;
        }
        



    }




}
