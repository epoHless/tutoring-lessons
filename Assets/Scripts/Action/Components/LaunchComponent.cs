using UnityEngine;

namespace Tutoring.Mobile.Input_Action
{
    [RequireComponent(typeof(Rigidbody2D)), DisallowMultipleComponent]
    public class LaunchComponent : MonoBehaviour
    {
        [SerializeField, Range(1, 100)] private float speed = 10;
        private Rigidbody2D rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            InputManager.OnTouchReleased += OnTouchReleased;
            InputManager.OnTouchBegan += OnTouchBegan;
        }

        private void OnDisable()
        {
            InputManager.OnTouchReleased -= OnTouchReleased;
            InputManager.OnTouchBegan -= OnTouchBegan;
        }

        private void OnTouchBegan(TouchData _touchData)
        {
            rigidbody.velocity = Vector2.zero;
        }
        
        private void OnTouchReleased(Vector3 _direction)
        {
            rigidbody.AddForce(_direction * speed, ForceMode2D.Impulse);
        }
    }
}