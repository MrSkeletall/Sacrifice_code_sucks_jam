using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    public int weaponId;
    Canvas pickupText;
    //LayerMask layer;

    
    private void Awake()
    {
        pickupText = GetComponentInChildren<Canvas>();
        //layer = LayerMask.GetMask("Level");
    }


    // Start is called before the first frame update
    void Start()
    {
        pickupText.enabled = false;
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        pickupText.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        pickupText.enabled = false;
    }

   
    
    


}
