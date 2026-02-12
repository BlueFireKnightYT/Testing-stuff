using UnityEngine;
using UnityEngine.InputSystem;

public class FlappyBirdJump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpHeight = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rb.linearVelocityY = jumpHeight;
        }
    }
}