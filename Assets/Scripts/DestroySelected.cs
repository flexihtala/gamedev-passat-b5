using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DialogueTrigger))]
public class ObjectDestroyer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject targetObject;
    [SerializeField] private UnityEvent onTeleportAction;
    [SerializeField] private int maxTeleports = 3;

    private DialogueTrigger dialogueTrigger;
    private int teleportCount = 0;
    private bool isTeleporting = false;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Диалог обрабатывается отдельно
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (dialogueTrigger != null && dialogueTrigger.isDialogShownOnce && !isTeleporting)
        {
            StartCoroutine(TeleportAndHandle());
        }
    }

    private IEnumerator TeleportAndHandle()
    {
        isTeleporting = true;

        // Выполнить действия связанные с телепортом
        onTeleportAction?.Invoke();

        // Здесь можно поставить задержку если нужно, например:
        yield return new WaitForSeconds(3f); // допустим 1 секунда после телепорта

        teleportCount++;

        if (teleportCount >= maxTeleports)
        {
            DestroyTargetObject();
        }

        isTeleporting = false;
    }

    private void DestroyTargetObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned in ObjectDestroyer.");
        }
    }
}