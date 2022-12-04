using PDBTools.Models;
using PDBTools.Serializer.StateMachine;

namespace PDBTools.Serializer
{
    public static class PDBSerializer
    {
        public static PdbDataModel Serialize(List<string> lines)
        {
            var serializeMachine = new SerializerMachine();

            return serializeMachine.Serialize(lines);
        }
    }
}