using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreSystem : MonoBehaviour
{
    public TMP_Text scoreText;

    

    //score system
    int score = 0;
    float sliderValue = 0;
    public float SliderValue
    {
        get
        {
            return sliderValue;
        }
        set
        {
            sliderValue = value;
        }
    }

    Slider slider;
    //GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        scoreText.text = "Score: " + score.ToString();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        setSlider();
        
    }

    public void AddScore(int pointsAdded)
    {
        score += pointsAdded;
        sliderValue += pointsAdded;
        scoreText.text = "Score: " + score.ToString();
    }

    void setSlider()
    {
        if (slider.value != sliderValue)
        {
            slider.value = Mathf.Lerp(slider.value, sliderValue, 1.2f * Time.deltaTime);
        }
    }


}
