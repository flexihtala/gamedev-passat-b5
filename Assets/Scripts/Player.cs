using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private PlayerInputActions inputActions;
    private Rigidbody2D rb;
    
    private bool isForcedRunning = false;
    private Vector2 forcedRunDirection;
    private float forcedRunSpeed;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        if (isForcedRunning)
            rb.MovePosition(rb.position + forcedRunDirection * (forcedRunSpeed * Time.fixedDeltaTime));
        else
            rb.MovePosition(rb.position + moveInput * (moveSpeed * Time.fixedDeltaTime));
    }
    
    public void StartForcedRun(Vector2 direction, float speed)
    {
        isForcedRunning = true;
        forcedRunDirection = direction.normalized;
        forcedRunSpeed = speed;
        inputActions.Player.Disable(); // Отключаем управление игрока
    }
    
    public void StopForcedRun()
    {
        isForcedRunning = false;
        inputActions.Player.Enable(); // Возвращаем обычное управление
        moveInput = Vector2.zero;     // Останавливаем движение
    }
}