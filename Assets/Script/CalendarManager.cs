using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalendarManager : MonoBehaviour
{
    public int day = 1;
    public int season_index = 0;
    public int year = 1;
    public List<string> seasons = new List<string> {
        "Spring", "Summer", "Fall", "Winter"
    };

    public void IncrementDay() {
        day += 1;
        if (day > 30) {
            season_index += 1;
            day = 1;
            if (season_index > 3) {
                season_index = 0;
                year += 1;
            }
        }
        FindObjectOfType<generateCalendar>().CalendarRecalibrate();
        Debug.Log("day: " + day.ToString() + ", season: " + seasons[season_index] + ", year: " + year.ToString());
    }
}
