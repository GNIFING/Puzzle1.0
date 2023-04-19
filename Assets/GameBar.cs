using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBar : MonoBehaviour
{

    public Slider slider;
    public RectTransform fillArea;
    public int BarScale = 10;
    public Image color_fill;
    public float ratio;

    public void SetMax(int val)
    {
        slider.maxValue = val;
        fillArea.sizeDelta = new Vector2(BarScale*val, 125);
    }


    public void Set(int val) 
    {
        slider.value = val;
        ratio = val / slider.maxValue;
        //set color of bar yellow(255,255,79)   (255,0,14)   80  20
        if (ratio <= 0.2)
            color_fill.color = new Color32(255,0,14,255);
        else if (ratio > 0.2 && ratio <= 0.8)
        {
            byte greenValue = (byte)(255 * (((ratio - 0.2) / 0.6)));
            byte blueValue = (byte)(14 + 65 * (((ratio - 0.2) / 0.6)));
            color_fill.color = new Color32(255, greenValue, blueValue, 255);
        }
        else
            color_fill.color = new Color32(255,255,79,255);
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
