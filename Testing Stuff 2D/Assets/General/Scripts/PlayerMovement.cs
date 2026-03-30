using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 input;
    Animator animator;
    SpriteRenderer sr;

    public float speed;
    public float maxSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb.linearVelocityX = (input.x * speed);

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

    private void Update()
    {
        if (rb.linearVelocity.x > 0)
        { 
            animator.SetBool("Moving", true);
            sr.flipX = false;
        }
        else if (rb.linearVelocity.x < 0)
        { 
            animator.SetBool("Moving", true);
            sr.flipX = true;
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if(rb.linearVelocity.y > 0)
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Moving", false);
        }
        else if(rb.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
            animator.SetBool("Jumping", false);
            animator.SetBool("Moving", false);
        }
        else
        {
            animator.SetBool("Falling", false);
            animator.SetBool("Jumping", false);
        }  

    }
    public void Move(InputAction.CallbackContext c)
    {
        input = c.ReadValue<Vector2>();
    }
}
