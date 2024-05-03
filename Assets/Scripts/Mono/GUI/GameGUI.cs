using Api.Common;
using TMPro;
using UnityEngine;

namespace Mono.GUI
{
    public class GameGUI : MonoBehaviour
    {
        private const int DistanceMantissaPrecision = 10;

        [SerializeField] public TextMeshProUGUI countdownText;
        [SerializeField] public TextMeshProUGUI healthText;
        [SerializeField] public TextMeshProUGUI distanceText;

        public void UpdateCountdownText(int startingTime) => countdownText.text = $"Starting in {startingTime} ...";
        public void UpdateHealth(int value) => healthText.text = $"Health: {value}";
        public void UpdateDistanceText(float value) => 
            distanceText.text = $"Distance: {MathUtil.TrimFloat(value, DistanceMantissaPrecision)}";
        
        public void SetActive(bool active) => gameObject.SetActive(active);
        public bool IsActive() => gameObject.activeSelf;
    }
}