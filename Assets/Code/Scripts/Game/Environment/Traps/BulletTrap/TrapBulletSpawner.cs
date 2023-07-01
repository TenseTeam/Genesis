namespace ProjectGenesis.Environment.Traps
{
    using ProjectGenesis.Generic.Factories;
    using Unity.VisualScripting;
    using UnityEngine;
    using VUDK.Extensions.Gizmos;
    using VUDK.Generic.Utility;

    public class TrapBulletSpawner : ObjectsSpawner
    {
        [SerializeField, Header("Spawn")]
        private Transform _spawnPosition;

        [SerializeField, Min(0f), Header("Trap")]
        private float _trapDamage;
        [SerializeField]
        private float _trapBulletSpeed;

        private void OnTriggerEnter(Collider other)
        {
            StartSpawner();
        }

        protected override void SpawnObject()
        {
            GameObject bullGO = TrapsFactory.CreateTrapBullet(_trapDamage, _trapBulletSpeed, out BulletTrap bull);
            bullGO.transform.position = _spawnPosition.position;
            bullGO.transform.rotation = _spawnPosition.rotation;
            bullGO.transform.localScale = _spawnPosition.lossyScale;
            bull.ShootBullet();
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(transform.position, transform.localScale);

            Gizmos.color = Color.yellow;
            GizmosExtension.DrawArrow(_spawnPosition.position, _spawnPosition.position + (_spawnPosition.forward * Vector3.Distance(transform.position, _spawnPosition.position)), 1f);
            Gizmos.DrawWireSphere(_spawnPosition.position, _spawnPosition.lossyScale.magnitude/4f);
        }
#endif
    }
}