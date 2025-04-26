using System.Collections;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public RectTransform phonePanel;
    public Vector2 hiddenPosition;
    public Vector2 visiblePosition;
    public float moveSpeed;
    public float visibleDuration;

    private bool isVisible;
    private Coroutine hideCoroutine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isVisible = true;

        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        hideCoroutine = StartCoroutine(HideAfterDelay());
    }

    private void Update()
    {
        MovePanel();
    }

    private void MovePanel()
    {
        var targetPosition = isVisible ? visiblePosition : hiddenPosition;
        phonePanel.anchoredPosition =
            Vector2.MoveTowards(phonePanel.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(visibleDuration);
        isVisible = false;
    }
}