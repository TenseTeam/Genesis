namespace VUDK.Generic.Utility
{
    using UnityEngine;

    public class DestroyOnTrigger : MonoBehaviour
    {
        public string tagName = "Enemy";

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == tagName)
            {
                Destroy(gameObject);
            }
        }
    }
}