using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    float horizontal;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpH = 7f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    
    private void Update()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }


    public bool isGrounded()
    {
        var hits = Physics2D.OverlapCapsuleAll
        (
            groundCheck.position,
            new Vector2(1f, 0.5f),
            CapsuleDirection2D.Horizontal,
            0f,
            groundLayer
        );

        return hits.Length > 0;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded() == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpH);
        }
    }
}

