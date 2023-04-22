using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem 
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;

        [Header ("Text Option")]
        [SerializeField] private string input;
        [SerializeField] private Color32 color;
        [SerializeField] private TMP_FontAsset font;

        [Header ("Time Params")]
        [SerializeField] private float delay;

        [Header ("Sound")]
        [SerializeField] private AudioClip sound;

        private void Awake() {
            textHolder = GetComponent<TextMeshProUGUI>();

            StartCoroutine(WriteText(input, textHolder, color, font, delay, sound));
        }
    }
}

