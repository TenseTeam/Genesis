namespace ProjectGenesis.Generic.Factories
{
    using UnityEngine;
    using VUDK.Generic.Managers;
    using ProjectGenesis.Constants;
    using ProjectGenesis.Environment.Traps;

    public static class TrapsFactory
    {
        public static GameObject Create(float disposeTime)
        {
            GameObject trapGO =  GameManager.Instance.PoolsManager.Pools[Constants.Pools.FallingTraps].Get();
            if (trapGO.TryGetComponent(out FallingTrap trap))
                trap.Init(disposeTime);
            
            return trapGO;
        }
    }
}