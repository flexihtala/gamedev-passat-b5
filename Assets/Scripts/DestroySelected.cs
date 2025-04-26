using UnityEngine;
using UnityEngine.Events;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject targetObject;
    public UnityEvent onTriggerExitAction; // Тут в инспекторе настраиваем что делать

    private DialogueTrigger d;

    private void Start()
    {
        d = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (d != null && d.isDialogShownOnce)
        {
            onTriggerExitAction?.Invoke();
        }
    }
}