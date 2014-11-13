using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace armsim
{
    class Instr_Branch : Instruction
    {
        Memory instr;
        string diss = "Non-Implemented Branching Instruction";
        Registers reg;

        public override bool getStop() { return false; }
        public override string toString() { return diss; }
        public Instr_Branch(Memory inst, Registers r)
        {
            instr = inst;
            reg = r;
        }

        public override void decode()
        {
            //do fun things later
        }

        public override void exec()
        {
            //throw new NotImplementedException();
        }
    }
}
