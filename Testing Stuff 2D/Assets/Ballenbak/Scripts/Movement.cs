using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    float horizontal;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpH = 7f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    [SerializeField] GameObject shootPos;
    public bullet bulletCode;
    public bool flipped = false;

    private void Update()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocityY);

        if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(180, 0, 0);
            shootPos.transform.localPosition = new Vector2(-1, 0);
            flipped = true;
        }
        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            shootPos.transform.localPosition = new Vector2(1, 0);
            flipped = false;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}

