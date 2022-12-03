using PDBTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBTools.Serializer.StateMachine
{
    public class SerializerMachine
    {
        //public OctavesFinals OctavesFinals { get; set; }
        //public QuarterFinals QuarterFinals { get; set; }
        //public Finals Finals { get; set; }
        //public CupMachine CupMachine { get; set; }

        public PdbDataModel Serialize(List<string> lines)
        {

            var machine = new StateMachine();

            machine.PdbDataModel = new PdbDataModel();
            machine.Lines = lines;

            Finals = new Finals(CupMachine);
            QuarterFinals = new QuarterFinals(CupMachine, Finals);
            OctavesFinals = new OctavesFinals(CupMachine, QuarterFinals);

            machine.ChangeState(OctavesFinals);

            return machine.PdbDataModel;
        }
    }
}
