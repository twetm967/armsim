using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace armsim
{

    class Operand
    {
        Memory instr;
        Registers reg;
        bool ifShift = false;
        bool ROR = true;
        string shifter = "";
        uint shiftType, Rm, Rs, immed, rot, shiftAm, type = 0;

        public Operand(Memory mem, bool b, Registers r)
        {
            instr = mem;
            ifShift = b;
            reg = r;
            parse();

        }

        //parses the operand so and stored in instance variables
        public void parse()
        {
            if (ifShift == true)//shift by immediate and set type = 0
            {
                type = 0;
                for (int i = 0; i < 8; ++ i) //gets 8-bit immediate
                {
                    if (instr.TestFlag(0, i) == true){ immed += Convert.ToUInt32(Math.Pow(2, i));}                   
                }

                rot = instr.ReadNibble(8) * 2; //gets #rot (immediate alignment) * 2

            }
            else //shift by register
            {
                if (instr.TestFlag(0, 4) == false)//immediate shifted register, type = 1
                {
                    type = 1;
                    Rm = instr.ReadNibble(0); 
                    for (int i = 5; i < 7; ++i) // gets the shift type
                    {
                        if (instr.TestFlag(0, i)) { shiftType += Convert.ToUInt32(Math.Pow(2, (i-5))); }
                    }

                    for (int i = 7; i < 12; ++i) // gets the shift amount
                    {
                        if (instr.TestFlag(0, i)) { shiftAm += Convert.ToUInt32(Math.Pow(2 , (i - 7))); }
                    }
                }
                else //register shifted register, type = 2
                {
                    type = 2;
                    Rm = instr.ReadNibble(0);
                    for (int i = 5; i < 7; ++i) // gets the shift type
                    {
                        if (instr.TestFlag(0, i)) { shiftType += Convert.ToUInt32(Math.Pow(2, (i - 5))); }
                    }

                    Rs = instr.ReadNibble(8);
                }
                uint num = 0;
                for (int i = 7; i < 12; ++i) // tests ROR/RRX
                { 
                    if (instr.TestFlag(0, i)) { num += Convert.ToUInt32(Math.Pow(2, (i - 7))); }
                }
                if (num == 0) { ROR = false; }

            }
        }

        public uint computeShift(uint type)
        {
            uint num = 0;
            
            uint SAm = 0;
            uint data = reg.getRegData(Rm);
            
            if (type !=1) //register shifted register
            {
                shiftAm = reg.getRegData(Rs);
            }
            //uint shiftType = shiftType;

            switch (shiftType)
            {
                case 0: //LSL
                    shifter = "lsl";
                    num = (data << Convert.ToInt32(shiftAm));
                    break;
                case 1: //ASR
                    //int info = (int)data;
                    shifter = "asr";
                    num = (data >> Convert.ToInt32(shiftAm));
                    break;
                case 2: //LSR
                    shifter = "lsr";
                    num = (uint)(((int)data >> (int)shiftAm));
                    break;
                case 3: //ROR*/RRX
                    if (getROR() == true) //ROR
                    {
                        shifter = "ror";
                        num = (data >> Convert.ToInt32(shiftAm)) | (data << (32 - Convert.ToInt32(shiftAm)));
                    }
                    else //RRX
                    {
                        shifter = "rrx";
                        num = (data >> 1) | (data << (32 - 1));
                    }
                    break;
            }

            return num;
        }


        //*********************GETTERS************************//
        public uint getRm() { return Rm; }
        public bool getROR() { return ROR; }
        public uint getRs() { return Rs; }
        public uint getImmed() { return immed; }
        public uint getRot() { return rot; }
        public string getShifter() { return shifter; }
        public uint getShiftAm() { return shiftAm; }
        public uint getType() { return type; }
        public uint getShiftType() { return shiftType; }
        //****************************************************//
    }
}
