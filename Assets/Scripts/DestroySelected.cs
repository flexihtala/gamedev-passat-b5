using System;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject targetObject;
    private DialogueTrigger d;

    private void Start()
    {
        d = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (d.isDialogShownOnce)
            targetObject.SetActive(false);
    }
}