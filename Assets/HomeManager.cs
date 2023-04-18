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
        //should use list when stable
        if(billPriceEachday[day] > 0)
        {
            billNameText.text = "Chao Nee" + day;
            billPrice.text = "Pay " + billPriceEachday[gameController.Day] + " Baht";
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
        if (gameController.Money >= billPriceEachday[gameController.Day])
        {
            gameController.Money -= billPriceEachday[gameController.Day];
            billPriceEachday[gameController.Day] = -1;
            UpdateHome();
            billButton.SetActive(false);
        }
    }
}
