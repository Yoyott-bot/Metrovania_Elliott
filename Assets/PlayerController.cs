using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{ 
    private Rigidbody2D rb;
    [SerializeField] private float walkspeed = 6f;
    private float xAxis;
    private float jumpForce = 20f;
    private bool jumpPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInputs();
        Move();
        Jump();
    }

    void GetInputs()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        xAxis = 0f;
        if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            xAxis = -1f;
        if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            xAxis = 1f;

        jumpPressed = keyboard.spaceKey.wasPressedThisFrame;
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(walkspeed * xAxis, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (jumpPressed)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}