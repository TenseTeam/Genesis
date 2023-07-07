﻿namespace VUDK.Generic.Managers
{
    using UnityEngine;
    using VUDK.Patterns.ObjectPool;
    using VUDK.Patterns.Singleton;

    public class GameManager : PersistentSingleton<GameManager>
    {
        [field: SerializeField, Header("Pooling")]
        public PoolsManager PoolsManager { get; private set; }
    }
}