namespace VUDK.Generic.Utility
{
    using UnityEngine.SceneManagement;
    using UnityEngine;
    using System.Collections;

    public class SwitchScene : MonoBehaviour
    {
        [SerializeField]
        private float _waitTime;

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
        /// Waits for seconds and then switches to a scene.
        /// </summary>
        /// <param name="sceneToLoad">Scene to load in a string format.</param>
        public void ChangeSceneIn(string sceneToLoad)
        {
            StartCoroutine(ChangeSceneRoutine(sceneToLoad, _waitTime));
        }

        private IEnumerator ChangeSceneRoutine(string sceneToLoad, float time)
        {
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}