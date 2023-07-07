namespace ProjectGenesis.Player
{
    using UnityEngine;
    using VUDK.Generic.Systems.MovementSystem;
    using VUDK.Patterns.StateMachine;
    using VUDK.Generic.Systems.InputSystem;
    using VUDK.Generic.Systems.CheckpointSystem;
    using ProjectGenesis.Settings;
    using ProjectGenesis.Player.States.Factory;
    using ProjectGenesis.Generic.Factories;
    using ProjectGenesis.Player.Controller;
    using ProjectGenesis.Player.States;
    using UnityEngine.InputSystem;
    using System;

    [RequireComponent(typeof(MovementBase))]
    [RequireComponent(typeof(PlayerGraphicsController))]
    [RequireComponent(typeof(PlayerStatus))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : StateMachine, Interfaces.IPlayer
    {
        protected Rigidbody Rigidbody;
        protected Animator Animator;

        public PlayerMovement Movement { get; protected set; }
        public PlayerGraphicsController Graphics { get; protected set; }
        public PlayerEntity Entity { get; protected set; }
        public PlayerStatus Status { get; protected set; }

        protected virtual void Awake()
        {
            TryGetComponent(out PlayerMovement movement);
            TryGetComponent(out PlayerGraphicsController graphics);
            TryGetComponent(out PlayerEntity entity);
            TryGetComponent(out PlayerStatus status);
            TryGetComponent(out Rigidbody);
            TryGetComponent(out Animator);

            Movement = movement;
            Graphics = graphics;
            Entity = entity;
            Status = status;

            Entity.Init(this, transform.position);
            Movement.Init(Rigidbody, GameSettings.GroundLayers);
            Graphics.Init(Animator);

            CheckpointsManager.SetCheckpoint(Entity, transform.position);
            Init();
        }

        public override void Init()
        {
            PlayerContext context = ContextFactory.Create(InputsManager.Inputs, Movement, Graphics);

            PlayerGroundState groundState = PlayerStatesFactory.Create(PlayerStateKey.Ground, this, context) as PlayerGroundState;
            PlayerAirState airState = PlayerStatesFactory.Create(PlayerStateKey.Air, this, context) as PlayerAirState;
            PlayerJumpState jumpState = PlayerStatesFactory.Create(PlayerStateKey.Jump, this, context) as PlayerJumpState;
            PlayerGrapRopeState grapState = PlayerStatesFactory.Create(PlayerStateKey.GrapRope, this, context) as PlayerGrapRopeState;

            AddState(PlayerStateKey.Ground, groundState);
            AddState(PlayerStateKey.Jump, jumpState);
            AddState(PlayerStateKey.Air, airState);
            AddState(PlayerStateKey.GrapRope, grapState);

            ChangeState(PlayerStateKey.Ground);
        }

        public void Reset()
        {
            Status.Clear();
        }
    }
}