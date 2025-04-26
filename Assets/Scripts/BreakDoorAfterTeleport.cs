using TMPro;
using UnityEngine;

public class TriggerCheckCount : MonoBehaviour
{
    public GameObject sourceObject; // Объект, из которого достаём переменную count

    private int count = 0;

    private void UpdateCount()
    {
        if (sourceObject != null)
        {
            var componentWithCount = sourceObject.GetComponent<DialogueTrigger>();
            if (componentWithCount != null)
            {
                count = componentWithCount.countDialoges;
            }
            else
            {
                Debug.LogWarning("На sourceObject нет компонента с переменной count!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        UpdateCount();

        if (count >= 1)
        {
            GetComponent<Collider2D>().enabled = false;
            var dialogue = GetComponent<DialogueTriggerWithoutE>();
            dialogue.fullDialogueText = "Это кабинет шефа";
            var panel = dialogue.dialoguePanel;
            panel.SetActive(false);
        }
    }
}