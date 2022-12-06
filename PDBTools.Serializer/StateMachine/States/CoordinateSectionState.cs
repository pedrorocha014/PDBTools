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
            var anisouList = new List<Anisou>();
            var hetatmList = new List<Hetatm>();
            var tersList = new List<Ter>();

            while (lineInsideModel)
            {
                var currentLine = _stateMachine.CurrentLine;

                if (currentLine.StartsWith("ATOM"))
                {
                    atomsList.Add(BuildAtom(currentLine));
                    _stateMachine.LineId++;
                    continue;
                }

                if(currentLine.StartsWith("HETATM")){
                    hetatmList.Add(BuildHetatm(currentLine));
                    _stateMachine.LineId++;
                    continue;
                }
                
                if(currentLine.StartsWith("ANISOU")){
                    anisouList.Add(BuildAnisou(currentLine));
                    _stateMachine.LineId++;
                    continue;
                }

                if(currentLine.StartsWith("TER")){
                    tersList.Add(BuildTer(currentLine));
                    _stateMachine.LineId++;
                    continue;
                }

                if (currentLine.StartsWith("ENDMDL")){
                    _stateMachine.LineId++;
                    break;
                }

                lineInsideModel = false;
            }

            _currentModel.Atom = atomsList;
            _currentModel.Anisou = anisouList;
            _currentModel.Hetatm = hetatmList;
            _currentModel.Ter = tersList;

            _stateMachine.PdbDataModel.Models.Add(_currentModel);
            _stateMachine.ChangeState(_stateMachine.SelectSection);
        }
    
        private Atom BuildAtom(string line){
            return new Atom{
                Serial = int.Parse(line.Substring(6, 5)),
                Name = line.Substring(12, 4).Trim(),
                AltLoc = line.Substring(16, 1).Trim(),
                ResName = line.Substring(17, 3).Trim(),
                ChainID = line.Substring(21, 1).Trim(),
                ResSeq = int.Parse(line.Substring(22, 4)),
                ICode = line.Substring(26, 1).Trim(),
                X = float.Parse(line.Substring(30, 8).Replace('.',',')),
                Y = float.Parse(line.Substring(38, 8).Replace('.',',')),
                Z = float.Parse(line.Substring(46, 8).Replace('.',',')),
                Occupancy = line.Substring(54, 6).Trim(),
                TempFactor = line.Substring(60, 6).Trim(),
                Element = line.Substring(76, 2).Trim(),
                Charge = line.Substring(78, 2).Trim()
            };
        }

        private Ter BuildTer(string line){
            return new Ter{
                Serial = int.Parse(line.Substring(6, 5)),
                ResName = line.Substring(17, 3).Trim(),
                ChainId = line.Substring(21, 1).Trim(),
                ResSeq = int.Parse(line.Substring(22, 4)),
                ICode = line.Substring(26, 1).Trim()
            };
        }
    
        private Anisou BuildAnisou(string line){
            return new Anisou(){};
        }

        private Hetatm BuildHetatm(string line){
            return new Hetatm(){};
        }
    }
}