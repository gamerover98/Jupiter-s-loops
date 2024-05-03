using Mono.GUI;
using UnityEngine;

namespace Mono.Manager
{
    public class GUIMenuManager : MonoBehaviour
    {
        public GameGUI gameGUI;
        public PauseMenu pauseMenu;

        private void Start()
        {
            MonoInputManager.EscapeKeyPressed += StartPauseMenu;
        }

        private void StartPauseMenu(KeyCode keycode) =>
            pauseMenu.SetActive(!pauseMenu.IsActive());
    }
}