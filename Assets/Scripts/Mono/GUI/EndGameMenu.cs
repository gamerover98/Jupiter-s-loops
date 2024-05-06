using System.Linq;
using Api.Common;
using Mono.Manager;
using TMPro;
using UnityEngine;

namespace Mono.GUI
{
    public class EndGameMenu : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI distanceTextValue;
        [SerializeField] private TextMeshProUGUI recordDistanceTextValue;
        
        protected void OnEnable()
        {
            Time.timeScale = 0;
            MonoInputManager.EscapeKeyPressed -=
                MonoGameManager.GetGuiMenuManager().OpenOrClosePauseMenu;

            var distance = MonoGameManager.GetPlayerManager().Distance;
            distanceTextValue.SetText($"{MathUtil.TrimFloat(distance, 10)} m");
            
            var scoreboard = ScoreboardManager.LoadScoreboard();
            var maxDistanceGame = scoreboard.GetGamesSortedByDistanceDescending().FirstOrDefault();
            var maxDistance = 0F;

            if (maxDistanceGame != null) maxDistance = maxDistanceGame.distance;
            recordDistanceTextValue.SetText($"{MathUtil.TrimFloat(maxDistance, 10)} m");
        }

        protected void OnDisable()
        {
            MonoGameManager.instance.BackToMainMenu();
            MonoGameManager.IsFirstGame = false;
        }

        public void SetActive(bool active) => gameObject.SetActive(active);
        public bool IsActive() => gameObject.activeSelf;
    }
}