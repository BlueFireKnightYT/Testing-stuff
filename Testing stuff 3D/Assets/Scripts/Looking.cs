using UnityEngine;
using UnityEngine.InputSystem;

public class Looking : MonoBehaviour
{
    Vector2 lookInput;
    public float sensitivity;
    //float xRotation = 0f;

    GameObject cam;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void LateUpdate()
    {
        float mouseX = lookInput.x * sensitivity;
        //float mouseY = lookInput.y * sensitivity;

        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -90, 90);

        //cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    public void Look(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
}
