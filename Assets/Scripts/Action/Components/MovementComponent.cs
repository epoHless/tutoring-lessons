using UnityEngine;

namespace Tutoring.Mobile.Input_Action
{
    public class MovementComponent : MonoBehaviour
    {
        private Camera playerCamera;

        private void Awake()
        {
            playerCamera = Camera.main;
        }

        private void OnEnable()
        {
            InputManager.OnTouchBegan += OnTouchBegan;
        }

        private void OnDisable()
        {
            InputManager.OnTouchBegan -= OnTouchBegan;
        }

        private void OnTouchBegan(TouchData _touchData)
        {
            Vector3 worldPoint = playerCamera.ScreenToWorldPoint(_touchData.Position);
            worldPoint.z = 0;

            transform.position = worldPoint;
        }
    }
}
