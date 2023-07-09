namespace VUDK.Generic.Systems.CheckpointSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.TriggerSystem;

    public abstract class Checkpoint<T> : TriggerEvent where T : IEntity
    {
        protected override void OnTriggerEnter(Collider interactor)
        {
            if(interactor.TryGetComponent(out T ent))
            {
                CheckpointsManager.SetCheckpoint(ent, transform.position);
            }
        }
    }
}