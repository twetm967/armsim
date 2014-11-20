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
        bool p, u, b, w, l, registerSh = false;
        uint cond, rn, type, rd = 0;
        OperandTwo op;
        string diss = "Non-Implemented Load/Store Instruction";
        Memory instr, mem;
        CPU cpu;
        Registers reg;
        //constructor
        public override bool getStop() { return false; }
        public override uint getCond() { return cond; }
        public Instr_LoadStore(Memory inst, Registers r, Memory m, CPU f)
        {
            instr = inst;
            reg = r;
            cpu = f;
            mem = m;
        }
        public override string toString() { return diss; }

        //determins which execute command to run
        public override void decode()
        {
            //decode fun things
            cond = instr.ReadNibble(28);
            registerSh = instr.TestFlag(0, 25);
            p = instr.TestFlag(0, 24);
            u = instr.TestFlag(0, 23);
            b = instr.TestFlag(0, 22);
            w = instr.TestFlag(0, 21);
            l = instr.TestFlag(0, 20);
            rn = instr.ReadNibble(16);
            rd = instr.ReadNibble(12);
            op = new OperandTwo(instr, registerSh, reg);
            uint num = op.getChunk(25, 27);
            if (num == 4)
            {
                if (l) { type = 3; }
                if (!l) { type = 4; }
            }
            else
            {
                if (l) { type = 1; }
                if (!l) { type = 2; }
            }
            

        }

        public override void exec()
        {
            //throw new NotImplementedException();
            switch (type)
            {
                case 1:
                    diss = "ldr";
                    execLDR();
                    break;
                case 2:
                    diss = "str";
                    execSTR();
                    break;
                case 3:
                    diss = "ldm";
                    execLDM();
                    break;
                case 4:
                    diss = "stm";
                    execSTM();
                    break;
            }


        }

        //add more instructions
        public void execLDR()
        {

            uint address = 0;
            uint op2 = op.getOp();
            int temp = Convert.ToInt32(op2);
            int data = 0;
            uint regData = 0;

            if (!u) { data = temp * -1; }

            if (p) { address = reg.getRegData(rn) + (uint)data; }
            else { address = reg.getRegData(rn); }

            if (b) { regData = mem.ReadByte(address); diss += "b "; }
            else { regData = mem.ReadWord(address);  }

            diss += " r" + rd.ToString();
            reg.setRegister(rd, regData);

            if (p && w) { reg.setRegister(rn, address); diss += "!"; }

            diss += ", [r" + rn.ToString() + op.getdiss() + "]";


        }

        public void execSTR()
        {
            uint address = 0;
            uint op2 = op.getOp();
            int temp = Convert.ToInt32(op2);
            int data = 0;
            uint regData = 0;

            if (!u) { data = temp * -1; }
            else { data = (int)op2; }
            if (p) { address = reg.getRegData(rn) + (uint)data; }
            else { address = reg.getRegData(rn); }



            if (b) { regData = reg.ReadByte(rd * 4); diss += "b "; }
            else { regData = reg.getRegData(rd);}

            diss += " r" + rd.ToString();

            mem.WriteWord(address, regData);
            if (p && w) { reg.setRegister(rn, address); diss += "!"; }

            diss += ", [r" + rn.ToString() + op.getdiss() + "]";
        }

        public void execLDM()
        {
            uint op2 = op.getNum();
            uint addr = reg.getRegData(rn);
            bool incAfter = false;
            bool decBefore = false;

            if (!p && u) { incAfter = true; diss += "fd "; }
            if (p && !u) { decBefore = true; addr = addr - (op2 * 4); diss += "ea "; }

            string registers = "{";
            bool first = true;
            for (int i = 0; i < 16; ++i)
            {
                if (instr.TestFlag(0, i))
                {
                    if (!first)
                    {
                        registers += ", ";
                    }
                    else { first = false; }
                    registers += "r" + i.ToString();
                    reg.setRegister((uint)i, mem.ReadWord(addr));
                    addr += 4;
                }
            }
            registers += "}";
            if (rn == 13)
            {
                diss += "sp";
            }
            else
            {
                diss += "r" + rn.ToString();
            }
            if (w && incAfter)
            {
                reg.setRegister(rn, reg.getRegData(rn) + (op2 * 4));
                diss += "!";
            }
            else if (u && decBefore)
            {
                reg.setRegister(rn, reg.getRegData(rn) - (op2 * 4));
                diss += "1";
            }

            diss += ", " + registers;
        }

        public void execSTM()
        {
            uint op2 = op.getNum();
            uint addr = reg.getRegData(rn);
            bool incAfter = false;
            bool decBefore = false;

            if (!p && u) { incAfter = true; diss += "ia ";  }
            if (p && !u) { decBefore = true; addr = addr - (op2 * 4); diss += "fd "; }
            string registers = "{";
            bool first = true;
            for (int i = 0; i < 16; ++i)
            {
                if (instr.TestFlag(0, i))
                {
                    if (!first)
                    {
                        registers += ", ";
                    }
                    else { first = false; }
                    registers += "r" + i.ToString();
                    mem.WriteWord(addr, reg.getRegData((uint)i));
                    addr += 4;
                }
            }
            registers += "}";
            if (rn == 13)
            {
                diss += "sp";
            }
            else
            {
                diss += "r" + rn.ToString();
            }

            if (w && incAfter)
            {
                reg.setRegister(rn, reg.getRegData(rn) + (op2 * 4));
                diss += "!";
            }
            else if (w && decBefore)
            {
                reg.setRegister(rn, reg.getRegData(rn) - (op2 * 4));
                diss += "!";
            }
            diss += ", " + registers;
        }
    }

}

