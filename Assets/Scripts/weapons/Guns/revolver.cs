using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revolver : MonoBehaviour
{
    
    [SerializeField] Transform firePoint;
    public GameObject bulletPrefab;
    weaponData wData;

    private void Awake()
    {
        //firePoint = GetComponentInChildren<Transform>();
        wData = GetComponent<weaponData>();
    }


    // Start is called before the first frame update
    void Start()
    {
        wData.gunInit(6, 20, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fire();
        }
    }

    void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * wData.bulletSpeed, ForceMode2D.Impulse);
        
    }

}
