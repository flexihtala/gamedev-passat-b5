using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerNameText;

    [TextArea(5, 20)]
    public string fullDialogueText;

    [Header("Line Settings")]
    [SerializeField] private int maxCharactersPerLine = 100;

    [Header("Trigger Settings")]
    [SerializeField] private bool isOnE = true; // ⬅⬅⬅ Новая галочка: запускать диалог по кнопке E или сразу

    public List<string> lines = new();
    private List<string> speakers = new();
    public int currentIndex = 0;
    private bool dialogueStarted = false;
    private bool onTrigger = false;
    public bool isDialogShownOnce = false;
    public int countDialoges = 0;

    private void Start()
    {
        ParseDialogue(fullDialogueText);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        onTrigger = true;
        currentIndex = 0;

        if (!isOnE)
        {
            StartDialogue();
        }
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
        if (isOnE && !dialogueStarted && Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            StartDialogue();
        }

        if (dialogueStarted && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    private void StartDialogue()
    {
        ParseDialogue(fullDialogueText);
        dialogueStarted = true;
        dialoguePanel.SetActive(true);
        ShowCurrentLine();
        isDialogShownOnce = true;
        countDialoges++;
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
        string currentSpeaker = "";

        foreach (var rawLine in rawLines)
        {
            var trimmed = rawLine.Trim();

            if (trimmed.EndsWith(":"))
            {
                currentSpeaker = trimmed.TrimEnd(':');
            }
            else if (trimmed.StartsWith("\"") && trimmed.EndsWith("\""))
            {
                var dialogueLine = trimmed.Trim('\"');

                List<string> brokenLines = BreakLongLine(dialogueLine, maxCharactersPerLine);
                foreach (var line in brokenLines)
                {
                    lines.Add(line);
                    speakers.Add(currentSpeaker);
                }
            }
        }
    }

    private List<string> BreakLongLine(string text, int maxLength)
    {
        List<string> result = new();

        while (text.Length > maxLength)
        {
            int breakIndex = text.LastIndexOf(' ', maxLength);
            if (breakIndex == -1) breakIndex = maxLength;

            result.Add(text.Substring(0, breakIndex));
            text = text.Substring(breakIndex).Trim();
        }

        if (!string.IsNullOrEmpty(text))
        {
            result.Add(text);
        }

        return result;
    }
}
