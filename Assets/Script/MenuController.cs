using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject home;
    [SerializeField]
    private GameObject hospital;
    [SerializeField]
    private GameObject bank;
    [SerializeField]
    private GameController gameController;
    
    public TextMeshProUGUI money;


    public void Start()
    {
        money.text = gameController.Money.ToString();
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
    }

    public void EnterHome()
    {
        home.SetActive(true);
    }

    public void EnterHospital()
    {
        hospital.SetActive(true);
    }

    public void EnterBank()
    {
        bank.SetActive(true);
    }

    public void ExitHome()
    {
        home.SetActive(false);
    }

    public void ExitHospital()
    {
        hospital.SetActive(false);
    }

    public void ExitBank()
    {
        bank.SetActive(false);
    }
}
