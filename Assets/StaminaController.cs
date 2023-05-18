using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaminaController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private float staminaFromSave;

    public TextMeshProUGUI staminaText;
    //private float maxStaminaFromSave;
    private void Awake()
    {
        //staminaFromSave = 200f;
        //maxStaminaFromSave = 200f;
        staminaFromSave = PlayerPrefs.GetFloat("stamina", 100);
        //maxStaminaFromSave = PlayerPrefs.GetFloat("maxStamina", 100);

        Debug.Log("staminaFromSave = " + staminaFromSave);
        //Debug.Log("maxStaminaFromSave = " + maxStaminaFromSave);
        playerMovement.SetMaxStamina(staminaFromSave);
        playerMovement.SetStamina(staminaFromSave);
    }

    private void Update()
    {
        staminaText.text = ((int)playerMovement.stamina).ToString();
    }
}
