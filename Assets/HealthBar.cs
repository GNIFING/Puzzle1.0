using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public RectTransform fillArea;
    public int healthScale = 10;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        fillArea.sizeDelta = new Vector2(healthScale*health, 125);
    }


    public void SetHealth(int health) 
    {
        slider.value = health;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
