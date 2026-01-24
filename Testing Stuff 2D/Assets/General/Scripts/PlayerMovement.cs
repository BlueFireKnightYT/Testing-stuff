using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce(input * 30);
    }

    public void Move(InputAction.CallbackContext c)
    {
        input = c.ReadValue<Vector2>();
    }
}
