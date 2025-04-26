using UnityEngine;

public class ForceRunTrigger : MonoBehaviour
{
    public Vector2 runDirection = Vector2.right;
    public float runSpeed = 20f;
    public float stopRunDelay = 2f;
    public Vector2 teleportPosition; // <<< Новая точка телепорта

    private bool triggered;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (!other.CompareTag("Player")) return;

        triggered = true;

        player = other.GetComponent<Player>();
        if (player == null) return;

        player.StartForcedRun(runDirection, runSpeed);

        var cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
            cameraFollow.enabled = false;

        Invoke(nameof(StopForcedRun), stopRunDelay);
    }

    private void StopForcedRun()
    {
        if (player != null)
        {
            player.StopForcedRun();

            // Телепортируем игрока
            player.transform.position = teleportPosition;
        }

        var cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
            cameraFollow.enabled = true;

        Destroy(gameObject);
    }
}