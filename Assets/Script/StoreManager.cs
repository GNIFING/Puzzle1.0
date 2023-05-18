using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public GameController gameController;
    public List<GameObject> buyButton;
    public List<GameObject> equipButton;

    public TextMeshProUGUI moneyText;

    public void BuyShoes(int shoesNumber)
    {
        if (shoesNumber == 1 && gameController.Money >= 10)
        {
            PayMoney(10);
            moneyText.text = gameController.Money.ToString();
            gameController.shoes1Buyed = true;
            PlayerPrefs.SetInt("shoes1Buyed", 1);
            buyButton[0].SetActive(false);
            EquipShoes(1);
        }
        else if (shoesNumber == 2 && gameController.Money >= 20)
        {
            PayMoney(20);
            moneyText.text = gameController.Money.ToString();
            gameController.shoes2Buyed = true;
            PlayerPrefs.SetInt("shoes2Buyed", 1);
            buyButton[1].SetActive(false);
            EquipShoes(2);
        }
        else if (shoesNumber == 3 && gameController.Money >= 30)
        {
            PayMoney(30);
            moneyText.text = gameController.Money.ToString();
            gameController.shoes3Buyed = true;
            PlayerPrefs.SetInt("shoes3Buyed", 1);
            buyButton[2].SetActive(false);
            EquipShoes(3);
        }
    }

    public void EquipShoes(int shoesNumber)
    {
        switch (shoesNumber)
        {
            case 1:
                gameController.shoesEquip = 1;
                gameController.MoveSpeedLvl = 1;
                PlayerPrefs.SetInt("shoesEquip", 1);
                PlayerPrefs.SetInt("moveSpeedLvl", 1);
                equipButton[0].SetActive(false);
                equipButton[1].SetActive(true);
                equipButton[2].SetActive(true);
                break;
            case 2:
                gameController.shoesEquip = 2;
                gameController.MoveSpeedLvl = 2;
                PlayerPrefs.SetInt("shoesEquip", 2);
                PlayerPrefs.SetInt("moveSpeedLvl", 2);
                equipButton[0].SetActive(true);
                equipButton[1].SetActive(false);
                equipButton[2].SetActive(true);
                break;
            case 3:
                gameController.shoesEquip = 3;
                gameController.MoveSpeedLvl = 3;
                PlayerPrefs.SetInt("shoesEquip", 3);
                PlayerPrefs.SetInt("moveSpeedLvl", 3);
                equipButton[0].SetActive(true);
                equipButton[1].SetActive(true);
                equipButton[2].SetActive(false);

                break;
            default:
                break;
        }
    }

    public void UnEquipShoes(int shoesNumber)
    {
        gameController.shoesEquip = 0;
        equipButton[shoesNumber - 1].SetActive(true);
    }

    public void BuyMagnet()
    {
        if(gameController.Money >= 50)
        {
            PayMoney(50);
            moneyText.text = gameController.Money.ToString();
            gameController.magnetBuyed = true;
            PlayerPrefs.SetInt("magnetBuyed", 1);
            buyButton[3].SetActive(false);
        }
    }

    public void EquipMagnet(int equip)
    {
        //equip = 1, unequip = 0; 
        if(equip == 0)
        {
            equipButton[3].SetActive(true);
        }
        if (equip == 1)
        {
            equipButton[3].SetActive(false);
        }
    }

    public void BuyStaminaBuff(int staminaNumber)
    {
        if (staminaNumber == 1 && gameController.Money >= 25)
        {
            PayMoney(25);
            buyButton[4].SetActive(false);
            gameController.staminaBuff1Buyed = true;
            PlayerPrefs.SetInt("staminaBuff1Buyed", 1);
            
            if(PlayerPrefs.GetInt("staminaBuff2Buyed") == 1)
            {
                PlayerPrefs.SetFloat("maxStamina", 175);
                PlayerPrefs.SetFloat("stamina", 175);
                gameController.MaxStamina = 175;
                gameController.Stamina = 175;
            }
            else
            {
                PlayerPrefs.SetFloat("maxStamina", 125);
                PlayerPrefs.SetFloat("stamina", 125);
                gameController.MaxStamina = 125;
                gameController.Stamina = 125;
            }

        }
        else if (staminaNumber == 2 && gameController.Money >= 50)
        {
            PayMoney(50);
            buyButton[5].SetActive(false);
            gameController.staminaBuff2Buyed = true;
            PlayerPrefs.SetInt("staminaBuff2Buyed", 1);

            if (PlayerPrefs.GetInt("staminaBuff1Buyed") == 1)
            {
                PlayerPrefs.SetFloat("maxStamina", 175);
                PlayerPrefs.SetFloat("stamina", 175);
                gameController.MaxStamina = 175;
                gameController.Stamina = 175;
            }
            else
            {
                PlayerPrefs.SetFloat("maxStamina", 150);
                PlayerPrefs.SetFloat("stamina", 150);
                gameController.MaxStamina = 150;
                gameController.Stamina = 150;
            }
        }
        moneyText.text = gameController.Money.ToString();
    }

    public void BuyStudyCourse(int studyCourseNumber)
    {
        if (studyCourseNumber == 1 && gameController.Money >= 50)
        {
            PayMoney(50);
            buyButton[6].SetActive(false);
            gameController.studyCourse1Buyed = true;
            if (gameController.studyCourse2Buyed)
            {
                gameController.StudyCourseLvl = 2;
            }
            else
            {
                gameController.StudyCourseLvl = 1;
            }
            PlayerPrefs.SetInt("studyCourse1Buyed", 1);
        }
        else if (studyCourseNumber == 2 && gameController.Money >= 100)
        {
            PayMoney(100);
            buyButton[7].SetActive(false);
            gameController.studyCourse2Buyed = true;
            gameController.StudyCourseLvl = 2;
            PlayerPrefs.SetInt("studyCourse2Buyed", 1);
        }
        moneyText.text = gameController.Money.ToString();
    }

    public void PayMoney(int money)
    {
        gameController.Money -= money;
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - money);
    }

    public void UpdateStoreButton()
    {
        if (gameController.shoes1Buyed)
        {
            buyButton[0].SetActive(false);
        }
        if (gameController.shoes2Buyed  )
        {
            buyButton[1].SetActive(false);
            Debug.Log("Shoes2Buyed");
        }
        if (gameController.shoes3Buyed)
        {
            buyButton[2].SetActive(false);
        }

        EquipShoes(gameController.shoesEquip);

        if (gameController.magnetBuyed)
        {
            buyButton[3].SetActive(false);
        }
        if (gameController.staminaBuff1Buyed)
        {
            buyButton[4].SetActive(false);
        }
        if (gameController.staminaBuff2Buyed)
        {
            buyButton[5].SetActive(false);
        }
        if (gameController.studyCourse1Buyed)
        {
            buyButton[6].SetActive(false);
        }
        if (gameController.studyCourse2Buyed)
        {
            buyButton[7].SetActive(false);
        }

    }

}
