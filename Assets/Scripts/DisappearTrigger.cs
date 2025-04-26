using System;
using UnityEngine;

public class DisappearTrigger : MonoBehaviour
{
    private bool onTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        onTrigger = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        onTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        onTrigger = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
            gameObject.SetActive(false);
    }
}
