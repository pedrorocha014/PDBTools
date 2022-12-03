using PDBTools.Models;

namespace PDBTools.Serializer.StateMachine
{
    public class StateMachine
    {
        public PDBModel PDBModel { get; set; }
        public IState CurrentState { get; private set; }
        public IState PreviousState { get; private set; }

        private bool inTransition = false;

        public virtual void ChangeState(IState newState)
        {
            if (CurrentState == newState || inTransition)
                return;

            ChangeStateRoutine(newState);
        }

        void ChangeStateRoutine(IState newState)
        {
            inTransition = true;

            PreviousState = CurrentState;
            CurrentState = newState;

            CurrentState?.Enter();

            inTransition = false;

            Execute();
        }

        public void Execute()
        {
            if (CurrentState != null && !inTransition)
            {
                CurrentState.Execute();
            }
        }
    }
}
