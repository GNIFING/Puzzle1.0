using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void MainGame() {
        SceneManager.LoadScene("StoryDialogue");
        clearGameData();
        clearInGameState();
    }

    public void QuitGame() {
        Debug.Log("Quit!!!!");
        Application.Quit();
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
}