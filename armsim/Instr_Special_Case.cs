using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class Instr_Special_Case : Instruction
    {
        Memory instr;
        Registers reg;
        bool stop = false;
        int type;
        string diss = "Non-Implemented Special Instruction";
        uint rd;
        uint rs;
        uint rm;

        public override bool getStop() { return stop; }
        public override string toString() { return diss; }
       
        public Instr_Special_Case(Memory inst, Registers r, int num)
        {
            instr = inst;
            reg = r;
            type = num;
        }

        public static Instr_Special_Case isSpecial(Memory inst, Registers r)
        {
            if(inst.ReadNibble(24) == 15) //SWI
            {
                return new Instr_Special_Case(inst, r, 1);
            }
            else if(checkMUL(inst)) //MUL
            {
                return new Instr_Special_Case(inst, r, 2);
            }
            return null;
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
        public static bool checkMUL(Memory inst)
        {
            uint num1 = 0;
            uint num2 = 0;
            for (int i = 21; i < 28; ++i) 
            {
                if (inst.TestFlag(0, i) == true) { num1 += Convert.ToUInt32(Math.Pow(2, i-21)); }
            }
            num2 = inst.ReadNibble(4);
            if (num1 == 0 && num2 == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void decode()
        {
            switch(type)
            {
                case 1:
                    //decode for SWI
                    break;
                case 2:
                    //instr.PrintArray();
                    rd = instr.ReadNibble(16);
                    rs = instr.ReadNibble(8);
                    rm = instr.ReadNibble(0);
                    //decode for MUL
                    break;
            }
        }

        public override void exec()
        {
            switch (type)
            {
                case 1:
                    execSWI();
                    break;
                case 2:
                    execMUL();
                    break;
            }
        }

        public void execSWI()
        {
            stop = true;
            diss = "swi " + getChunk(0, 23).ToString();
        }

        public void execMUL()
        {
            uint data = reg.getRegData(rs) * reg.getRegData(rm);
            reg.setRegister(rd, data);
            diss = "mul r" + rd.ToString() + ", r" + rm.ToString() + ", r" + rs.ToString(); 
        }
    }
}
