using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimShoot : MonoBehaviour
{
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

        Vector3 playerScreenPoint = cam.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - playerScreenPoint.x, mousePos.y - playerScreenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
