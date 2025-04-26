using UnityEngine;
using UnityEngine.UI;

public class ShowImageOnTrigger : MonoBehaviour
{
    [SerializeField] private Image imageToShow;
    [SerializeField] private float heightAbovePlayer  = 1.5f; // Смещение ближе к объекту
    private Transform player; // Игрок

    private void Start()
    {
        imageToShow.enabled = false; // Выключаем полностью объект
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        imageToShow.enabled = true;
        PositionImageBetweenPlayerAndObject();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            imageToShow.enabled = false;
    }

    private void PositionImageBetweenPlayerAndObject()
    {
        if (player == null)
            return;
        
        Vector3 worldPosition = player.position + new Vector3(0, heightAbovePlayer, 0);

        // Переводим мировую позицию в позицию на экране
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        
    }
}