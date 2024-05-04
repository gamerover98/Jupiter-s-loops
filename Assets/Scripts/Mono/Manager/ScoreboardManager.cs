using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

namespace Mono.Manager
{
    public class ScoreboardManager : MonoBehaviour
    {
        public static ScoreboardManager Instance;

        private const string ScoreboardKeyName = "scoreboard";

        private void Awake()
        {
            Instance ??= this;
            DontDestroyOnLoad(gameObject);
        }

        [ProButton]
        public static void SaveGame(int capsules, float distance)
        {
            if (distance < 0) throw new ArgumentException("The distance value must be positive");
            if (capsules < 0) throw new ArgumentException("The capsules value must be positive");

            var scoreboard = LoadScoreboard();
            scoreboard.AddGame(new Game(capsules, distance));

            PlayerPrefs.SetString(ScoreboardKeyName, JsonUtility.ToJson(scoreboard));
            PlayerPrefs.Save();

            Debug.Log($"Game saved with: distance={distance}, capsules={capsules}");
        }

        public static Scoreboard LoadScoreboard()
        {
            Scoreboard result = null;

            if (PlayerPrefs.HasKey(ScoreboardKeyName))
                result =
                    JsonUtility.FromJson<Scoreboard>(
                        PlayerPrefs.GetString(ScoreboardKeyName, "{}"));

            result ??= new Scoreboard();
            return result;
        }

        [ProButton]
        public static void ClearScoreboard()
        {
            PlayerPrefs.DeleteKey(ScoreboardKeyName);
            PlayerPrefs.Save();

            Debug.Log($"Game scoreboard has been cleared");
        }
    }

    /// <summary>
    /// Represents a scoreboard containing a list of games.
    /// </summary>
    [Serializable]
    public class Scoreboard
    {
        /// <summary>
        /// The list of games in the scoreboard.
        /// </summary>
        public List<Game> games = new();

        /// <summary>
        /// Adds a game to the scoreboard.
        /// </summary>
        /// <param name="game">The game to add.</param>
        public void AddGame(Game game) => games.Add(game);

        /// <summary>
        /// Gets a list of games sorted by date in descending order.
        /// </summary>
        /// <returns>A list of games sorted by date in descending order.</returns>
        public List<Game> GetGamesSortedByDateDescending() =>
            games
                .OrderByDescending(game => game.dateTime)
                .ToList();
        
        /// <summary>
        /// Gets a list of games sorted by distance in descending order.
        /// </summary>
        /// <returns>A list of games sorted by distance in descending order.</returns>
        public List<Game> GetGamesSortedByDistanceDescending() =>
            games
                .OrderByDescending(game => game.distance)
                .ToList();

        /// <summary>
        /// Gets a list of games sorted by capsules collected in descending order.
        /// </summary>
        /// <returns>A list of games sorted by capsules collected in descending order.</returns>
        public List<Game> GetGamesSortedByCapsuleDescending() =>
            games
                .OrderByDescending(game => game.capsules)
                .ToList();

        public override string ToString() => JsonUtility.ToJson(games);
    }

    /// <summary>
    /// Represents a game with information about the date and
    /// time it was played, capsules collected, and distance traveled.
    /// </summary>
    [Serializable]
    public class Game
    {
        /// <summary>
        /// The date and time the game was played, represented as a string.
        /// </summary>
        public string dateTime;
        
        /// <summary>
        /// The number of capsules collected in the game.
        /// </summary>
        public int capsules;
        
        /// <summary>
        /// The distance traveled in the game.
        /// </summary>
        public float distance;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class with the
        /// specified number of capsules collected and distance traveled.
        /// </summary>
        /// <param name="capsules">The number of capsules collected in the game.</param>
        /// <param name="distance">The distance traveled in the game.</param>
        public Game(int capsules, float distance)
        {
            dateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            this.capsules = capsules;
            this.distance = distance;
        }
    }
}