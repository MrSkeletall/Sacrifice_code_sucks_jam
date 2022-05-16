using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public enum STATE
    {
        IDLE, PERSUE, ATTACK,
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT,
    }
}
