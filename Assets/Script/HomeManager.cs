using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI maxStaminaText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI moveSpeedText;
    public TextMeshProUGUI studyLevelText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyMenuText;

    public TextMeshProUGUI billNameText;
    public TextMeshProUGUI billPrice;
    public TextMeshProUGUI moneyInMenuText;
    public GameObject thankYouText;
    public GameObject billButton;
    public GameObject payObject;
    public List<int> billPriceEachDay;


    public bool isPayFirstBill;
    public bool isPaySecondBill;
    public bool isPayThirdBill;

    public GameController gameController;

    private float scale = 1;
    public void UpdateHome()
    {
        dayText.text = "Day : " + gameController.Day;
        maxStaminaText.text = "Max Stamina : " + gameController.MaxStamina;
        staminaText.text = "Stamina : " + gameController.Stamina;
        moveSpeedText.text = "Move Speed : " + gameController.MoveSpeedLvl;
        studyLevelText.text = "Study Level : " + gameController.StudyCourseLvl;
        moneyText.text = "Money : " + gameController.Money;
        moneyMenuText.text = gameController.Money.ToString();

        isPayFirstBill = PlayerPrefs.GetInt("isPayFirstBill", 0) == 1 ? true : false;
        isPaySecondBill = PlayerPrefs.GetInt("isPaySecondBill", 0) == 1 ? true : false;
        isPayThirdBill = PlayerPrefs.GetInt("isPayThirdBill", 0) == 1 ? true : false;

        CheckBillDate(gameController.Day);
    }

    public void CheckBillDate(int day)
    {
        if (!isPayFirstBill)
        {
            int remainingDay = 3 - day;
            ShowDueDate(remainingDay, 1);
            billPrice.text = 30.ToString();
        }
        else if (!isPaySecondBill)
        {
            int remainingDay = 6 - day;
            ShowDueDate(remainingDay, 2);
            billPrice.text = 60.ToString();
        }
        else if (!isPayThirdBill)
        {
            int remainingDay = 10 - day;
            ShowDueDate(remainingDay, 3);
            billPrice.text = 100.ToString();
        }
    }

    public void ShowDueDate(int remainingDay, int billNo)
    {
        if(remainingDay == 1)
        {
            billNameText.text = "Bill NO." + billNo + " is due in 1 day";
        }
        else if(remainingDay == 0)
        {
            billNameText.text = "Bill NO." + billNo + " is due TODAY!";
        }
        else
        {
            billNameText.text = "Bill NO." + billNo + "  is due in " + remainingDay + " days";
        }
    }
    public void PayBill()
    {
        if (!isPayFirstBill && gameController.Money >= billPriceEachDay[0])
        {
            isPayFirstBill = true;
            PlayerPrefs.SetInt("isPayFirstBill", 1);

            payObject.SetActive(false);
            thankYouText.SetActive(true);

            int saveMoney = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", saveMoney - 30);
            gameController.Money -= 30;

            moneyText.text = "Money : " + gameController.Money.ToString();
            moneyInMenuText.text = gameController.Money.ToString();
        }
        else if (!isPaySecondBill && gameController.Money >= billPriceEachDay[1])
        {
            isPaySecondBill = true;
            PlayerPrefs.SetInt("isPaySecondBill", 1);
            billPrice.text = 60.ToString();

            payObject.SetActive(false);
            thankYouText.SetActive(true);

            int saveMoney = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", saveMoney - 60);
            gameController.Money -= 60;

            moneyText.text = "Money : " + gameController.Money.ToString();
            moneyInMenuText.text = gameController.Money.ToString();
        }
        else if (!isPayThirdBill && gameController.Money >= billPriceEachDay[2])
        {
            isPayThirdBill = true;
            PlayerPrefs.SetInt("isPayThirdBill", 1);
            billPrice.text = 100.ToString();

            payObject.SetActive(false);
            thankYouText.SetActive(true);

            int saveMoney = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", saveMoney - 100);
            gameController.Money -= 100;

            moneyText.text = "Money : " + gameController.Money.ToString();
            moneyInMenuText.text = gameController.Money.ToString();

            SceneManager.LoadScene("EndingDialogue");
            //Win Game Here
        }

    }

    public void PriceScale(int day, int money)
    {
        float moneyScale = 1f;
        if(billPriceEachDay[gameController.Day] != 0)
        {
            moneyScale = money / billPriceEachDay[gameController.Day];
        }

        if (day >= 7 && money >= billPriceEachDay[gameController.Day] * 1.8f) 
        {
            scale = moneyScale * 0.66f;
        }
        else if (day >= 7 && money >= billPriceEachDay[gameController.Day] * 1.4f)
        {
            scale = moneyScale * 0.66f;
        }
        else if (day >= 7)
        {
            scale = moneyScale * 0.7f;
        }
        else if(day >= 4 && money >= billPriceEachDay[gameController.Day] * 2)
        {
            scale = 1.6f;
        }
        else if (day >= 4 && money >= billPriceEachDay[gameController.Day] * 1.5f)
        {
            scale = 1.3f;
        }
        else
        {
            scale = 1f;
        }
    }

    public void ExitHome()
    {
        payObject.SetActive(true);
        thankYouText.SetActive(false);
    }
}
