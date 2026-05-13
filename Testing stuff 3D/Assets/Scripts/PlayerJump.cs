using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] float jumpheight;
    [SerializeField] float rayLength;
    [SerializeField] LayerMask groundLayer;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump(InputAction.CallbackContext c)
    {
        bool jumpCheck = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);
        if (c.performed && jumpCheck)
        {
            rb.AddForce(Vector3.up * jumpheight, ForceMode.Impulse);
        }
    }
}
