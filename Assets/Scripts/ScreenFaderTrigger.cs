using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1f;
    public float visibleDuration = 1f; // сколько держать затемнение
    private Coroutine fadeCoroutine;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // затемняем до 1
        yield return StartCoroutine(FadeToAlpha(1f));

        // держим затемнение visibleDuration секунд
        yield return new WaitForSeconds(visibleDuration);

        // убираем затемнение до 0
        yield return StartCoroutine(FadeToAlpha(0f));
    }

    private IEnumerator FadeToAlpha(float targetAlpha)
    {
        Color color = fadeImage.color;
        while (!Mathf.Approximately(color.a, targetAlpha))
        {
            color.a = Mathf.MoveTowards(color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeImage.color = color;
            yield return null;
        }
    }
}