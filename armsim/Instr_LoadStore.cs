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
    class Instr_LoadStore //: Instruction
    {
        Memory instr;
        Registers reg;
        //constructor
        public Instr_LoadStore(Memory inst, Registers r)
        {
            instr = inst;
            reg = r;
        }

        //determins which execute command to run
        public void decode()
        {
            //decode fun things
        }
        
        //add more instructions
        public void execLDR()
        {

        }

        public void execSTR()
        {

        }

    }
}
