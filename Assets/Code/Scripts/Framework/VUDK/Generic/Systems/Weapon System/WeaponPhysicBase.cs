namespace VUDK.Generic.Systems.WeaponSystem
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using VUDK.Generic.Systems.WeaponSystem.Bullets;

    public abstract class WeaponPhysicBase : WeaponBase
    {
        [SerializeField, Header("Bullet")]
        protected float BulletSpeed;
        [SerializeField]
        private bool _alternateBarrel;

        private int _currentBarrelIndex = 0;

        protected override void BulletGeneration()
        {
            base.BulletGeneration();
            if (_alternateBarrel)
            {
                SpawnBullet(BarrelsPoints[_currentBarrelIndex]);
                _currentBarrelIndex = (_currentBarrelIndex + 1) % BarrelsPoints.Length;
            }
            else
            {
                foreach (Transform barrel in BarrelsPoints)
                    SpawnBullet(barrel);
            }
        }

        /// <summary>
        /// Spawns the bullet in a barrel transform position.
        /// </summary>
        /// <param name="barrel">Barrel's <see cref="Transform"/>.</param>
        /// <returns>Spawned Bullet.</returns>
        protected virtual GameObject SpawnBullet(Transform barrel)
        {
            GameObject goBull = CreateBullet();
            goBull.transform.SetPositionAndRotation(barrel.transform.position, barrel.transform.rotation);

            if(goBull.TryGetComponent(out Bullet bull))
            {
                bull.Init(Damage.Random(), BulletSpeed);
                bull.ShootBullet();
            }

            return goBull;
        }

        /// <summary>
        /// Creates the bullet gameobject.
        /// </summary>
        /// <returns>Created Bullet.</returns>
        protected abstract GameObject CreateBullet();
    }
}