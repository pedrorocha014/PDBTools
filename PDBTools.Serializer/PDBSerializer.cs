using PDBTools.Models;
using PDBTools.Serializer.StateMachine;

namespace PDBTools.Serializer
{
    public class PDBSerializer
    {
        public PdbDataModel Serialize(List<string> lines)
        {
            List<string> line = File.ReadAllLines("/home/pedro/Downloads/2m6q(1).pdb").ToList();  
            var serializeMachine = new SerializerMachine();

            return serializeMachine.Serialize(line);
        }
    }
}