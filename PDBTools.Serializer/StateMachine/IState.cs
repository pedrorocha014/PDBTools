using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDBTools.Serializer.StateMachine
{
    public interface IState
    {
        void Enter();
        public void Execute();
    }
}
