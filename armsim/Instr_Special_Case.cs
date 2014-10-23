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
        int type;
        public Instr_Special_Case(Memory inst, Registers r, int num)
        {
            instr = inst;
            reg = r;
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

        }

        public void execMUL()
        {

        }
    }
}
