using System.Collections;
using UnityEngine;
using TMPro;

public class PhoneController : MonoBehaviour
{
    public RectTransform phonePanel;
    public Vector2 hiddenPosition;
    public Vector2 visiblePosition;
    public float moveSpeed;
    public float visibleDuration;

    public Transform messagesContainer;
    public GameObject messagePrefab;
    private GameObject currentMessage;

    private bool isVisible;
    private Coroutine hideCoroutine;

    private void Update()
    {
        MovePanel();
    }

    private void MovePanel()
    {
        var targetPosition = isVisible ? visiblePosition : hiddenPosition;
        phonePanel.anchoredPosition = Vector2.MoveTowards(phonePanel.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(visibleDuration);
        isVisible = false;
        currentMessage.SetActive(false);
    }

    public void ShowMessage(string text)
    {
        isVisible = true;

        if (hideCoroutine != null)
            StopCoroutine(hideCoroutine);
        
        AddMessage(text);

        hideCoroutine = StartCoroutine(HideAfterDelay());
    }

    private void AddMessage(string text)
    {
        var newMessage = Instantiate(messagePrefab, messagesContainer);
        currentMessage = newMessage;
        var messageTextComponent = newMessage.GetComponent<TextMeshProUGUI>();
        messageTextComponent.text = text;
        newMessage.SetActive(true);
    }
}