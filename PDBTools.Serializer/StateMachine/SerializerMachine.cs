using PDBTools.Models;
using PDBTools.Serializer.StateMachine.States;

namespace PDBTools.Serializer.StateMachine
{
    public class SerializerMachine
    {
        private SelectSection SelectSection { get; set; }
        private CoordinateSectionState CoordinateSectionState { get; set; }

        public PdbDataModel Serialize(List<string> lines)
        {
            var machine = new StateMachine(lines);

            SelectSection = new SelectSection(machine);
            CoordinateSectionState = new CoordinateSectionState(machine);

            machine.SelectSection = SelectSection;
            machine.CoordinateSectionState = CoordinateSectionState;

            machine.ChangeState(machine.SelectSection);

            return machine.PdbDataModel;
        }
    }
}
