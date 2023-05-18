using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject billButton;
    public List<int> billPriceEachday;

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
 
        CheckBillDate(gameController.Day);
    }

    public void CheckBillDate(int day)
    {
        PriceScale(day, gameController.Money);
        //should use list when stable
        if (billPriceEachday[day] > 0)
        {
            billNameText.text = "Chao Nee" + day;
            billPrice.text = "Pay " + (int)(billPriceEachday[gameController.Day] * scale) + " Baht";
            billButton.SetActive(true);
        }
        else if(billPriceEachday[day] == 0)
        {
            billNameText.text = "No Bill Today!";
            billButton.SetActive(false);
        }
        else
        {
            billNameText.text = "Thank you!";
        }
    }

    public void PayBill()
    {
        if (gameController.Money >= (int)(billPriceEachday[gameController.Day] * scale))
        {
            gameController.Money -= (int)(billPriceEachday[gameController.Day] * scale);
            int saveMoney = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", saveMoney - (int)(billPriceEachday[gameController.Day] * scale));
            billPriceEachday[gameController.Day] = -1;
            UpdateHome();
            billButton.SetActive(false);
        }
    }

    public void PriceScale(int day, int money)
    {
        float moneyScale = 1f;
        if(billPriceEachday[gameController.Day] != 0)
        {
            moneyScale = money / billPriceEachday[gameController.Day];
        }

        if (day >= 7 && money >= billPriceEachday[gameController.Day] * 1.8f) 
        {
            scale = moneyScale * 0.66f;
        }
        else if (day >= 7 && money >= billPriceEachday[gameController.Day] * 1.4f)
        {
            scale = moneyScale * 0.66f;
        }
        else if (day >= 7)
        {
            scale = moneyScale * 0.7f;
        }
        else if(day >= 4 && money >= billPriceEachday[gameController.Day] * 2)
        {
            scale = 1.6f;
        }
        else if (day >= 4 && money >= billPriceEachday[gameController.Day] * 1.5f)
        {
            scale = 1.3f;
        }
        else
        {
            scale = 1f;
        }
    }
}
