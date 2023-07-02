namespace ProjectGenesis.Environment.GrapplingSystem
{
    using Unity.VisualScripting;
    using UnityEngine;
    using VUDK.Generic.Systems.InteractSystem;

    public class GrapplingHook : InteractableBase
    {
        [SerializeField, Min(0f)]
        private float _launchForce;
        [SerializeField]
        private Transform _hook;

        private Transform _entityAttached;

        public bool IsAttached => _entityAttached;

        public override void Interact(InteractorBase interactor)
        {
            if (!IsAttached)
                Attach(interactor.transform);
            else if (interactor.TryGetComponent(out Rigidbody body))
            {
                Launch(body);
            }
        }

        private void Update()
        {
            if (IsAttached)
            {
                _entityAttached.position = _hook.position;
            }
        }

        private void Attach(Transform toAttach)
        {
            _entityAttached = toAttach;
        }

        private void Detach()
        {
            _entityAttached = null;
        }

        private void Launch(Rigidbody bodyToLaunch)
        {
            Detach();
            bodyToLaunch.velocity = Vector3.zero;
            bodyToLaunch.AddForce(transform.up * _launchForce, ForceMode.Impulse);
        }
    }
}
