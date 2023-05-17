using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;

        private void OnEnable()
        {
            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }

        private void Update() {
            if (Input.GetKey(KeyCode.Escape)) {
                Deactive();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
            }
        }

        private IEnumerator dialogueSequence() 
        {
            for (int i = 0; i < transform.childCount; i++) 
            {
                Deactive();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainMenu");
        }

        private void Deactive() {
            for (int i = 0; i < transform.childCount; i++) 
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        
    }
}

