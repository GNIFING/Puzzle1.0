using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished {get; protected set;}

        protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, Color32 textColor, TMP_FontAsset textFont, float delay, AudioClip sound, string charName, TextMeshProUGUI nameHolder) {
            finished = false;
            textHolder.color = textColor;
            textHolder.font = textFont;

            nameHolder.color = textColor;
            nameHolder.font = textFont;
            nameHolder.text = charName;
            
            for (int i = 0; i < input.Length; i++) {
                textHolder.text += input[i];
                Debug.Log(sound);
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSecondsRealtime(delay);
            }

            yield return new WaitUntil(() => Input.GetMouseButton(0));
            finished = true;
        }
    }
} 
