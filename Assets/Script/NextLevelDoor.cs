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
        } else {
            PlayerPrefs.SetFloat("inGameStamina", stamina);
            PlayerPrefs.SetInt("inGameScore", score);
            PlayerPrefs.SetInt("inGameLastLevel", SceneManager.GetActiveScene().buildIndex );
        }

        transition.SetTrigger("FadeStart");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneToLoad);
    }
}
