using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;

    public float speed;
    public float maxSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(input * speed);

        if (rb.linearVelocityX > maxSpeed) 
        { 
            rb.linearVelocityX = maxSpeed;
        }
        if (rb.linearVelocityX < -maxSpeed)
        {
            rb.linearVelocityX = -maxSpeed;
        }
        Debug.Log(rb.linearVelocityX);
    }

    public void Move(InputAction.CallbackContext c)
    {
        input = c.ReadValue<Vector2>();
    }
}
