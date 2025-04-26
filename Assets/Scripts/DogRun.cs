using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public string triggerName = "isRun"; // Имя триггера в Animator

    private Animator animator;
    private bool playerInZone = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger(triggerName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}