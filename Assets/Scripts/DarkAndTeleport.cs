using System.Collections;
using UnityEngine;

public class SpawnTeleportDestroy : MonoBehaviour
{
    public GameObject prefabToSpawn;    // Префаб, который нужно заспаунить
    public Transform spawnPoint;        // Точка, где спаунить объект
    public Transform teleportPoint;     // Точка, куда телепортировать игрока
    public GameObject player;           // Игрок

    private GameObject spawnedObject;   // Ссылка на заспауненный объект

    public void SpawnTeleportAndDestroy()
    {
        if (prefabToSpawn == null || spawnPoint == null || teleportPoint == null || player == null)
        {
            Debug.LogWarning("Не все поля заполнены в SpawnTeleportDestroy!");
            return;
        }

        // 1. Спауним объект
        spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

        // 2. Запускаем корутину для телепортации и удаления
        StartCoroutine(TeleportAndDestroyAfterDelay(2f)); // 2 секунды задержка
    }

    private IEnumerator TeleportAndDestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 3. Телепортируем игрока
        player.transform.position = teleportPoint.position;
        
        yield return new WaitForSeconds(delay);

        // 4. Выключаем заспауненный объект
        if (spawnedObject != null)
        {
            spawnedObject.SetActive(false);
        }
    }
}