using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
// using GameController;

public class GameOverController : GameController
{
    public static bool gameHasEnd = false;
    [SerializeField] private TextMeshProUGUI textHolder;

    private void OnEnable() {
        day = PlayerPrefs.GetInt("day", 1);
        textHolder.text = "Day Survive: " + day.ToString();
    }

    public void Back() {
        SceneManager.LoadScene("MainMenuForReal");
        ResetGame();
    }

}
