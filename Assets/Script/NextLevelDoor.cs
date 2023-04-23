using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelDoor : MonoBehaviour
{
    public string sceneToLoad;
    public Animator transition;
    public float transitionTime = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float stamina = collision.gameObject.GetComponent<PlayerMovement>().getStamina();
            int score = collision.gameObject.GetComponent<PlayerMovement>().getScore();
            StartCoroutine(LoadLevel(stamina, score));
        }
    }

    IEnumerator LoadLevel(float stamina, int score)
    {
        if(sceneToLoad == "MainGame"){
            PlayerPrefs.DeleteKey("inGameStamina");
            PlayerPrefs.DeleteKey("inGameScore");
            PlayerPrefs.DeleteKey("inGameLastLevel");
            PlayerPrefs.DeleteKey("Level1_isVisited");
            PlayerPrefs.DeleteKey("Level2_isVisited");
            PlayerPrefs.DeleteKey("Level3_isVisited");
        } else {
            PlayerPrefs.SetFloat("inGameStamina", stamina);
            PlayerPrefs.SetInt("inGameScore", score);

            Scene thisScene = SceneManager.GetActiveScene();
            int thisSceneIndex = thisScene.buildIndex;
            string thisSceneName = thisScene.name;
            PlayerPrefs.SetInt("inGameLastLevel", thisSceneIndex);
            PlayerPrefs.SetInt(thisSceneName + "_isVisited", 1);
        }

        transition.SetTrigger("FadeStart");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneToLoad);
    }
}
