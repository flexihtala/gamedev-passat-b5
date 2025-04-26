using System;
using UnityEngine;

public class SetFalse : MonoBehaviour
{
    public GameObject GameObject1;

    public bool value;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            GameObject1.SetActive(value);
    }
}
