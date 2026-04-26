using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{ 
    private Rigidbody2D rb;
    private float walkspeed = 1f;
    private float xAxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       	rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
   	    Move();
    }



    void GetInputs()
    {
        // Keyboard.current replaces Input.GetAxisRaw("Horizontal")
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        xAxis = 0f;
        if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            xAxis = -1f;
        if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            xAxis = 1f;
    }

    
    private void Move()
    {
	    rb.linearVelocity = new Vector2(walkspeed * xAxis, rb.linearVelocity.y);
    }	
	 	
   


}
