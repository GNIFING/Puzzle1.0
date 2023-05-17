using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogueManager : MonoBehaviour
{
    public GameObject tutorialDialogue;
    public int level;

    public void startTutorialDialogue(){
        string keyName = "level_" + level + "_tutorial_played";

        // if this tutorial has been played before, we will not replay it.
        if (PlayerPrefs.HasKey(keyName) && PlayerPrefs.GetInt(keyName) == 1){
            tutorialDialogue.SetActive(false);
            return;
        }

        PlayerPrefs.SetInt("level_" + level + "_tutorial_played", 1);
        StartCoroutine(delayForSomeTime());
    }

    IEnumerator delayForSomeTime(){
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 0;
    }

    public void deactivateTutorialDialogue(){
        tutorialDialogue.SetActive(false);
        Time.timeScale = 1;
    }
}
