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
        public static Instruction decode(uint instr, Registers reg)
        {
           // int type = 0;
            Memory instruction = new Memory();
            instruction.setMem(4);
            instruction.WriteWord(0, instr);
            instruction.PrintArray();

            if (instruction.TestFlag(0, 27) == false && instruction.TestFlag(0, 26) == false)
            {
                //Data Processing
                //type = 0;
                Console.WriteLine("Data_Proc Instruction...");
                return new Instr_DataProc(instruction, reg);
                
                
            }
            else if(instruction.TestFlag(0, 27) == false && instruction.TestFlag(0, 26) == true)
            {
                //Load/store
                Console.WriteLine("Load/Store Instruction...");
                return new Instr_LoadStore(instruction, reg);
                
            }
            else if (instruction.TestFlag(0, 27) == true && instruction.TestFlag(0, 26) == false)
            {
                //Branching
                Console.WriteLine("Branching Instruction...");
                return new Instr_Branch(instruction, reg);
            }
            return null;
  
        }
        public abstract void decode(); //allows for override
        public abstract void exec(); //allows for override
    }
}

