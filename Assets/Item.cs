using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int price;
    public bool isAlreadyBuy;
    public bool isEquip;

    public void BuyItem()
    {
        isAlreadyBuy = true;
    }

    public void EquipItem()
    {
        isEquip = true;
    }

    public void UnEquipItem()
    {
        isEquip = false;
    }

    public int GetItemPrice()
    {
        return price;
    }
}
