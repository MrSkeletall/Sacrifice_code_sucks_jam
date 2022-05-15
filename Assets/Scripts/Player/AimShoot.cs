using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShoot : MonoBehaviour
{
    //refrence to the camera of the scene, to acess mouse pos
    Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        rotato();
    }

    void rotato()
    {
        Vector3 mousePos = Input.mousePosition;
        
        //find where the player is on the screen
        Vector3 playerScreenPoint = cam.WorldToScreenPoint(transform.position);
        //vector math to get magnitude 
        Vector2 offset = new Vector2(mousePos.x - playerScreenPoint.x, mousePos.y - playerScreenPoint.y);
        //math function that turns the dot product into radians, which then gets converted to degrees
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        //feed the degrees into the funny quaternion function 
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
