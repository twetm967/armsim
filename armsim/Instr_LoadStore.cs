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
    class Instr_LoadStore : Instruction
    {
        Memory instr;
        //constructor
        public Instr_LoadStore(Memory inst)
        {
            instr = inst;
        }

        //determins which execute command to run
        public void decode()
        {
            
        }

        public void execLDR()
        {

        }

        public void execSTR()
        {

        }

    }
}
