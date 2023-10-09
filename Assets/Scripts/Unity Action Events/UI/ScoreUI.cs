using TMPro;
using UnityEngine;

namespace Tutoring.Mobile.Unity_Action_Events
{
    [DisallowMultipleComponent, RequireComponent(typeof(TMP_Text))]

    public class ScoreUI : MonoBehaviour
    {
        private TMP_Text tx_score;

        private void Awake()
        {
            tx_score = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            ScoreManager.OnScoreChanged += SetScore;
        }

        private void OnDisable()
        {
            ScoreManager.OnScoreChanged -= SetScore;
        }

        public void SetScore(int score)
        {
            tx_score.text = score.ToString();
        }
    }
}
