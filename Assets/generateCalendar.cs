using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generateCalendar : MonoBehaviour
{
    public GameObject dayPrefab; // Reference to the "Day" prefab
    // public GameObject text;
    // public GameObject image;
    public List<Sprite> spriteChoices;
    public int daysInMonth = 30; // Number of days in the month

    void Start()
    {

        // Loop through each day in the month
        for (int i = 1; i <= daysInMonth; i++)
        {
            var rand = Random.Range(-6, 4); //70% none, 10% for each events
            if (rand <= 0) {
                rand = 0;
            }
            if (i <= 3) {
                rand = 0;
            }

            // Instantiate a new "Day" prefab
            GameObject day = Instantiate(dayPrefab, transform);
            
            // Set the day number on the Text component
            // Debug.Log(day.GetComponentInChildren<TMPro.TextMeshProUGUI>());
            day.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = i.ToString();
            Debug.Log(day.GetComponentInChildren<Image>());
            Debug.Log(rand);
            day.GetComponentsInChildren<Image>()[1].sprite = spriteChoices[rand];
            
            // Set the position of the day based on its index
            // day.transform.position = new Vector3(i % 7, -i / 7, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
