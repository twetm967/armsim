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
        string si, diss = "";
        uint shiftType, Rm, immed,num, shiftAm = 0;

        public OperandTwo(Memory mem, bool b, Registers r)
        {
            instr = mem;
            regShift = b;
            reg = r;
            if (instr.TestFlag(0, 23) == false) { si = "-"; }
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
                uint holder = getChunk(0, 11);
                if (holder != 0)
                {
                    diss = ", #" + si + Convert.ToString(holder);
                }else
                {
                    diss = "";
                }
            }
            else
            {

                if (regShift) //shift by register
                {
                    Rm = instr.ReadNibble(0);
                    shiftType = getChunk(5, 6);
                    shiftAm = getChunk(7, 11);
                    diss = ", " + si + "r" + Rm.ToString();
                }
                else //shift by immediate
                {
                    //get the 12-bit immediate
                    immed = getChunk(0, 11);
                    if (immed != 0)
                    {
                        diss = ", #" + immed.ToString();
                    }
                    else
                    {
                        diss = "";
                    }
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
                        if (shiftAm != 0) { diss += ", lsl " + "#" + shiftAm.ToString(); }
                        break;
                    case 1: //LSR
                        op2 = (data >> Convert.ToInt32(shiftAm));
                        if (shiftAm != 0) { diss += ", lsr " + "#" + shiftAm.ToString(); }
                        break;
                    case 2: //ASR
                        op2 = (uint)(((int)data >> (int)shiftAm));
                        if (shiftAm != 0) { diss += ", asr " + "#" + shiftAm.ToString(); }
                        break;
                    case 3: //ROR
                        op2 = (data >> Convert.ToInt32(shiftAm)) | (data << (32 - Convert.ToInt32(shiftAm)));
                        if (shiftAm != 0) { diss += ", ror " + "#" + shiftAm.ToString(); }
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
        public string getdiss() { return diss; }
        public uint getNum() { return num; }
        //****************************************************//
    }
}
