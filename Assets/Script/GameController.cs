using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float maxStamina = 100f;
    private float stamina = 100f;
    private int day = 1;
    private int moveSpeedLvl = 1;
    private int studyCourseLvl = 1;
    private int money = 0;

    public bool shoes1Buyed;
    public bool shoes2Buyed;
    public bool shoes3Buyed;
    public int shoesEquip;

    public bool staminaBuff1Buyed;
    public bool staminaBuff2Buyed;

    public bool studyCourse1Buyed;
    public bool studyCourse2Buyed;

    public bool magnetBuyed;

    public bool alreadyDisplay;

    public void Start()
    {
        //ResetGame();
        LoadGame();
        Debug.Log("Day = " + day);
        if (day == 4 && !alreadyDisplay)
        {
            SceneManager.LoadScene("DialogueTest");
            alreadyDisplay = true;
            PlayerPrefs.SetInt("alreadyDisplay", 1);
        }
    }

    public void NextDay()
    {
        if(day != 9)
        {
            day += 1;
            PlayerPrefs.SetInt("day", day);
        }
        SaveGame();
        if (day == 4) {
            SceneManager.LoadScene("DialogueTest");
        }
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

        PlayerPrefs.SetInt("magnetBuyed", magnetBuyed ? 1 : 0);

        PlayerPrefs.SetInt("staminaBuff1Buyed", staminaBuff1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("staminaBuff2Buyed", staminaBuff2Buyed ? 1 : 0);

        PlayerPrefs.SetInt("studyCourse1Buyed", studyCourse1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("studyCourse2Buyed", studyCourse2Buyed ? 1 : 0);

        PlayerPrefs.SetInt("alreadyDisplay", alreadyDisplay ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        maxStamina = PlayerPrefs.GetFloat("maxStamina", 100f);
        stamina = PlayerPrefs.GetFloat("stamina", 100f);
        day = PlayerPrefs.GetInt("day", 1);
        moveSpeedLvl = PlayerPrefs.GetInt("moveSpeedLvl", 0);
        studyCourseLvl = PlayerPrefs.GetInt("studyCourseLvl", 0);
        money = PlayerPrefs.GetInt("money", 0);

        shoes1Buyed = PlayerPrefs.GetInt("shoes1Buyed", 0) == 1 ? true : false;
        shoes2Buyed = PlayerPrefs.GetInt("shoes2Buyed", 0) == 1 ? true : false;
        shoes3Buyed = PlayerPrefs.GetInt("shoes3Buyed", 0) == 1 ? true : false;
        shoesEquip = PlayerPrefs.GetInt("shoesEquip", 0);

        magnetBuyed = PlayerPrefs.GetInt("magnetBuyed", 0) == 1 ? true : false;

        staminaBuff1Buyed = PlayerPrefs.GetInt("staminaBuff1Buyed", 0) == 1 ? true : false;
        staminaBuff2Buyed = PlayerPrefs.GetInt("staminaBuff2Buyed", 0) == 1 ? true : false;

        studyCourse1Buyed = PlayerPrefs.GetInt("studyCourse1Buyed", 0) == 1 ? true : false;
        studyCourse2Buyed = PlayerPrefs.GetInt("studyCourse2Buyed", 0) == 1 ? true : false;

        alreadyDisplay = PlayerPrefs.GetInt("alreadyDisplay", 0) == 1 ? true : false;

        //Check if it has key or not
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

        PlayerPrefs.SetInt("magnetBuyed", magnetBuyed ? 1 : 0);

        PlayerPrefs.SetInt("staminaBuff1Buyed", staminaBuff1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("staminaBuff2Buyed", staminaBuff2Buyed ? 1 : 0);

        PlayerPrefs.SetInt("studyCourse1Buyed", studyCourse1Buyed ? 1 : 0);
        PlayerPrefs.SetInt("studyCourse2Buyed", studyCourse2Buyed ? 1 : 0);

        PlayerPrefs.SetInt("alreadyDisplay", alreadyDisplay ? 1 : 0);

    }

    public void ResetGame()
    {
        PlayerPrefs.SetFloat("maxStamina", 100f);
        PlayerPrefs.SetFloat("stamina", 100f);
        PlayerPrefs.SetInt("day", 1);
        PlayerPrefs.SetInt("moveSpeedLvl", 0);
        PlayerPrefs.SetInt("studyCourseLvl", 0);
        PlayerPrefs.SetInt("money", 0);

        PlayerPrefs.SetInt("shoes1Buyed", 0);
        PlayerPrefs.SetInt("shoes2Buyed", 0);
        PlayerPrefs.SetInt("shoes3Buyed", 0);
        PlayerPrefs.SetInt("shoesEquip", 0);

        PlayerPrefs.SetInt("magnetBuyed", 0);

        PlayerPrefs.SetInt("staminaBuff1Buyed", 0);
        PlayerPrefs.SetInt("staminaBuff2Buyed", 0);

        PlayerPrefs.SetInt("studyCourse1Buyed", 0);
        PlayerPrefs.SetInt("studyCourse2Buyed", 0);

        PlayerPrefs.SetInt("alreadyDisplay", 0);
        
        PlayerPrefs.SetInt("isPayFirstBill", 0);
        PlayerPrefs.SetInt("isPaySecondBill", 0);
        PlayerPrefs.SetInt("isPayThirdBill", 0);
        PlayerPrefs.Save();
    }


    public float MaxStamina { get { return maxStamina; } set { maxStamina = value; } }
    public float Stamina { get { return stamina; } set { stamina = value; } }
    public int Day { get { return day; } set { day = value; } }
    public int MoveSpeedLvl { get { return moveSpeedLvl; } set { moveSpeedLvl = value; } }
    public int StudyCourseLvl { get { return studyCourseLvl; } set { studyCourseLvl = value; } }
    public int Money { get { return money; } set { money = value; } }
}
