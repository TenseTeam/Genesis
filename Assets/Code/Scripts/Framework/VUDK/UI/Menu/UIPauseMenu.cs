namespace VUDK.UI.Menu
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VUDK.Generic.Systems.InputSystem;

    public class UIPauseMenu : MonoBehaviour
    {
        [SerializeField, Header("Pause Panel")]
        private RectTransform _pausePanel;

        private bool _isPaused;

        private void Awake() => DisablePause();

        private void OnEnable()
        {
            InputsManager.Inputs.UI.PauseMenuToggle.started += PauseToggle;
        }

        private void OnDisable()
        {
            InputsManager.Inputs.UI.PauseMenuToggle.started -= PauseToggle;
        }

        /// <summary>
        /// Pauses and unpauses the game by setting the time scale.
        /// </summary>
        public void PauseToggle()
        {
            if (_isPaused)
                DisablePause();
            else
                EnablePause();

            _isPaused = !_isPaused;
        }

        public void EnablePause()
        {
            Debug.Log("hey?");
            _isPaused = true;
            _pausePanel.gameObject.SetActive(true);
            InputsManager.Inputs.Disable();
            InputsManager.Inputs.UI.Enable();
            SetTimeScale(0f);
        }

        public void DisablePause()
        {
            _isPaused = false;
            _pausePanel.gameObject.SetActive(false);
            InputsManager.Inputs.Enable();
            SetTimeScale(1f);
        }

        private void PauseToggle(InputAction.CallbackContext context)
        {
            PauseToggle();
        }

        private void SetTimeScale(float timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}