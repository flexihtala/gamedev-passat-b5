using System;
using UnityEngine;

public class DisappearAfterAtLeast1Dialoge : MonoBehaviour
{
    private bool onTrigger;
    public DialogueTrigger dialogue;

    void Start()
    {
        onTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || dialogue.countDialoges < 1) return;
        onTrigger = true;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
            gameObject.SetActive(false);
    }
}