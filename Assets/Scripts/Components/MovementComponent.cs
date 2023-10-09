using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField, Range(1, 10)] private float speed = 2f;

    private void Update()
    {
        Vector3 direction = InputManager.MovementAxis;
        transform.position += direction * (speed * Time.deltaTime);
    }
}
