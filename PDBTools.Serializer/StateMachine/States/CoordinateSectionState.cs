using PDBTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBTools.Serializer.StateMachine.States
{
    public class CoordinateSectionState : IState
    {
        private StateMachine _stateMachine;
        private Model _currentModel;

        public CoordinateSectionState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _currentModel = new Model();
            _currentModel.Id = _stateMachine.Lines[_stateMachine.LineId].Substring(10,4);

            _stateMachine.LineId++;
        }

        public void Execute()
        {
            var currentLine = _stateMachine.Lines[_stateMachine.LineId];
            var lineInsideModel = true;

            //Things that can be inside a MODEL

            while (lineInsideModel)
            {

                if (currentLine.StartsWith("ATOM"))
                {
                    _stateMachine.LineId++;
                    break;
                }

                lineInsideModel = false;
            }
        }
    }
}
