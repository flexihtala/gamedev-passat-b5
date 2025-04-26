using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // Игрок или цель, за которой будет следовать камера
    public Vector3 offset;      // Смещение камеры относительно цели
    public float smoothSpeed = 0.125f; // Скорость сглаживания движения
    

    private void Start()
    {
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        smoothedPosition.z = -10;
        transform.position = smoothedPosition;

        // Если нужно, чтобы камера всегда смотрела на игрока:
        transform.LookAt(target);
    }
}
