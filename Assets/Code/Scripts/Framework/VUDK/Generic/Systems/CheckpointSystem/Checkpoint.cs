namespace VUDK.Generic.Systems.CheckpointSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.InteractSystem;

    public class Checkpoint<T> : TriggerInteractBase where T : IEntity
    {
        public override void Interact(GameObject interactor)
        {
            if(interactor.TryGetComponent(out T ent))
            {
                CheckpointsManager.SetCheckpoint(ent, transform.position);
            }
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, transform.lossyScale);
        }
#endif
    }
}