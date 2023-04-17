using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generateCalendar : MonoBehaviour
{
    public GameObject dayPrefab; // Reference to the "Day" prefab
    public GameObject seasonTitle; // Reference to season
    public List<Sprite> spriteChoices;
    public int daysInMonth = 30; // Number of days in the month
    public CalendarManager calendarManager;
    private List<GameObject> dayList;

    void Start() {
        // Loop through each day in the month
        dayList = new List<GameObject>();
        for (int i = 1; i <= daysInMonth; i++)
        {
            var rand = Random.Range(-6, 4); //70% none, 10% for each events
            if (rand <= 0) {
                rand = 0;
            }
            if (i <= 3) { // prevent any cost in early days
                rand = 0;
            }

            Debug.Log(calendarManager.day);

            // Instantiate a new "Day" prefab
            GameObject day = Instantiate(dayPrefab, transform);
            
            // Set the day number on the Text component
            // Debug.Log(day.GetComponentInChildren<TMPro.TextMeshProUGUI>());
            day.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = i.ToString();
            // Debug.Log(day.GetComponentInChildren<Image>());
            Debug.Log(rand);
            if (calendarManager.day == int.Parse(day.GetComponentInChildren<TMPro.TextMeshProUGUI>().text)) {
                day.GetComponentsInChildren<Image>()[0].color = new Color32(200,200,200,255);
                if (rand == 0) {
                    day.GetComponentsInChildren<Image>()[1].color = new Color32(200,200,200,255);
                }
            } 
            day.GetComponentsInChildren<Image>()[1].sprite = spriteChoices[rand];
            
            dayList.Add(day);
        }
        Debug.Log(dayList);
        var season_text = calendarManager.seasons[calendarManager.season_index] + ", year: " + calendarManager.year.ToString();
        Debug.Log(season_text);
        seasonTitle.GetComponent<TMPro.TextMeshProUGUI>().text = season_text;
    }

    public void CalendarRecalibrate() {
        for (int k = 0; k < dayList.Count; k++) {
            dayList[k].GetComponentsInChildren<Image>()[0].color = new Color32(255,255,255,255);
            if (dayList[k].GetComponentsInChildren<Image>()[1].sprite == null) {
                dayList[k].GetComponentsInChildren<Image>()[1].color = new Color32(255,255,255,255);
            }
        }
        var date = calendarManager.day;
        dayList[date - 1].GetComponentsInChildren<Image>()[0].color = new Color32(200,200,200,255);
        if (dayList[date - 1].GetComponentsInChildren<Image>()[1].sprite == null) {
            dayList[date - 1].GetComponentsInChildren<Image>()[1].color = new Color32(200,200,200,255);
        }
        seasonTitle.GetComponent<TMPro.TextMeshProUGUI>().text = calendarManager.seasons[calendarManager.season_index] + ", year: " + calendarManager.year.ToString();
    }
}
