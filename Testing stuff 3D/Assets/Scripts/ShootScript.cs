using UnityEngine;
using UnityEngine.InputSystem;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] bulletScriptableObject[] bulletSO;
    [SerializeField] int bulletType;
    bool canShoot = true;

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint);
        Renderer renderer = bullet.GetComponent<Renderer>();
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        bullet.name = bulletSO[bulletType].bulletName;
        renderer.material = bulletSO[bulletType].bulletMaterial;
        Destroy(bullet, bulletSO[bulletType].bullerLifeTime);
        bulletRB.AddForce(shootPoint.forward * bulletSO[bulletType].bulletVelocity, ForceMode.Impulse);
        
    }

    public void ShootInput(InputAction.CallbackContext context)
    {
        if (context.performed && canShoot)
        {
            Shoot();
        }
    }

    public void ChangeBulletType (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (bulletType < (bulletSO.Length - 1))
            {
                bulletType++;
            }
            else
            {
                bulletType = 0;
            }
        }
    }
}
