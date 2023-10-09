using UnityEngine;

namespace Tutoring.Mobile.Input_Action
{
    public struct TouchData
    {
        public TouchData(Vector2 _position, float _id)
        {
            Position = _position;
            ID = _id;
        }

        public Vector2 Position;
        public float ID;
    }
}
