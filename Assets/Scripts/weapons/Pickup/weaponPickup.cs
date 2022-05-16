using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    public int weaponId;
    Canvas pickupText;

    private void Awake()
    {
        pickupText = GetComponentInChildren<Canvas>();
    }


    // Start is called before the first frame update
    void Start()
    {
        pickupText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        pickupText.enabled = true;
    }


}
