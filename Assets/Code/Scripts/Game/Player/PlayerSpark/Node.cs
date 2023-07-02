namespace ProjectGenesis.Player.PlayerSpark
{
    using UnityEngine;
    using VUDK.Generic.Utility;

    public class Node : TriggerEvent
    {
        protected PathRunner CurrentRunner;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.TryGetComponent(out PathRunner runner))
                OnNodeEnter(runner);
        }

        protected override void OnTriggerExit(Collider other)
        {
            base.OnTriggerExit(other);
            if (other.TryGetComponent(out PathRunner runner))
                OnNodeExit(runner);
        }

        protected virtual void OnNodeEnter(PathRunner runner)
        {
            CurrentRunner = runner;
            runner.CurrentNodesPath.Next();
        }

        protected virtual void OnNodeExit(PathRunner runner)
        {
            CurrentRunner = null;
        }
    }
}