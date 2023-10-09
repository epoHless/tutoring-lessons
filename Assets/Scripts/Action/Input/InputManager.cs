using System;
using UnityEngine;

namespace Tutoring.Mobile.Input_Action
{
    public class InputManager : MonoBehaviour
    {
        //first part
        public static Action<TouchData> OnTouchBegan; //send position info

        //second part
        private Vector2 startTouch;
        private Vector2 endTouch;
        
        public static Action<Vector3> OnTouchReleased; //send direction info

        private void Update()
        {
            if (Input.touchCount == 0) return;
                
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouch = touch.position;
                endTouch = touch.position;
                
                OnTouchBegan?.Invoke(new TouchData(touch.position, touch.fingerId));
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endTouch = touch.position;

                var direction = endTouch - startTouch;
                OnTouchReleased?.Invoke(direction.normalized); // -1 | 1
            }
        }
    }
}
