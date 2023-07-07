namespace VUDK.Generic.Utility
{
    using UnityEngine;

    public class SetCursor : MonoBehaviour
    {
        public bool enable;

        private void Awake()
        {
            Cursor.visible = enable;
        }
    }
}
