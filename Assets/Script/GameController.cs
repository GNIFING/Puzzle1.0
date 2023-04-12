using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float stamina = 100f;
    private int day = 1;
    private int moveSpeedLvl = 1;
    private int studyCourseLvl = 1;
    private int money = 0;

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("stamina", stamina);
        PlayerPrefs.SetInt("day", day);
        PlayerPrefs.SetInt("moveSpeedLvl", moveSpeedLvl);
        PlayerPrefs.SetInt("studyCourseLvl", studyCourseLvl);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        stamina = PlayerPrefs.GetFloat("stamina", 100f);
        day = PlayerPrefs.GetInt("day", 1);
        moveSpeedLvl = PlayerPrefs.GetInt("moveSpeedLvl", 1);
        studyCourseLvl = PlayerPrefs.GetInt("studyCourseLvl", 1);
        money = PlayerPrefs.GetInt("money", 0);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetFloat("stamina", 100f);
        PlayerPrefs.SetInt("day", 1);
        PlayerPrefs.SetInt("moveSpeedLvl", 1);
        PlayerPrefs.SetInt("studyCourseLvl", 1);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.Save();
    }

    public float Stamina { get { return stamina; } set { stamina = value; } }
    public int Day { get { return day; } set { day = value; } }
    public int MoveSpeedLvl { get { return moveSpeedLvl; } set { moveSpeedLvl = value; } }
    public int StudyCourseLvl { get { return studyCourseLvl; } set { studyCourseLvl = value; } }
    public int Money { get { return money; } set { money = value; } }
}
