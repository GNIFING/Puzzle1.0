using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public List<Item> items;
    public GameController gameController;

    public void BuyItem(int itemNumber)
    {
        if(gameController.Money >= items[itemNumber].GetItemPrice())
        {
            items[itemNumber].BuyItem();
            EquipItem(itemNumber);
            UnEquipAllShoesExcept(itemNumber);
        }
    }

    public void EquipItem(int itemNumber)
    {
        items[itemNumber].EquipItem();
    }

    public void UnEquipAllShoesExcept(int itemNumber)
    {

    }
}
