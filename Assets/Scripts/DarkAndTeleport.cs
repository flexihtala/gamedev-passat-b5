using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DialogueTrigger))]
public class SpawnTeleportDestroy : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform teleportPoint;
    [SerializeField] private GameObject player;

    private GameObject spawnedObject;
    private DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void SpawnTeleportAndDestroy()
    {
        if (!IsValidSetup())
            return;

        if (dialogueTrigger.countDialoges > 1)
            return;

        spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

        var fadeController = spawnedObject.GetComponent<ScreenFadeController>();
        if (fadeController != null)
        {
            fadeController.OnTriggerEnter2D(player.GetComponent<Collider2D>());
        }

        StartCoroutine(HandleTeleportAndCleanup(fadeController));
    }

    private IEnumerator HandleTeleportAndCleanup(ScreenFadeController fadeController)
    {
        yield return new WaitForSeconds(2f);

        if (player != null && teleportPoint != null)
        {
            player.transform.position = teleportPoint.position;
        }

        yield return new WaitForSeconds(2f);

        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
    }

    private bool IsValidSetup()
    {
        if (prefabToSpawn == null || spawnPoint == null || teleportPoint == null || player == null)
        {
            Debug.LogWarning("SpawnTeleportDestroy: One or more required fields are not assigned!");
            return false;
        }
        return true;
    }
}