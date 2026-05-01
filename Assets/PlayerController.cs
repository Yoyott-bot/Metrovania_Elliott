using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{ 
    private Rigidbody2D rb;
    [SerializeField] private float walkspeed = 6f;
    private float xAxis;  


    [Header("Ground Check Settings ")]
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private bool jumpPressed;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
     [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
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

    public bool Grounded()
    {
        // Check if the player is grounded using a raycast
        // the following code checks for the ground in multiple positions around the player to ensure better detection
        if(Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround) 
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround) || Physics2D.Raycast(groundCheckPoint.position - new Vector3(groundCheckX, 0, 0), Vector2.right, groundCheckX, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround) || Physics2D.Raycast(groundCheckPoint.position - new Vector3(groundCheckX, 0, 0), Vector2.right, groundCheckX, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

