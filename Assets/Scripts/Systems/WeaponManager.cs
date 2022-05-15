using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;

    ThingHolder hand;

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<ThingHolder>();
        setWeapon(weapons[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWeapon(GameObject weapon)
    {
        GameObject newWeapon = Instantiate(weapon, transform.position, Quaternion.identity);

        hand.currentHeld = newWeapon;
    }

    

}
