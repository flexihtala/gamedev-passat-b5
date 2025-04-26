using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialoguePanel;      // UI панель с диалогом
    public Text dialogueText;             // UI текст внутри панели
    [TextArea(3, 10)]
    public string dialogueContent;        // Текст диалога

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueContent;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            dialoguePanel.SetActive(false);
    }
}