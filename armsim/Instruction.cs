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
    public class Instruction
    {

        //switch statement to decide instruction type and calls that class decode
        public static void decode(uint instr, Registers reg)
        {
            Memory instruction = new Memory();
            instruction.setMem(4);
            instruction.WriteWord(0, instr);
            instruction.PrintArray();

            if (instruction.TestFlag(0, 27) == false && instruction.TestFlag(0, 26) == false)
            {
                //Data Processing
                Console.WriteLine("Data_Proc Instruction...");
                Instr_DataProc poc = new Instr_DataProc(instruction, reg);
                poc.decode();
            }
            else if(instruction.TestFlag(0, 27) == false && instruction.TestFlag(0, 26) == true)
            {
                //Load/store
                Console.WriteLine("Load/Store Instruction...");
                Instr_LoadStore load = new Instr_LoadStore(instruction, reg);
                load.decode();

            }
            else if (instruction.TestFlag(0, 27) == true && instruction.TestFlag(0, 26) == false)
            {
                //Branching
                Console.WriteLine("Branching Instruction...");
            }
            
            

            
        }



    }
}
