using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{
    class OperandTwo
    {
         Memory instr;
        Registers reg;
        bool regShift = false;
        bool ROR = true;
        uint shiftType, Rm, immed,num, shiftAm = 0;

        public OperandTwo(Memory mem, bool b, Registers r)
        {
            instr = mem;
            regShift = b;
            reg = r;
            parse();

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
        public void parse()
        {
            if (getChunk(25, 27) == 4)
            {
                for (int i = 0; i < 16; ++i)
                {
                    if (instr.TestFlag(0, i)){ ++num;}
                }
            }
            else
            {

                if (regShift) //shift by register
                {
                    Rm = instr.ReadNibble(0);
                    shiftType = getChunk(5, 6);
                    shiftAm = getChunk(7, 11);
                }
                else //shift by immediate
                {
                    //get the 12-bit immediate
                    immed = getChunk(0, 11);
                }
            }
        }
        public uint getOp()
        {
            uint op2 = 0;
            if (!regShift)
            {
                return immed;
            }
            else
            {
                uint data = reg.getRegData(Rm);
                switch (shiftType)
                {
                    case 0: //LSL
                        op2 = (data << Convert.ToInt32(shiftAm));
                        break;
                    case 1: //ASR
                        //int info = (int)data;

                        op2 = (data >> Convert.ToInt32(shiftAm));
                        break;
                    case 2: //LSR
                        op2 = (uint)(((int)data >> (int)shiftAm));
                        break;
                    case 3: //ROR
                        op2 = (data >> Convert.ToInt32(shiftAm)) | (data << (32 - Convert.ToInt32(shiftAm)));
                        break;
                }
                return op2;
            }

            
        }
        //*********************GETTERS************************//
        public uint getRm() { return Rm; }
        public bool getROR() { return ROR; }
        public uint getImmed() { return immed; }
        public uint getShiftAm() { return shiftAm; }
        public uint getShiftType() { return shiftType; }
        public uint getNum() { return num; }
        //****************************************************//
    }
}
