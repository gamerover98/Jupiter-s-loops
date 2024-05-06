using System.Collections;
using System.Collections.Generic;
using Api;
using Mono.GameState;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mono.Manager
{
    public class MonoGameManager : MonoBehaviour
    {
        private const string MainMenuSceneName = "MainMenuScene";

        public static MonoGameManager instance;
        public static bool IsFirstGame = true;

        private static readonly Dictionary<GameStateType, GenericGameState> RegisteredGameStates = new();
        public static GameStateType CurrentGameStateType { get; private set; } = GameStateType.Starting;

        [SerializeField] private EventManager eventManager;
        [SerializeField] private MonoBiomeManager biomeManager;
        [SerializeField] private MonoPlayerManager playerManager;
        [SerializeField] private MonoInputManager inputManager;
        [SerializeField] private GUIMenuManager guiMenuManager;

        [Tooltip("How long the starting phase should last.")]
        public int startingTimeInSeconds = 3;

        [Tooltip("How many times the game-loop should be updated each second.")]
        public int gameStateTicksPerSeconds = 60;

        private Coroutine updateGameCoroutine;

        private void Awake()
        {
            if (instance == null) instance = this;

            RegisteredGameStates.Clear();
            RegisteredGameStates.Add(GameStateType.Starting, new StartingState());
            RegisteredGameStates.Add(GameStateType.Playing, new PlayingState());
            RegisteredGameStates.Add(GameStateType.Ending, new EndingState());
        }

        private void Start()
        {
            CurrentGameStateType = GameStateType.Starting;
            updateGameCoroutine = StartCoroutine(UpdateGameStateRoutine());
        }

        private void OnDestroy()
        {
            StopCoroutine(updateGameCoroutine);
        }

        private IEnumerator UpdateGameStateRoutine()
        {
            var waitingTime = new WaitForSeconds(1F / gameStateTicksPerSeconds);

            while (GetCurrentGameState() is { } gameState)
            {
                if (gameState.IsEnding)
                {
                    gameState.End();

                    var nextGameState = gameState.GetNext();
                    if (nextGameState.HasValue) CurrentGameStateType = nextGameState.GetValueOrDefault();
                    else break;
                }

                if (gameState.IsUpdating) gameState.Update();
                if (gameState.IsStarting) gameState.Start();

                yield return waitingTime;
            }

            yield return null;
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene(MainMenuSceneName);
        }

        private static GenericGameState GetCurrentGameState() =>
            RegisteredGameStates.GetValueOrDefault(CurrentGameStateType);

        public static EventManager GetEventManager() => instance.eventManager;
        public static MonoBiomeManager GetBiomeManager() => instance.biomeManager;
        public static MonoPlayerManager GetPlayerManager() => instance.playerManager;
        public static MonoInputManager GetInputManager() => instance.inputManager;
        public static GUIMenuManager GetGuiMenuManager() => instance.guiMenuManager;
    }
}