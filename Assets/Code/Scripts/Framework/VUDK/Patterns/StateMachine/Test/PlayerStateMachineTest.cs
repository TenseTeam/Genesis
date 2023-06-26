namespace VUDK.Patterns.StateMachine
{
    using VUDK.Generic.Systems.InputSystem;

    public enum StatesKey
    {
        Idle,
        Walk,
        Run
    }

    public enum LolKeys
    {
        Lol,
        ciao,
        bello
    }

    public class PlayerStateMachineTest : StateMachine<StatesKey, InputContext>
    {
        TestContext<LolKeys, Context, StatesKey, InputContext> context;

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        //private void Awake()
        //{
        //    context = new TestContext<LolKeys, Context, StatesKey, InputContext>(new SubStateMachine<LolKeys, Context, StatesKey, InputContext>());
        //}

        //public override void Init()
        //{
        //    AddState(StatesKey.Idle, new PlayerJumpStateTest(this, playerContext));
        //}
    }
}