using UnityEngine;
using UnityEngine.InputSystem;

public class jumpingRaycast : MonoBehaviour
{
    Rigidbody2D rb;
    LayerMask groundMask;
    bool canJump;
    public float jumpHeight = 50f;
    public float jumpRayDistance;
    int baseExtraJumps = 1;
    int extraJumps = 1;
    [SerializeField] float newGravityScale;

    private void Start()
    {
        groundMask = LayerMask.GetMask("ground");
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.down * jumpRayDistance, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, jumpRayDistance, groundMask);

        if (hit)
        {
            canJump = true;
            extraJumps = baseExtraJumps;
        }
        else
        {
            canJump = false;
        }

        if (rb.linearVelocityY < -0.2f)
        {
            rb.gravityScale = newGravityScale;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    
    public void Jump(InputAction.CallbackContext context)
    {
        //checktt input
        if (context.performed)
        {
            if (canJump)
            { 
                rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
            }
            else if (extraJumps > 0)
            {
                rb.gravityScale = 1;
                rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
                extraJumps -= 1;
            }
        }
    }
}
