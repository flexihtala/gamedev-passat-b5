using System;
using UnityEngine;

public class ChefTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public GameObject wife;
    public BoxCollider2D wifeTrigger;
    private ObjectDestroyer objDestroyer;

    private void Start()
    {
        objDestroyer = wife.GetComponents<ObjectDestroyer>()[1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        wifeTrigger.enabled = true;
        objDestroyer.enabled = true;
        dialogueTrigger.countDialoges = 0;
        dialogueTrigger.fullDialogueText = "Сьюзен:\n \"Как твой день?\"\n\nДжо:\n \"Отвратительно, сделали выговор. Мне кажетс, сейчас зарплата вообще будет пару копеек.\" \n\nДжо:\n \"Я не могу так больше жить в нищите, да и начальник унижает! Я чуть ему в морду не дал\"\n\nСьюзен:\n \"Не будь так категоричен все ошибаются, хорошо что ты сдержал себя. Главное все живы и ты дома\"\n\nДжо:\n \"Нет, ты не понимаешь, я устал это терпеть\" \n\n";
    }
}
