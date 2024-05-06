using System.Linq;
using Api.Common;
using Api.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mono.Manager
{
    public class MainMenuManager : MonoBehaviour, IMainMenuManager
    {
        private const string GameSceneName = "Scene";

        [SerializeField] private TextMeshProUGUI maxDistanceText;

        private void OnEnable()
        {
            var scoreboard = ScoreboardManager.LoadScoreboard();
            var maxDistanceGame = scoreboard.GetGamesSortedByDistanceDescending().FirstOrDefault();
            var maxDistance = 0F;

            if (maxDistanceGame != null) maxDistance = maxDistanceGame.distance;
            maxDistanceText.SetText($"{MathUtil.TrimFloat(maxDistance, 10)} m");
        }

        public void StartGame() => SceneManager.LoadScene(GameSceneName, LoadSceneMode.Single);
        public void QuitGame() => Application.Quit();
    }
}