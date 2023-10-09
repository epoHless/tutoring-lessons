using TMPro;
using UnityEngine;

namespace Tutoring.Mobile.Input_Action
{
    [DisallowMultipleComponent]
    public class PositionUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text tx_position;
        [SerializeField] private TMP_Text tx_id;
        
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
            tx_position.text = _touchData.Position.ToString();
            tx_id.text = _touchData.ID.ToString();
        }
    }
}