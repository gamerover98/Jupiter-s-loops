using Api.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mono.Manager
{
    public class MainMenuManager : MonoBehaviour, IMainMenuManager
    {
        private const string GameSceneName = "Scene";

        public void StartGame() => SceneManager.LoadScene(GameSceneName);
    }
}