namespace VUDK.Generic.Utility
{
    using UnityEngine;

    public class DestroyOnCollision : MonoBehaviour
    {
        public string tagName = "Enemy";

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag(tag))
            {
                Destroy(gameObject);
            }
        }
    }
}