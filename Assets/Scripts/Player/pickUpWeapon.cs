using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpWeapon : MonoBehaviour
{
    WeaponManager weaponManager;

    private void Awake()
    {
        //get the weapon manager on the hand 
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool canPickup = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && canPickup == true)
        {
            weaponPickup pickup = pickupItem.GetComponent<weaponPickup>();
            int wepId = pickup.weaponId;
            weaponManager.WeaponId = wepId;
            Destroy(pickupItem.gameObject, 0.1f);
        }
    }

    Collider2D pickupItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        canPickup = true;
        Debug.Log(canPickup);
        pickupItem = collision;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canPickup = false;
        Debug.Log(canPickup);
        pickupItem = null;

    }

    
}
