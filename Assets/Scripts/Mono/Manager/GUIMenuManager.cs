using Mono.GUI;
using UnityEngine;

namespace Mono.Manager
{
    public class GUIMenuManager : MonoBehaviour
    {
        public GameGUI gameGUI;
        public PauseMenu pauseMenu;
        public EndGameMenu endGameMenu;
        public TutorialMenu tutorialMenu;

        private void Start()
        {
            MonoInputManager.EscapeKeyPressed += OpenOrClosePauseMenu;
        }

        private void OnDestroy()
        {
            MonoInputManager.EscapeKeyPressed -= OpenOrClosePauseMenu;
        }

        public void OpenOrClosePauseMenu()
        {
            if (tutorialMenu.IsNotCollectAllCapsulesActive()) return;
                
            pauseMenu.SetActive(!pauseMenu.IsActive());
            gameGUI.SetActive(!pauseMenu.IsActive());
            tutorialMenu.SetActive(gameGUI.IsActive());
        }
    }
}