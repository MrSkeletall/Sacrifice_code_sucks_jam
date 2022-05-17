using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBar : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setBar(float setPoint)
    {
        if (slider.value < setPoint)
        {
            slider.value = Mathf.Lerp(slider.value, setPoint, 0.2f);
        }
    }
}
