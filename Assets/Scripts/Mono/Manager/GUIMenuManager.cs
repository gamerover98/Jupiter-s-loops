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
            MonoInputManager.EscapeKeyPressed += OpenOrClosePauseMenu;
        }

        public void OpenOrClosePauseMenu()
        {
            pauseMenu.SetActive(!pauseMenu.IsActive());
            gameGUI.SetActive(!pauseMenu.IsActive());
        }
    }
}