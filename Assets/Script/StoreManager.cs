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
            gameController.Money -= 10;
            moneyText.text = gameController.Money.ToString();
            gameController.shoes1Buyed = true;
            buyButton[0].SetActive(false);
            EquipShoes(1);
        }
        else if (shoesNumber == 2 && gameController.Money >= 20)
        {
            gameController.Money -= 20;
            moneyText.text = gameController.Money.ToString();
            gameController.shoes2Buyed = true;
            buyButton[1].SetActive(false);
            EquipShoes(2);
        }
        else if (shoesNumber == 3 && gameController.Money >= 30)
        {
            gameController.Money -= 30;
            moneyText.text = gameController.Money.ToString();
            gameController.shoes3Buyed = true;
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
                equipButton[0].SetActive(false);
                equipButton[1].SetActive(true);
                equipButton[2].SetActive(true);
                break;
            case 2:
                gameController.shoesEquip = 2;
                equipButton[0].SetActive(true);
                equipButton[1].SetActive(false);
                equipButton[2].SetActive(true);
                break;
            case 3:
                gameController.shoesEquip = 3;
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
            gameController.Money -= 50;
            moneyText.text = gameController.Money.ToString();
            gameController.magnetBuyed = true;
            buyButton[3].SetActive(false);
        }
    }

    public void EquipMagnet(int equip)
    {
        //equip = 1, unequip = 0; 
        if(equip == 0)
        {
            gameController.magnetEquip = 1;
            equipButton[3].SetActive(true);
        }
        if (equip == 1)
        {
            gameController.magnetEquip = 0;
            equipButton[3].SetActive(false);
        }
    }

    public void BuyStaminaBuff(int staminaNumber)
    {
        if (staminaNumber == 1 && gameController.Money >= 25)
        {
            gameController.Money -= 25;
            buyButton[4].SetActive(false);
            gameController.staminaBuff1Buyed = true;
        }
        else if (staminaNumber == 2 && gameController.Money >= 50)
        {
            gameController.Money -= 50;
            buyButton[5].SetActive(false);
            gameController.staminaBuff2Buyed = true;
        }
        moneyText.text = gameController.Money.ToString();
    }

    public void BuyStudyCourse(int studyCourseNumber)
    {
        if (studyCourseNumber == 1 && gameController.Money >= 50)
        {
            gameController.Money -= 50;
            buyButton[6].SetActive(false);
            gameController.studyCourse1Buyed = true;
        }
        else if (studyCourseNumber == 2 && gameController.Money >= 100)
        {
            gameController.Money -= 100;
            buyButton[7].SetActive(false);
            gameController.studyCourse2Buyed = true;
        }
        moneyText.text = gameController.Money.ToString();
    }


}
