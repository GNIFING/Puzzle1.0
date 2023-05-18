using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DaysDisplayGen : MonoBehaviour
{
    public string word;
    public float fadeInDuration = 1f;
    public float freezeDuration = 1f;
    public float fadeOutDuration = 2f;

    private Image blackBackground;
    private TextMeshProUGUI textComponent;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        Transform childTransform = transform.Find("Text");
        startTime = Time.time;
        textComponent = childTransform.GetComponent<TextMeshProUGUI>();
        textComponent.text = word;

        blackBackground = GetComponent<Image>();

        StartCoroutine(FadeInFreezeAndFadeOut());
    }

    private IEnumerator FadeInFreezeAndFadeOut()
    {
        yield return FadeIn(textComponent, fadeInDuration);
        yield return new WaitForSeconds(freezeDuration);
        yield return FadeOut(blackBackground,textComponent, fadeOutDuration);

        Destroy(gameObject);
    }

    private IEnumerator FadeIn(Graphic graphic, float duration)
    {
        float elapsedTime = 0f;
        Color originalColor = graphic.color;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0f, originalColor.a, elapsedTime / duration);
            SetAlpha(graphic, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetAlpha(graphic, originalColor.a);
    }

    private IEnumerator FadeOut(Graphic blackBackground,Graphic textComponent, float duration)
    {
        float elapsedTime = 0f;
        Color originalColorA = blackBackground.color;
        Color originalColorB = textComponent.color;

        while (elapsedTime < duration)
        {
            float alphaA = Mathf.Lerp(originalColorA.a, 0f, elapsedTime / duration);
            SetAlpha(blackBackground, alphaA);
            float alphaB = Mathf.Lerp(originalColorB.a, 0f, elapsedTime / duration);
            SetAlpha(textComponent, alphaB);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetAlpha(blackBackground, 0f);
        SetAlpha(textComponent, 0f);
    }

    private void SetAlpha(Graphic graphic, float alpha)
    {
        Color color = graphic.color;
        color.a = alpha;
        graphic.color = color;
    }
}