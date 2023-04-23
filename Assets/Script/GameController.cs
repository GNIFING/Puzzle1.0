using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float maxStamina = 100f;
    private float stamina = 80f;
    private int day = 0;
    private int moveSpeedLvl = 1;
    private int studyCourseLvl = 1;
    private int money = 50;

    public bool shoes1Buyed;
    public bool shoes2;
    public bool shoes3Equip;
    public bool shoes4Equip;

    public void NextDay()
    {
        day += 1;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("maxStamina", maxStamina);
        PlayerPrefs.SetFloat("stamina", stamina);
        PlayerPrefs.SetInt("day", day);
        PlayerPrefs.SetInt("moveSpeedLvl", moveSpeedLvl);
        PlayerPrefs.SetInt("studyCourseLvl", studyCourseLvl);
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        maxStamina = PlayerPrefs.GetFloat("maxStamina", 100f);
        stamina = PlayerPrefs.GetFloat("stamina", 100f);
        day = PlayerPrefs.GetInt("day", 1);
        moveSpeedLvl = PlayerPrefs.GetInt("moveSpeedLvl", 1);
        studyCourseLvl = PlayerPrefs.GetInt("studyCourseLvl", 1);
        money = PlayerPrefs.GetInt("money", 0);
    }

    public void ResetGame()
    {
        PlayerPrefs.SetFloat("maxStamina", 100f);
        PlayerPrefs.SetFloat("stamina", 100f);
        PlayerPrefs.SetInt("day", 1);
        PlayerPrefs.SetInt("moveSpeedLvl", 1);
        PlayerPrefs.SetInt("studyCourseLvl", 1);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.Save();
    }

    public float MaxStamina { get { return maxStamina; } set { maxStamina = value; } }
    public float Stamina { get { return stamina; } set { stamina = value; } }
    public int Day { get { return day; } set { day = value; } }
    public int MoveSpeedLvl { get { return moveSpeedLvl; } set { moveSpeedLvl = value; } }
    public int StudyCourseLvl { get { return studyCourseLvl; } set { studyCourseLvl = value; } }
    public int Money { get { return money; } set { money = value; } }
}
