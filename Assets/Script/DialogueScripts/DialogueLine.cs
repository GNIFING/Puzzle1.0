using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DialogueSystem 
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;
        private IEnumerator lineAppear;
        private TextMeshProUGUI nameHolder;

        [Header ("Text Option")]
        [SerializeField] private string input;
        [SerializeField] private Color32 color;
        [SerializeField] private TMP_FontAsset font;

        [Header ("Time Params")]
        [SerializeField] private float delay;

        [Header ("Sound")]
        [SerializeField] private AudioClip sound;

        [Header ("Character Name")]
        [SerializeField] private string charName;

        [Header ("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;
        

        private void Awake() {
            textHolder = GetComponent<TextMeshProUGUI>(); 
            textHolder.text = "";

            nameHolder = transform.Find("CharacterNameHolder/Name").GetComponent<TextMeshProUGUI>();
            nameHolder.text = "";
            Debug.Log(nameHolder);

            imageHolder.sprite = characterSprite;
        }
        
        private void OnEnable() {
            ResetLine();
            lineAppear = WriteText(input, textHolder, color, font, delay, sound, charName, nameHolder);
            StartCoroutine(lineAppear);
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                if (textHolder.text != input) {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;
                }
                else {
                    finished = true;
                }
            }
        }

        private void ResetLine() {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";
            nameHolder = transform.Find("CharacterNameHolder/Name").GetComponent<TextMeshProUGUI>();
            nameHolder.text = "";
            finished = false;
        }
    }

    
}

