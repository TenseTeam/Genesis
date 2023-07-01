namespace ProhectGenesis.Environment.Traps
{
    using System.Collections.Generic;
    using UnityEngine;
    using VUDK.Extensions.Transform;
    using VUDK.Generic.Utility;
    using ProjectGenesis.Generic.Factories;

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
    }
}