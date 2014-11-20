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
        uint cond, test1, test2, type, rm, immed;
        bool l = false;
        CPU cpu;
        string diss = "Non-Implemented Branching Instruction";
        Registers reg;

        public override bool getStop() { return false; }
        public override string toString() { return diss; }
        public override uint getCond() {return cond;}

        public Instr_Branch(Memory inst, Registers r, CPU f)
        {
            instr = inst;
            cpu = f;
            reg = r;
        }

        public uint getChunk(uint start, uint end)
        {
            uint num = 0;
            for (uint i = start; i <= end; ++i)
            {
                if (instr.TestFlag(0, (int)i)) { num += Convert.ToUInt32(Math.Pow(2, (i - start))); }
            }
            return num;
        }

        public override void decode()
        {
            //do fun things later
            cond = instr.ReadNibble(28);
            test1 = getChunk(20, 27);
            test2 = instr.ReadNibble(4);
            if (test1 == 18 && test2 == 1)
            {
                type = 2;
                rm = instr.ReadNibble(0);
            }
            else
            {
                type = 1;
                immed = getChunk(0, 23);
                l = instr.TestFlag(0, 24);
            }
        }

        public override void exec()
        {
            switch (type)
            {
                case 1:
                    diss = "b";
                    execB();
                    break;
                case 2:
                    diss = "bx ";
                    execBX();
                    break;
            }
        }
        public void execB()
        {
            if (instr.TestFlag(0, 23)) { immed = (0x3F000000 | immed) << 2; }
            else { immed = (immed << 2); }
            uint data = reg.getRegData(15);
            cpu.setPC(data-8);
            if (l) { reg.setRegister(14, data - 4); diss += "l "; }
            else { diss += " "; }


            reg.setRegister(15, data + immed + 4);
            diss += "0x" + string.Format("{0:X8}", (data + immed + 4));

        }

        public void execBX()
        {
            cpu.setPC(reg.getRegData(15) - 8);
            reg.setRegister(15, reg.getRegData(rm) + 4);
            diss += "0x" + string.Format("{0:X8}", (reg.getRegData(rm) + 4));
        }
    }
}
