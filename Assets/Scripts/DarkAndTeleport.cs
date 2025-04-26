using System;
using System.Collections;
using UnityEngine;

public class SpawnTeleportDestroy : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public Transform teleportPoint;
    public GameObject player;

    private GameObject spawnedObject;
    private DialogueTrigger dialogue;

    public void SpawnTeleportAndDestroy()
    {
        if (prefabToSpawn == null || spawnPoint == null || teleportPoint == null || player == null)
        {
            Debug.LogWarning("Не все поля заполнены в SpawnTeleportDestroy!");
            return;
        }
        
        dialogue = GetComponent<DialogueTrigger>();
        Debug.Log(dialogue.countDialoges);
        if (dialogue.countDialoges > 1)
            return;
        

        // Спаун объекта
        spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

        // Запустить затемнение
        var fadeController = spawnedObject.GetComponent<ScreenFadeController>();
        if (fadeController != null)
        {
            fadeController.OnTriggerEnter2D(player.GetComponent<Collider2D>()); // вызываем метод начала затемнения (не OnTriggerEnter!)
        }

        // Стартуем корутину
        StartCoroutine(TeleportAfterFade(fadeController));
    }

    private IEnumerator TeleportAfterFade(ScreenFadeController fadeController)
    {
        // Подождать пока затемнение полностью не закончится
        // Допустим затемнение длится 2 секунды (можно подстроить)
        yield return new WaitForSeconds(2f);

        // Телепортировать игрока
        player.transform.position = teleportPoint.position;
        
        yield return new WaitForSeconds(0.5f);

        // Убрать затемняющий объект
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }
}