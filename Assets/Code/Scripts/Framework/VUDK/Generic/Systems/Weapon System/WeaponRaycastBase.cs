﻿namespace VUDK.Generic.Systems.WeaponSystem
{
    using System;
    using UnityEngine;
    using VUDK.Generic.Systems.EntitySystem.Interfaces;

    public class WeaponRaycastBase : WeaponBase
    {
        [SerializeField, Header("Raycast")]
        protected float RaycastShootRange;

        [SerializeField]
        private LayerMask _rayShootableMask;

        public static event Action<Vector3> OnBulletHit;

        protected override void BulletGeneration()
        {
            base.BulletGeneration();
            foreach (Transform barrel in BarrelsPoints)
            {
#if DEBUG
                Debug.DrawRay(barrel.position, barrel.forward * RaycastShootRange);
#endif
                if (Physics.Raycast(barrel.position, barrel.forward, out RaycastHit hit, RaycastShootRange, _rayShootableMask))
                {
                    OnBulletHit?.Invoke(hit.point);

                    if (hit.transform.TryGetComponent(out IVulnerable ent))
                        ent.TakeDamage(Damage.Random());
                }
            }
        }
    }
}