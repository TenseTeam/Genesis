namespace ProjectGenesis.Player.PlayerSpark
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VUDK.Extensions.Gizmos;
    using VUDK.Extensions.Vectors;
    using VUDK.Generic.Structures;
    using VUDK.Generic.Systems.InputSystem;

    public class PathRunner : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private bool _canMove;

        public LoopList<Node> CurrentNodesPath { get; private set; }

        private void Update()
        {
            Move();
        }

        public void StartMove()
        {
            _canMove = true;
        }

        public void Stop()
        {
            _canMove = false;
        }

        public void SetCurrentPath(LoopList<Node> nodesPath)
        {
            if (!_canMove)
            {
                CurrentNodesPath = nodesPath;
                CurrentNodesPath.Reset();
                StartMove();
            }
        }

        private void Move()
        {
            if (!_canMove) return;

            float distanceToTarget = Vector3.Distance(transform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, CurrentNodesPath.Current.transform.position, _speed * Time.deltaTime);
        }

#if DEBUG
        private void OnDrawGizmos()
        {
            if (CurrentNodesPath != null)
            {
                Gizmos.color = Color.yellow;

                // Accessing the actual list of nodes in the CurrentNodesPath.
                List<Node> nodesList = CurrentNodesPath.List;

                for (int i = 0; i < nodesList.Count; i++)
                {
                    if (i + 1 < nodesList.Count)
                    {
                        GizmosExtension.DrawArrow(nodesList[i].transform.position, nodesList[i + 1].transform.position, 1f);
                    }
                }
            }
        }
#endif
    }
}