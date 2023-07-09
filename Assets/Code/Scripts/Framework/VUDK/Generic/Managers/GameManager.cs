namespace VUDK.Generic.Managers
{
    using UnityEngine;
    using VUDK.Features.DialogueSystem;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.Singleton;

    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField, Header("Pooling")]
        public PoolsManager PoolsManager { get; private set; }

        [field: SerializeField, Header("Dialogue")]
        public DialogueManager DialogueManager { get; private set; }

        [field: SerializeField, Header("Event Manager")]
        public EventManager EventManager { get; private set; }
    }
}