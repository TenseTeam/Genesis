namespace VUDK.Tools.Debug
{
    using UnityEditor;
    using UnityEngine;

#if DEBUG
    public class FPSLocker : EditorWindow
    {
        private int _targetFPS = 60;

        [MenuItem("Tools/VUDK/Debug/FPSTool")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(FPSLocker), false, "FPS Lock Tool");
        }

        private void OnGUI()
        {
            GUILayout.Label("FPS Lock Settings", EditorStyles.boldLabel);

            _targetFPS = EditorGUILayout.IntField("Target FPS", _targetFPS);

            if (GUILayout.Button("Lock"))
                ApplyTargetFPS(_targetFPS);
            if (GUILayout.Button("Unlock"))
                Unlock();
        }

        private void ApplyTargetFPS(int fps)
        {
            Application.targetFrameRate = fps;
            Debug.Log("FPS capped to: " + fps);
        }

        private void Unlock()
        {
            Application.targetFrameRate = 0;
            Debug.Log("FPS Uncapped");
        }
    }
#endif
}