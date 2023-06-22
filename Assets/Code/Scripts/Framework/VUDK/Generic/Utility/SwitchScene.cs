namespace VUDK.Generic.Utility
{
    using UnityEngine.SceneManagement;
    using UnityEngine;
    using System.Collections;

    public class SwitchScene : MonoBehaviour
    {
        /// <summary>
        /// Switches to a scene.
        /// </summary>
        /// <param name="sceneToLoad">Scene to load in a string format.</param>
        public void ChangeScene(string sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }

        /// <summary>
        /// Switches to a scene.
        /// </summary>
        /// <param name="sceneToLoad">Build index of the scene to load.</param>
        public void ChangeScene(int sceneToLoadBuildIndex)
        {
            SceneManager.LoadScene(sceneToLoadBuildIndex, LoadSceneMode.Single);
        }

        /// <summary>
        /// Waits N seconds and then switches to a scene.
        /// </summary>
        /// <param name="sceneToLoad">Scene to load in a string format.</param>
        /// <param name="time">Time to wait before switching to a new scene.</param>
        public void ChangeSceneIn(string sceneToLoad, float time)
        {
            StartCoroutine(ChangeSceneRoutine(time, sceneToLoad));
        }

        private IEnumerator ChangeSceneRoutine(float time, string sceneToLoad)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}