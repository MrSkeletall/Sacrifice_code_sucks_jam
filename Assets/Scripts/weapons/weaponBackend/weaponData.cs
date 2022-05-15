using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponData : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int bullets;
    public int damage;


    //class constructors
    public weaponData(int ammoCount, int damageDealtPerShot)
    {
        bullets = ammoCount;
        damage = damageDealtPerShot;
       

    }

    public weaponData(int damageDealtPerShot)
    {
        damage = damageDealtPerShot;
        


    }

    //funkofunctions

    public void weaponInit()
    {
        //precaution
        enemyLayer = LayerMask.GetMask("Enemy", "Grab");
    }


    public void addDamage()
    {

    }

    





}
