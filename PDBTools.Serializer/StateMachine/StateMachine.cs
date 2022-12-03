using PDBTools.Models;

namespace PDBTools.Serializer.StateMachine
{
    public class StateMachine
    {
        public PdbDataModel PdbDataModel { get; set; }
        public List<string> Lines { get; set; }
        public int LineId = 0;        

        public IState CurrentState { get; private set; }
        public IState PreviousState { get; private set; }

        private bool inTransition = false;

        #region 'States'
        public IState CoordinateSectionState { get; set; }
        public IState SelectSection { get; set; }
        #endregion


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
