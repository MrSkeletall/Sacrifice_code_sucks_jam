using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;

    ThingHolder hand;
    
    int weaponId;
    public int WeaponId
    {
        get
        {
            return weaponId;
        }
        set
        {
            weaponId = value;
            setWeapon(weapons[weaponId]);
        }
    }


    /* weapon id list
     * weapons[0] = sword
     * weapons[1] = pistol
     * weapons[2] = 
     */

    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<ThingHolder>();
        setWeapon(weapons[0]);
        
    }

    public void setWeapon(GameObject weapon)
    {

        GameObject newWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        
        
        hand.CurrentHeld = newWeapon;
    }

    

}
