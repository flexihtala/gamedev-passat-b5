using System;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerNameText;

    [TextArea(5, 20)]
    public string fullDialogueText;

    private List<string> lines = new();
    private List<string> speakers = new();
    private int currentIndex = 0;
    private bool dialogueStarted = false;
    private bool onTrigger = false;
    public bool isDialogShownOnce = false;
    public int countDialoges = 0;

    private void Start()
    {
        ParseDialogue(fullDialogueText);
        onTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        onTrigger = true;
        currentIndex = 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        dialogueStarted = false;
        dialoguePanel.SetActive(false);
        currentIndex = 0;
        onTrigger = false;
    }

    private void Update()
    {
        if (!dialogueStarted && Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            dialogueStarted = true;
            dialoguePanel.SetActive(true);
            ShowCurrentLine();
            isDialogShownOnce = true;
            countDialoges++;
        }
        if (dialogueStarted && Input.GetKeyDown(KeyCode.Space))
            NextLine();
    }

    private void NextLine()
    {
        currentIndex++;

        if (currentIndex >= lines.Count)
        {
            dialoguePanel.SetActive(false);
            dialogueStarted = false;
            currentIndex = 0;
            return;
        }

        ShowCurrentLine();
    }

    private void ShowCurrentLine()
    {
        speakerNameText.text = speakers[currentIndex];
        dialogueText.text = lines[currentIndex];
    }

    private void ParseDialogue(string text)
    {
        lines.Clear();
        speakers.Clear();

        var rawLines = text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var currentSpeaker = "";

        foreach (var rawLine in rawLines)
        {
            var trimmed = rawLine.Trim();

            if (trimmed.EndsWith(":"))
            {
                currentSpeaker = trimmed.TrimEnd(':');
            }
            else if (trimmed.StartsWith("\"") && trimmed.EndsWith("\""))
            {
                lines.Add(trimmed.Trim('"'));
                speakers.Add(currentSpeaker);
            }
        }
    }
}
