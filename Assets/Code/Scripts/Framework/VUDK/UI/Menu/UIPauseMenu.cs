namespace VUDK.UI.Menu
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class UIPauseMenu : MonoBehaviour
    {
        [field: SerializeField, Header("UI")]
        public GameObject PanelPauseUI { get; set; }
        [field: SerializeField]
        public GameObject PauseMainUI { get; set; }

        public bool IsPaused { get; private set; }

        public Action OnPause { get; set; }

        /// <summary>
        /// Pauses the game by setting the time scale.
        /// </summary>
        public void PauseToggle()
        {
            IsPaused = !IsPaused;

            if (IsPaused)
                SetTimeScale(0);
            else
                SetTimeScale(1);

            TogglePlayerInputs();
            PanelPauseUI.SetActive(IsPaused);

            if (IsPaused)
                ResetPauseMenu();
        }

        private void TogglePlayerInputs()
        {
            OnPause?.Invoke();
        }

        public void ResetPauseMenu()
        {
            for(int i = 0; i < PanelPauseUI.transform.childCount; i++)
            {
                PanelPauseUI.transform.GetChild(i).gameObject.SetActive(false);
            }

            PauseMainUI.SetActive(true);
        }

        public void SetTimeScale(int t)
        {
            Time.timeScale = t;
        }
    }
}