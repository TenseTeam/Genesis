namespace VUDK.Generic.Systems.CheckpointSystem
{
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;
    using VUDK.Generic.Systems.TriggerSystem;

    public abstract class Checkpoint<T> : TriggerEvent where T : IEntity
    {
        [SerializeField, Header("Offset")]
        private Vector3 _positionOffset;

        private Vector3 _savePosition => transform.position + _positionOffset;

        protected override void OnTriggerEnter(Collider interactor)
        {
            if(interactor.TryGetComponent(out T ent))
            {
                CheckpointsManager.SetCheckpoint(ent, _savePosition);
            }
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            float size = transform.localScale.magnitude / 8f;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, _savePosition);
            Gizmos.DrawWireSphere(_savePosition, size);
        }
#endif
    }
}