namespace VUDK.Features.DialogueSystem
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.EventsSystem.Events;
    using VUDK.Generic.Systems.TriggerSystem;

    [RequireComponent(typeof(Collider))]
    public class DialogueTrigger : TriggerEvent
    {
        [SerializeField]
        private Dialogue _dialogue;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            GameManager.Instance.EventManager.TriggerEvent(EventKeys.DialogueEvents.OnTriggeredDialouge, _dialogue);
        }
    }
}
