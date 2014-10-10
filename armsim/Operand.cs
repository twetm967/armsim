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
        bool ifShift = false;
        int shiftType, Rm, Rs, immed, rot, shiftAm, type = 0;

        public Operand(Memory mem, bool b)
        {
            instr = mem;
            ifShift = b;
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
                    if (instr.TestFlag(0, i) == true){ immed += (int)Math.Pow(2, i);}                   
                }

                rot = instr.ReadNibble(8) * 2; //gets #rot (immediate alignment) * 2

            }
            else //shift by register
            {
                if (instr.TestFlag(0, 4) == false)//immediate shifted register, type = 1
                {
                    type = 2;
                    Rm = instr.ReadNibble(0); 
                    for (int i = 5; i < 7; ++i) // gets the shift type
                    {
                        if (instr.TestFlag(0, i)) { shiftType += (int)Math.Pow(2, (i-5)); }
                    }

                    for (int i = 7; i < 12; ++i) // gets the shift amount
                    {
                        if (instr.TestFlag(0, i)) { shiftAm += (int)Math.Pow(2 , (i - 7)); }
                    }
                }
                else //register shifted register, type = 2
                {
                    type = 3;
                    Rm = instr.ReadNibble(0);
                    for (int i = 5; i < 7; ++i) // gets the shift type
                    {
                        if (instr.TestFlag(0, i)) { shiftType += (int)Math.Pow(2, (i - 5)); }
                    }

                    Rs = instr.ReadNibble(8);
                }
            }
        }



        //*********************GETTERS************************//
        public int getRm() { return Rm; }
        public int getRs() { return Rs; }
        public int getImmed() { return immed; }
        public int getRot() { return rot; }
        public int getShiftAm() { return shiftAm; }
        public int getType() { return type; }
        public int getShiftType() { return shiftType; }
        //****************************************************//
    }
}
