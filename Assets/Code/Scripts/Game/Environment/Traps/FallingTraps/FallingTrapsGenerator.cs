namespace ProjectGenesis.Environment.Traps
{
    using System.Collections.Generic;
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Utility;
    using ProjectGenesis.Generic.Factories;
    using VUDK.Extensions.Gizmos;

    public class FallingTrapsGenerator : ObjectsSpawner
    {
        [SerializeField]
        private List<Transform> _positions;

        [SerializeField, Min(0f)]
        private float _disposeTime;

        private void Start()
        {
            StartSpawner();
        }

        protected override void SpawnObject()
        {
            GameObject trap = TrapsFactory.Create(_disposeTime);
            trap.transform.SetPosition(_positions[Random.Range(0, _positions.Count)].position);   
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            if(_positions.Count > 0)
            {
                foreach(Transform trans in _positions)
                {
                    float size = transform.lossyScale.magnitude / 4f;
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(trans.position, size);
                    Vector3 endPos = transform.position - Vector3.up / size;
                    Gizmos.DrawRay(trans.position, -trans.up * size * 4f);
                }
            }
        }
#endif
    }
}