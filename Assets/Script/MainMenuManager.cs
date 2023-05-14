using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void MainGame() {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() {
        Debug.Log("Quit!!!!");
        Application.Quit();
    }
}