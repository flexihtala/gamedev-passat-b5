using UnityEngine;

public class TriggerRunner : MonoBehaviour
{
    public float runSpeed = 10f;
    public Vector2 runDirection = Vector2.right;
    public float runDuration = 2f; // <<< сколько секунд бежать

    private bool playerInTrigger = false;
    private bool isRunning = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
            StartRunning();
    }

    private void FixedUpdate()
    {
        if (isRunning)
            rb.MovePosition(rb.position + runDirection.normalized * (runSpeed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInTrigger = false;
    }

    private void StartRunning()
    {
        if (isRunning) return;

        isRunning = true;
        Invoke(nameof(StopRunning), runDuration);
    }

    private void StopRunning()
    {
        isRunning = false;
        gameObject.SetActive(false);
    }
}