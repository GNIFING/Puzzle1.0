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
        else
        {
            // Default case
        }

    }

    public void BuyStaminaBuff(int staminaNumber)
    {
        if(staminaNumber == 1)
        {
            gameController.staminaBuff1Buyed = true;
        }
        else if(staminaNumber == 2)
        {
            gameController.staminaBuff2Buyed = true;
        }
    }

    public void BuyMagnet()
    {
        
    }

    public void BuyStudyCourse(int studyCourseNumber)
    {

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
}
