using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    public string[] scenesAvailable;
    public Animator transition;
    public float transitionTime = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float maxStamina = collision.gameObject.GetComponent<PlayerMovement>().getMaxStamina();
            float stamina = collision.gameObject.GetComponent<PlayerMovement>().getStamina();
            int usedStamina = collision.gameObject.GetComponent<PlayerMovement>().getUsedStamina();
            int score = collision.gameObject.GetComponent<PlayerMovement>().getScore();
            int junkLossed = collision.gameObject.GetComponent<PlayerMovement>().getJunkLossed();
            StartCoroutine(LoadLevel(maxStamina, stamina, usedStamina, score, junkLossed));
        }
    }

    IEnumerator LoadLevel(float maxStamina, float stamina, int usedStamina, int score, int junkLossed)
    {
        int rdnInt = Random.Range (0, scenesAvailable.Length);
        Debug.Log(rdnInt);
        string randomScene = scenesAvailable[rdnInt];

        if(randomScene == "Summary"){
            PlayerPrefs.DeleteKey("inGameMaxStamina");
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

            GameObject[] allTrashes = GameObject.FindGameObjectsWithTag("Trash");
            foreach (GameObject trashManager in allTrashes)
            {
                Destroy(trashManager);
            }

            SummaryReportController.AssignVariable(score, usedStamina, junkLossed, score*1);

        } else {
            PlayerPrefs.SetFloat("inGameMaxStamina", maxStamina);
            PlayerPrefs.SetFloat("inGameStamina", stamina);
            PlayerPrefs.SetInt("inGameScore", score);
            PlayerPrefs.SetInt("inGameJunkLossed", junkLossed);

            Scene thisScene = SceneManager.GetActiveScene();
            int thisSceneIndex = thisScene.buildIndex;
            string thisSceneName = thisScene.name;
            PlayerPrefs.SetInt("inGameLastLevel", thisSceneIndex);
            PlayerPrefs.SetInt(thisSceneName + "_isVisited", 1);
        }

        transition.SetTrigger("FadeStart");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(randomScene);
        Debug.Log(randomScene);
    }
}
