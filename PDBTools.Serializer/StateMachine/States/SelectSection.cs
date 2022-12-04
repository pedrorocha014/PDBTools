namespace PDBTools.Serializer.StateMachine.States
{
    public class SelectSection : IState
    {
        private StateMachine _stateMachine;

        public SelectSection(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {

        }

        public void Execute()
        {
            var section = _stateMachine.CurrentLine.Substring(0,6).Trim();
            IState nextState = null;

            switch (section)
            {
                case "MODEL": nextState = _stateMachine.CoordinateSectionState; break;
                default:
                    break;
            }

            _stateMachine.ChangeState(nextState);
        }
    }
}
