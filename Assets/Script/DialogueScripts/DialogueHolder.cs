using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        public TutorialDialogueManager tutorialDialogueManager;
        public bool isTutorialDialogue = false;

        private void OnEnable()
        {
            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }

        private void Start(){
            if(isTutorialDialogue){
                tutorialDialogueManager.startTutorialDialogue();
            }
        }

        private void Update() {
            if (Input.GetKey(KeyCode.Escape)) {
                Deactive();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
                if(isTutorialDialogue){
                    tutorialDialogueManager.deactivateTutorialDialogue();
                }
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
            if(isTutorialDialogue){
                tutorialDialogueManager.deactivateTutorialDialogue();
            }
        }

        private void Deactive() {
            for (int i = 0; i < transform.childCount; i++) 
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        
    }
}

