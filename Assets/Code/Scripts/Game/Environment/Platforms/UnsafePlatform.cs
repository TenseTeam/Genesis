namespace ProjectGenesis.Environment.Platforms
{
    using UnityEngine;
    using VUDK.Generic.Utility;

    public class UnsafePlatform : Platform
    {
        [SerializeField, Header("Looper")]
        public GameobjectEnablerLoop _gameobjectLooper;

        protected override void OnEntityEnterPlatform(Collision entityCollision)
        {
            base.OnEntityEnterPlatform(entityCollision);
            _gameobjectLooper.StartLoop();
        }
    }
}
