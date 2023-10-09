using System;
using UnityEngine;

[DisallowMultipleComponent, RequireComponent(typeof(Rigidbody2D))]
public class BulletComponent : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector3 _direction)
    {
        rigidbody.velocity = _direction * speed;
    }
}
