using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTransformMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;

    private void FixedUpdate()
    {
        // Create local XZ move from input, convert to world space and keep Y unchanged
        Vector3 localMove = new Vector3(moveInput.x, 0f, moveInput.y);
        Vector3 worldMove = transform.TransformDirection(localMove);
        worldMove.y = 0f;

        // moveSpeed is units/second; multiply by FixedDeltaTime
        transform.position += worldMove * moveSpeed * Time.fixedDeltaTime;
    }

    // Wire this to your Input System "Move" action
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}

