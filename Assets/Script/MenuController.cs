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
        if(PlayerPrefs.GetInt("day") == 3 && PlayerPrefs.GetInt("isPayFirstBill") == 0)
        {
            SceneManager.LoadScene("GameOverDialogue");
            Debug.Log("Test");
        }
        else if(PlayerPrefs.GetInt("day") == 6 && PlayerPrefs.GetInt("isPaySecondBill") == 0)
        {
            SceneManager.LoadScene("GameOverDialogue");
        }
        else if (PlayerPrefs.GetInt("day") == 10 && PlayerPrefs.GetInt("isPayThirdBill") == 0)
        {
            SceneManager.LoadScene("GameOverDialogue");
        }

        else
        {
            Debug.Log("Play Game");
            clearInGameState();

            string[] scenesAvailable = new string[]{"Level1", "Level1_2"};
            int rdnInt = Random.Range(0, scenesAvailable.Length);
            string randomScene = scenesAvailable[rdnInt];
            Debug.Log(randomScene);

            SceneManager.LoadScene(randomScene);
        }
        //PlayerPrefs.SetFloat("maxStamina", 100);
        //PlayerPrefs.SetFloat("stamina", 100);
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
        store.GetComponent<StoreManager>().UpdateStoreButton();
        store.SetActive(true);
    }

    public void ExitHome()
    {
        home.GetComponent<HomeManager>().ExitHome();
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
        clearInGameState();
        clearGameData();
        SceneManager.LoadScene("GameOver");
    }

    private void clearInGameState()
    {
        PlayerPrefs.DeleteKey("inGameStamina");
        PlayerPrefs.DeleteKey("inGameScore");
        PlayerPrefs.DeleteKey("inGameJunkLossed");
        PlayerPrefs.DeleteKey("inGameLastLevel");
        PlayerPrefs.DeleteKey("Level1_isVisited");
        PlayerPrefs.DeleteKey("Level2_isVisited");
        PlayerPrefs.DeleteKey("Level3_isVisited");
        PlayerPrefs.DeleteKey("Level4_isVisited");
        PlayerPrefs.DeleteKey("Level1_2_isVisited");
        PlayerPrefs.DeleteKey("Level1_3_isVisited");
        PlayerPrefs.DeleteKey("Level2_2_isVisited");
        PlayerPrefs.DeleteKey("Level2_3_isVisited");
        PlayerPrefs.DeleteKey("Level3_2_isVisited");
        PlayerPrefs.DeleteKey("Level3_3_isVisited");
    }

    private void clearGameData()
    {
        PlayerPrefs.DeleteKey("level_0_tutorial_played");
        PlayerPrefs.DeleteKey("level_1_tutorial_played");
        PlayerPrefs.DeleteKey("level_2_tutorial_played");
        PlayerPrefs.DeleteKey("level_3_tutorial_played");
        PlayerPrefs.DeleteKey("level_4_tutorial_played");
        PlayerPrefs.DeleteKey("specialItemFound");
    }

    // public void NextDay () {
    //     day = PlayerPrefs.GetInt("day", 1);
    //     Debug.Log(day);
    //     if (day == 4) {
    //         SceneManager.LoadScene("DialogueTest");
    //     }
    // }
}
