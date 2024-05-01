using TMPro;
using UnityEngine;

namespace Mono.Manager
{
    public class GUIMenuManager : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI countdownText;
        [SerializeField] public TextMeshProUGUI healthText;

        public void UpdateCountdownText(int startingTime) => countdownText.text = $"Starting in {startingTime} ...";
        public void UpdateHealth(int value) => healthText.text = $"Health: {value}";
    }
}