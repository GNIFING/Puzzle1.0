using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryReportController : MonoBehaviour
{
    // these static value can be change from any classes from any scene
    public static int junkCollected = 0;
    public static int staminaUsed = 0;
    public static int junkLoss = 0;
    public static int totalIncome = 0;
    // private int minFontSize = 80;

    void OnEnable()
    {
        LoadSummary();
        Debug.Log("LoadSummary is called");
    }

    // change the display in report summary according to the parameters that we have
    public void LoadSummary() {
        var reportInfoDisplay = GameObject.Find("ReportInfoDisplay").gameObject.transform;
        reportInfoDisplay.GetChild(0).GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>().text = junkCollected.ToString();
        reportInfoDisplay.GetChild(1).GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>().text = staminaUsed.ToString();
        reportInfoDisplay.GetChild(2).GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>().text = junkLoss.ToString();
        reportInfoDisplay.GetChild(3).GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>().text = totalIncome.ToString();
    } 

    // call this function to reset parameters as we can see in the bracket
    public void ResetSummary() {
        junkCollected = 0;
        staminaUsed = 0;
        junkLoss = 0;
        totalIncome = 0;
    }

    // if developer doesn't want to assign each params, u can call this function instead (but why?)
    public void AssignVariable(int junkCol, int stamUsed, int junkL, int income) {
        junkCollected = junkCol;
        staminaUsed = stamUsed;
        junkLoss = junkL;
        totalIncome = income;
    }

    public void LoadMainMenu() {
        Debug.Log("This is Mainmenu");
        SceneManager.LoadScene("MainGame");
    }
}
