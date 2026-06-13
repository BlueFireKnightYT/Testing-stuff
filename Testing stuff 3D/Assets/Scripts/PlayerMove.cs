using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed;
    Vector2 moveInput;
    [SerializeField] PlayerStatsSO playerStatsSO;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveSpeed = playerStatsSO.speed;
        Vector3 moveDir = transform.forward * moveInput.y + transform.right * moveInput.x;

        rb.linearVelocity = new Vector3(moveDir.x * moveSpeed, rb.linearVelocity.y, moveDir.z * moveSpeed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
    }
}
