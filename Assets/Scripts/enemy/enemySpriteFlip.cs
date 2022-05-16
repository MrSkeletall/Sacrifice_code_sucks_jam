using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemySpriteFlip : MonoBehaviour
{
    SpriteRenderer enemySprite;
    AIPath aiPath; //a* ai path 

    private void Awake()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        aiPath = GetComponent<AIPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01)
        {
            enemySprite.flipX = true;
        }
        else
        {
            enemySprite.flipX = false;
        }
    }
}
