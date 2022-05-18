using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tommyGunner : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    public GameObject bulletPrefab;
    weaponData wData;
    WeaponManager wManager;

    float timeToNextShot = 0f;
    [SerializeField] float fireRate = 15f;


    // Start is called before the first frame update
    void Start()
    {
        wData = GetComponent<weaponData>();
        wManager = GameObject.Find("Player").GetComponentInChildren<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToNextShot)
        {
            timeToNextShot = Time.time + 1/fireRate;
            fire();
            wData.bullets--;
        }
        if (wData.bullets <= 0)
        {
            Destroy(gameObject);
            wManager.WeaponId = 0;
        }

    }

    void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * wData.bulletSpeed, ForceMode2D.Impulse);
       

    }

}
