using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class StoryDialogue : MonoBehaviour
{
    public TextMeshProUGUI textHolder;
    private IEnumerator lineAppear;
    AudioSource source;

    [Header ("Text Option")]
    [SerializeField] private string input;

    [Header ("Time Params")]
    [SerializeField] private float delay;

    [Header ("Sound")]
    [SerializeField] private AudioClip sound;
    

    private void Awake() {
        textHolder = GetComponent<TextMeshProUGUI>();
        textHolder.text = "";

        source = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        ResetLine();
        lineAppear = WriteText(input, textHolder, delay, sound);
        StartCoroutine(lineAppear);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (textHolder.text != input) {
                StopCoroutine(lineAppear);
                textHolder.text = input;
            }
        }
    }

    private void ResetLine() {
        textHolder = GetComponent<TextMeshProUGUI>();
        textHolder.text = "";
    }

    protected IEnumerator WriteText(string input, TextMeshProUGUI textHolder, float delay, AudioClip sound) {
        
        for (int i = 0; i < input.Length; i++) {
            textHolder.text += input[i];
            // SoundManager.instance.PlaySound(sound);
            // source = GetComponent<AudioSource>();
            // source.PlayOneShot(sound);
            source.PlayOneShot(sound);
            yield return new WaitForSecondsRealtime(delay);
        }

        yield return new WaitUntil(() => Input.GetMouseButton(0));
    }

    public void NextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenuForReal");
    }

    public void ToCreditScene()
    {
        SceneManager.LoadScene("Credit");
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
