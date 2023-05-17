using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject home;
    [SerializeField]
    private GameObject hospital;
    [SerializeField]
    private GameObject store;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject dialogueHolder;
    private int day;

    public TextMeshProUGUI money;


    public void Start()
    {
        money.text = gameController.Money.ToString();
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene("Level1");
    }

    public void EnterHome()
    {
        home.GetComponent<HomeManager>().UpdateHome();
        home.SetActive(true);
    }

    public void EnterHospital()
    {
        hospital.GetComponent<HospitalManager>().UpdateHospital();
        hospital.SetActive(true);
    }

    public void EnterStore()
    {
        store.SetActive(true);
    }

    public void ExitHome()
    {
        home.SetActive(false);
    }

    public void ExitHospital()
    {
        hospital.SetActive(false);
    }

    public void ExitStore()
    {
        store.SetActive(false);
    }

    public void Summary()
    {
        Debug.Log("Summary!");
        SceneManager.LoadScene("Summary");
    }

    public void Suicide()
    {
        Debug.Log("Game over!");
        SceneManager.LoadScene("GameOver");
    }

    // public void NextDay () {
    //     day = PlayerPrefs.GetInt("day", 1);
    //     Debug.Log(day);
    //     if (day == 4) {
    //         SceneManager.LoadScene("DialogueTest");
    //     }
    // }
}
