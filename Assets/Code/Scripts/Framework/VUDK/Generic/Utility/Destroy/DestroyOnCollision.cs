namespace VUDK.Generic.Utility
{
    using UnityEngine;

    public class DestroyOnCollision : MonoBehaviour
    {
        [SerializeField]
        private string _tagName;

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(_tagName))
            {
                Destroy(gameObject);
            }
        }
    }
}