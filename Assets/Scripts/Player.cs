using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Получаем ввод по осям
        float horizontal = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float vertical = Input.GetAxis("Vertical");     // W/S или стрелки вверх/вниз

        // Вектор направления движения
        Vector3 movement = new Vector3(horizontal, vertical, 0f);

        // Двигаем игрока
        transform.Translate(movement * (moveSpeed * Time.deltaTime), Space.World);
    }
}