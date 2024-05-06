using System.Collections.Generic;
using Api.Common;
using TMPro;
using UnityEngine;

namespace Mono.GUI
{
    public class GameGUI : MonoBehaviour
    {
        private const int DistanceMantissaPrecision = 1;
        
        [SerializeField] public TextMeshProUGUI countdownText;
        [SerializeField] public List<GameObject> healthIcons = new();
        [SerializeField] public List<GameObject> capsuleIcons = new();
        [SerializeField] public TextMeshProUGUI distanceText;

        private int capsuleIconsIndex;
        
        public void UpdateCountdownText(int startingTime) => countdownText.text = $"Starting in {startingTime} ...";
        //public void UpdateHealth(int value) => healthText.text = $"Health: {value}";
        public void UpdateHealth(int value)
        {
            for (int i = healthIcons.Count - 1; i >= 0; i--)
                healthIcons[i].SetActive(value > i);
        }

        public void UpdateCapsule()
        {
            if (capsuleIconsIndex >= capsuleIcons.Count) return;
            capsuleIcons[capsuleIconsIndex++].SetActive(false);
        }

        public void ResetCapsules()
        {
            foreach (var capsuleIcon in capsuleIcons)
            {
                capsuleIcon.SetActive(true);
            }

            capsuleIconsIndex = 0;
        }

        public void UpdateDistanceText(float value) => 
            distanceText.text = $"{MathUtil.TrimFloat(value, DistanceMantissaPrecision)} m";
        
        public void SetActive(bool active) => gameObject.SetActive(active);
        public bool IsActive() => gameObject.activeSelf;
    }
}