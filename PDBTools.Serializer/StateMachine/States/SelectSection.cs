using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBTools.Serializer.StateMachine.States
{
    public class SelectSection : IState
    {
        private StateMachine _stateMachine;

        public SelectSection(StateMachine stateMachine, IState coordinateSectionState)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            if (_stateMachine.LineId > 0)
            {
                _stateMachine.LineId++;
            }
        }

        public void Execute()
        {
            var section = _stateMachine.Lines[_stateMachine.LineId].Substring(0,6);
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
