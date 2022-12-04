using PDBTools.Models;

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
            var lineInsideModel = true;

            //Things that can be inside a MODEL
            var atomsList = new List<Atom>();

            while (lineInsideModel)
            {
                var currentLine = _stateMachine.CurrentLine;

                if (currentLine.StartsWith("ATOM"))
                {
                    atomsList.Add(new Atom{
                        Type = currentLine.Substring(76, 2).Trim(),
                        X = float.Parse(currentLine.Substring(30, 8).Replace('.',',')),
                        Y = float.Parse(currentLine.Substring(30, 8).Replace('.',',')),
                        Z = float.Parse(currentLine.Substring(30, 8).Replace('.',','))                            
                    });

                    _stateMachine.LineId++;
                    continue;
                }

                if(currentLine.StartsWith("TER")){
                    _stateMachine.LineId++;
                    continue;
                }

                if (currentLine.StartsWith("ENDMDL")){
                    _stateMachine.LineId++;
                    break;
                }

                lineInsideModel = false;
            }

            _currentModel.Atoms = atomsList;
            _stateMachine.PdbDataModel.Models.Add(_currentModel);
            _stateMachine.ChangeState(_stateMachine.SelectSection);
        }
    }
}
