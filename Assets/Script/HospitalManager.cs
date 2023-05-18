using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HospitalManager : MonoBehaviour
{
    public TextMeshProUGUI maxStaminaText;
    public TextMeshProUGUI staminaText;

    public TextMeshProUGUI healText;

    public TextMeshProUGUI moneyMenuText;
    public GameController gameController;

    private int healCost = 10;

    public void UpdateHospital()
    {
        maxStaminaText.text = gameController.MaxStamina.ToString();
        staminaText.text = gameController.Stamina.ToString();

        if(gameController.MaxStamina > gameController.Stamina)
        {
            healText.text = "Heal Cost : 10 ";
        }
        else
        {
            healText.text = "Your stamina is full";
        }
    }
    public void Heal()
    {
        if (gameController.MaxStamina > gameController.Stamina && gameController.Money >= healCost)
        {
            gameController.Stamina = gameController.MaxStamina;
            gameController.Money -= healCost;

            float maxStamina = PlayerPrefs.GetFloat("maxStamina");
            PlayerPrefs.SetFloat("stamina", maxStamina);
            int money = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money - healCost);

            moneyMenuText.text = gameController.Money.ToString();
            healText.text = "Your stamina is full";
            UpdateHospital();
        }
        else if(gameController.MaxStamina > gameController.Stamina && gameController.Money < healCost)
        {
            healText.text = "Not Enough money";
        }
    }
}
