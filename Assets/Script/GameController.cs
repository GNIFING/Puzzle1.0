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
    private int money = 100;

    public bool shoes1Buyed;
    public bool shoes2Buyed;
    public bool shoes3Buyed;
    public int shoesEquip;

    public bool staminaBuff1Buyed;
    public bool staminaBuff2Buyed;

    public bool studyCourse1Buyed;
    public bool studyCourse2Buyed;

    public bool magnetBuyed;

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

        PlayerPrefs.SetInt("shoes1Buyed", shoes1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("shoes2Buyed", shoes1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("shoes3Buyed", shoes1Buyed ? 1 : 0);

        PlayerPrefs.SetInt("shoesEquip", shoesEquip);

        PlayerPrefs.SetInt("staminaBuff1Buyed", staminaBuff1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("staminaBuff2Buyed", staminaBuff2Buyed ? 1 : 0);
        PlayerPrefs.SetInt("studyCourse1Buyed", studyCourse1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("studyCourse2Buyed", studyCourse2Buyed ? 1 : 0);
        PlayerPrefs.SetInt("magnetBuyed", magnetBuyed ? 1 : 0);

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
