namespace ProjectGenesis.Player.PlayerSpark
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using VUDK.Generic.Structures;
    using VUDK.Generic.Systems.InputSystem;

    public class NodePathSelector : Node
    {
        [SerializeField, Header("Paths")]
        private LoopList<Node> _pathUp;
        [SerializeField]
        private LoopList<Node> _pathDown;
        [SerializeField]
        private LoopList<Node> _pathLeft;
        [SerializeField]
        private LoopList<Node> _pathRight;

        private void Update()
        {
            CenterRunner();
        }

        private void CenterRunner()
        {
            if(CurrentRunner)
            {
                CurrentRunner.transform.position = Vector3.Lerp(CurrentRunner.transform.position, transform.position, 2f * Time.deltaTime);
            }
        }

        private void OnSelection()
        {
            InputsManager.Inputs.PlayerSpark.Up.started += (context) => SetCurrentPath(context, _pathUp);
            InputsManager.Inputs.PlayerSpark.Down.started += (context) => SetCurrentPath(context, _pathDown);
            InputsManager.Inputs.PlayerSpark.Left.started += (context) => SetCurrentPath(context, _pathLeft);
            InputsManager.Inputs.PlayerSpark.Right.started += (context) => SetCurrentPath(context, _pathRight);
        }

        private void OnDeselection()
        {
            InputsManager.Inputs.PlayerSpark.Up.started -= (context) => SetCurrentPath(context, _pathUp);
            InputsManager.Inputs.PlayerSpark.Down.started -= (context) => SetCurrentPath(context, _pathDown);
            InputsManager.Inputs.PlayerSpark.Left.started -= (context) => SetCurrentPath(context, _pathLeft);
            InputsManager.Inputs.PlayerSpark.Right.started -= (context) => SetCurrentPath(context, _pathRight);
        }

        protected override void OnNodeEnter(PathRunner runner)
        {
            CurrentRunner = runner;
            runner.Stop();
            OnSelection();
        }

        protected virtual void SetCurrentPath(InputAction.CallbackContext context, LoopList<Node> path)
        {
            if (CurrentRunner && !path.IsEmpty())
            {
                CurrentRunner.SetCurrentPath(path);
                OnDeselection();
                CurrentRunner = null;
            }
        }
    }
}