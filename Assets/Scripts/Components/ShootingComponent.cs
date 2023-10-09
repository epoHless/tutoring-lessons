using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingComponent : MonoBehaviour
{
    [SerializeField] private BulletComponent bulletPrefab;

    private void OnEnable()
    {
        InputManager.BindOnFire(FireBullet);
    }

    private void FireBullet(InputAction.CallbackContext _obj)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.SetVelocity(InputManager.MovementAxis);
    }
}
