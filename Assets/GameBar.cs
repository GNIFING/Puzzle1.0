using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBar : MonoBehaviour
{

    public Slider slider;
    public RectTransform fillArea;
    public int BarScale = 10;

    public void SetMax(int val)
    {
        slider.maxValue = val;
        fillArea.sizeDelta = new Vector2(BarScale*val, 125);
    }


    public void Set(int val) 
    {
        slider.value = val;
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
