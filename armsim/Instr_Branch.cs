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
        public Instr_Branch(Memory inst)
        {
            instr = inst;
        }
    }
}
