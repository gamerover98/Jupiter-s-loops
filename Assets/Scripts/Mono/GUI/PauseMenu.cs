using UnityEngine;

namespace Mono.GUI
{
    public class PauseMenu : MonoBehaviour
    {
        protected void OnEnable()
        {
            Time.timeScale = 0;
        }

        protected void OnDisable()
        {
            Time.timeScale = 1;
        }

        public void SetActive(bool active) => gameObject.SetActive(active);
        public bool IsActive() => gameObject.activeSelf;
    }
}