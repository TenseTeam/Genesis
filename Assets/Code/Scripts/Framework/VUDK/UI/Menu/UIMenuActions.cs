namespace VUDK.UI.Menu
{
    using ProjectGenesis.Constants.Events;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Utility;

    [RequireComponent(typeof(SwitchScene))]
    public class UIMenuActions : MonoBehaviour
    {
        private SwitchScene _sceneSwitcher;

        private void Awake()
        {
            TryGetComponent(out _sceneSwitcher);
        }

        public void ChangeScene(int sceneIndex)
        {
            ClickButton();
            _sceneSwitcher.WaitChangeScene(sceneIndex);
        }

        public void ExitApplication()
        {
            ClickButton();
            Application.Quit();
        }

        public void ClickButton()
        {
            EventManager.TriggerEvent(EventKeys.OnUIButtonClick);
        }
    }
}