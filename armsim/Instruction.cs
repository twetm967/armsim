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
    //This class holds the information for instruction operations
    abstract class Instruction
    {

        
        public static Instruction decode(uint instr, Registers reg, Memory mem, CPU cpu)
        {
           // int type = 0;
            Memory instruction = new Memory();
            instruction.setMem(4);
            instruction.WriteWord(0, instr);
            //instruction.PrintArray();
            uint num = 0;
            for (uint i = 20; i <= 27; ++i)
            {
                if (instruction.TestFlag(0, (int)i)) { num += Convert.ToUInt32(Math.Pow(2, (i - 20))); }
            }

            Instr_Special_Case special = Instr_Special_Case.isSpecial(instruction, reg, cpu);
            if (special == null)
            {

                if ((instruction.TestFlag(0, 27) && !instruction.TestFlag(0, 26) && instruction.TestFlag(0, 25)) || num == 18)
                {
                    //Branching
                    //Console.WriteLine("Branching Instruction...");
                    return new Instr_Branch(instruction, reg, cpu);
                }
                else if (!instruction.TestFlag(0, 27) && !instruction.TestFlag(0, 26))
                {
                    //Data Processing
                    //type = 0;
                    //Console.WriteLine("Data_Proc Instruction...");
                    return new Instr_DataProc(instruction, reg, cpu);


                }
                
                else if ((!instruction.TestFlag(0, 27) && instruction.TestFlag(0, 26) || (instruction.TestFlag(0, 27) && !instruction.TestFlag(0, 26))))
                {
                    //Load/store
                    //Console.WriteLine("Load/Store Instruction...");
                    return new Instr_LoadStore(instruction, reg, mem, cpu);

                }
               
            }
            else
            {
                return special;
            }
            
            return null;
  
        }
        
        public abstract void decode(); //allows for override
        public abstract void exec(); //allows for override
        public abstract bool getStop(); //allows for override
        public abstract string toString(); //allows for override
        public abstract uint getCond(); //allows for override
    }
}

