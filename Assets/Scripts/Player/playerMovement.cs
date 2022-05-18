using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    Animator playerAnimator;


    //facingRight stuff in case I don't feel like adding an alt set of sprites faceing the other direction
    bool facingRight = true;

    float moveDirection = 0;
    bool isGrounded = false;
    
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Use this for initialization
    void Start()
    {
        //you don't gotta do t, normally transform is always acessable
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponentInChildren<Animator>();
        //in case physics system does something funny 
        r2d.freezeRotation = true;
        //
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;

        //funny boolian 
        facingRight = t.localScale.x > 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        


        // Change facing direction which im not gonna do right now so ignore it
        ///how it works: if you negatively scale a sprite it mirrors it 
        /*if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }*/

        ///velocity vector
        moveDirection = InputDir();
        SetAnim();


        //check if the player is on the ground... hence the name ground check
        GroundCheck();

        /// Jumping 
        /// its here in update because It checks keycodes, and fixed update doesnt run every frame so it could miss a key press
        if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

       
    }

    void SetAnim()
    {
        

        if(moveDirection != 0f)
        {
            playerAnimator.Play("PlayerWalk");
        }
        else
        {
            playerAnimator.Play("playerIdle");
            
        }
    }

    //gets input from keyboard
    float InputDir()
    {

        // "Horizontal" is a defult pre defined axis in the built in input system, uses [a and d] or [left arrow and right]
        float xVel = Input.GetAxisRaw("Horizontal");
        //how it works is it returns (-1) when A is down and (1) when D is down. if no keys are down it returns 0
        //you then use that value in a velocity vector, check the bottom of the script to see that
        return xVel;
    }

    void GroundCheck()
    {
        //this math to avoid doing more math... I stole this math
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.5f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        ///this is done with a Physics function that returns all collider thats within an invisible circle on the bottom of the player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //the thing about this function is it also returns the players collider, which is fortuneately refrenced in this script as mainCollider
        //so this loop checks every returned collider and just makes sure that the collision is with ANYTHING else
        //theres another way to do this with layers but in this case it was way faster to do this
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
        // shows where the ground check sphere is in the scene view so you can see if any things acting weird
        ///the color thing at the end is called a tyrnany operator or something like that... its like a really tiny if statement 
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }

   
    
    void FixedUpdate()
    {

        // set movement velocity directly because I don't want to do physics 
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        
    }
}
