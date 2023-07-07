namespace VUDK.Patterns.ObjectPool
{
    using UnityEngine;
    using VUDK.Generic.Serializable;

    public class PoolsManager : MonoBehaviour
    {
        [field: SerializeField]
        public SerializableDictionary<string, Pool> Pools { get; private set; }
    }
}