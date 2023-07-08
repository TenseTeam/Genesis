namespace VUDK.Features.DialogueSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.EventsSystem;
    using VUDK.Generic.Utility;
    using VUDK.Generic.Systems.EventsSystem.Events;

    [RequireComponent(typeof(Collider))]
    public class DialogueTrigger : TriggerEvent
    {
        [SerializeField]
        private Dialogue _dialogue;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            EventManager.TriggerEvent(EventKeys.DialogueEvents.OnTriggerDialouge, _dialogue);
        }
    }
}
