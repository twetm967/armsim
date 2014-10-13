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
       
        int type = 0;
        Memory instruction;
        Registers reg;
        public Instruction(uint instr, Registers r)
        {
            reg = r;
            instruction = new Memory();
            instruction.setMem(4);
            instruction.WriteWord(0, instr);
            instruction.PrintArray();
        }
        //switch statement to decide instruction type and calls that class decode
        public void decode()
        {
             

            if (instruction.TestFlag(0, 27) == false && instruction.TestFlag(0, 26) == false)
            {
                //Data Processing
                type = 0;
                Console.WriteLine("Data_Proc Instruction...");
                
                
            }
            else if(instruction.TestFlag(0, 27) == false && instruction.TestFlag(0, 26) == true)
            {
                //Load/store
                type = 1;
                Console.WriteLine("Load/Store Instruction...");
                
                ///return load;

            }
            else if (instruction.TestFlag(0, 27) == true && instruction.TestFlag(0, 26) == false)
            {
                //Branching
                type = 2;
                Console.WriteLine("Branching Instruction...");
                
                
            }

  
        }

        public void exec()
        {
            if (type == 0)
            {
                Instr_DataProc poc = new Instr_DataProc(instruction, reg);
                poc.decode();
            }
            else if (type == 1)
            {
                Instr_LoadStore load = new Instr_LoadStore(instruction, reg);
                load.decode();
            }else if (type ==2)
            {
                Instr_Branch bran = new Instr_Branch(instruction, reg);
                bran.decode();
            }
        }



    }
}
