namespace VUDK.Generic.Utility
{
    using System.Collections;
    using UnityEngine;
    using VUDK.Generic.Serializable.Mathematics;

    public abstract class ObjectsSpawner : MonoBehaviour
    {
        [SerializeField, Min(0), Header("Rate")]
        private float _spawnRate = 1f;
        //[SerializeField]
        //private Range<int> _dropRate;

        /// <summary>
        /// Begins the spawn.
        /// </summary>
        public virtual void StartSpawner()
        {
            StartCoroutine(SpawObjectsRoutine());
        }

        /// <summary>
        /// Spawns the GameObject.
        /// </summary>
        /// <returns>Spawned GameObject.</returns>
        protected abstract void SpawnObject();

        /// <summary>
        /// Starts the spawn routine.
        /// </summary>
        private IEnumerator SpawObjectsRoutine()
        {
            while (true)
            {
                //for(int i = 0; i < _dropRate.Random(); i++)
                SpawnObject();
                yield return new WaitForSeconds(_spawnRate);
            }
        }
    }
}