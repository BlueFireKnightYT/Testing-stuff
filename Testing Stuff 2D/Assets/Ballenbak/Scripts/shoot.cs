using UnityEngine;
using UnityEngine.InputSystem;

public class shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
