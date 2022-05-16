using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponData : MonoBehaviour
{
    public LayerMask enemyLayer;
    public int bullets;
    public int damage;
    public float bulletSpeed;


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

    public void swordInit()
    {
        //precaution
        enemyLayer = LayerMask.GetMask("Enemy", "Grab");
    }

    public void gunInit(int ammoCount, int shotDam, float bulletSpeed)
    {
        bullets = ammoCount;
        damage = shotDam;
        bulletSpeed = this.bulletSpeed;
    }
    public void addDamage()
    {

    }

    





}
