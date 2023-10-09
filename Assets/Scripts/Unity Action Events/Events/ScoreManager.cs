using System;
using UnityEngine;
using UnityEngine.Events;

namespace Tutoring.Mobile.Unity_Action_Events
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private int score;

        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnScoreChanged?.Invoke(score);
            }
        }

        public static Action<int> OnScoreChanged;

        [SerializeField] private UnityEvent<int> OnScoreAdded;

        private void OnEnable()
        {
            OnScoreAdded.AddListener(AddScore);
        }

        private void OnDisable()
        {
            OnScoreAdded.RemoveListener(AddScore);
        }

        private void AddScore(int _score)
        {
            Score += _score;
        }

        public void TriggerOnScoreAdded(int score)
        {
            OnScoreAdded?.Invoke(score);
        }
    }
}
