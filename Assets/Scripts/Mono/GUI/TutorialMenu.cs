using System.Collections;
using Mono.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Mono.GUI
{
    public class TutorialMenu : MonoBehaviour
    {
        [SerializeField] private Image commandsSuggestionImage;
        [SerializeField] private float commandsSuggestionTtl = 4F;

        [SerializeField] private GameObject notCollectAllCapsules;

        public void ShowCommandsSuggestions()
        {
            commandsSuggestionImage.gameObject.SetActive(true);
            StartCoroutine(HideCommandsSuggestion());
        }

        private IEnumerator HideCommandsSuggestion()
        {
            yield return new WaitForSeconds(commandsSuggestionTtl);
            commandsSuggestionImage.gameObject.SetActive(false);
        }

        public void ShowNotCollectAllCapsules()
        {
            notCollectAllCapsules.SetActive(true);
            MonoInputManager.SpaceKeyPressed += HideNotCollectAllCapsules;
            Time.timeScale = 0;
        }

        public void HideNotCollectAllCapsules()
        {
            notCollectAllCapsules.SetActive(false);
            MonoInputManager.SpaceKeyPressed -= HideNotCollectAllCapsules;
            Time.timeScale = 1;
        }

        public bool IsNotCollectAllCapsulesActive() => notCollectAllCapsules.activeSelf;

        public void SetActive(bool active) => gameObject.SetActive(active);
        public bool IsActive() => gameObject.activeSelf;
    }
}