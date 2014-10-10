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
    class Instr_DataProc : Instruction
    {
        //string opcode = "";
        int opcode, Rn, Rd, cond;
        Operand op;
        Memory instr;
        bool s = false;

        public Instr_DataProc(Memory inst)
        {
            instr = inst;
        }
        
        //sets instance variables then calls exec()
        public void decode()
        {
            Console.WriteLine("Running Data_Proc decode..."); 
            Rn = instr.ReadNibble(16);
            Console.WriteLine("RN: " + Rn.ToString());
            Rd = instr.ReadNibble(12);
            cond = instr.ReadNibble(28);
            opcode = instr.ReadNibble(21);
            Console.WriteLine("Opcode: " + opcode.ToString());
            s = instr.TestFlag(0, 25);
            op = new Operand(instr, s);
            exec();

        }

        //uses switch and instance variables to call the corresct execute command
        public void exec()
        {
            switch (opcode)
            {
                case 0:
                    execAND();
                    break;
                case 1:
                    execEOR();
                    break;
                case 2:
                    execSUB();
                    break;
                case 3:
                    execRSB();
                    break;
                case 4:
                    execADD();
                    break;
                case 5:
                    execADC();
                    break;
                case 6:
                    execSBC();
                    break;
                case 7:
                    execRSC();
                    break;
                case 8:
                    execTST();
                    break;
                case 9:
                    execTEQ();
                    break;
                case 10:
                    execCMP();
                    break;
                case 11:
                    execCMN();
                    break;
                case 12:
                    execORR();
                    break;
                case 13:
                    execMOV();
                    Console.WriteLine("Running MOV commend...");
                    break;
                case 14:
                    execBIC();
                    break;
                case 15:
                    execMVN();
                    break;

            }
        }

        public void execAND()
        {

        }

        public void execEOR()
        {

        }
        public void execSUB()
        {

        }
        public void execRSB()
        {

        }
        public void execADD()
        {

        }
        public void execADC()
        {

        }
        public void execSBC()
        {

        }
        public void execRSC()
        {

        }
        public void execTST()
        {

        }
        public void execTEQ()
        {

        }
        public void execCMP()
        {

        }
        public void execCMN()
        {

        }
        public void execORR()
        {

        }
        public void execMOV()
        {
            //do fun things
            Console.WriteLine("IT WAS CORRECT!!!!!!!!!!!");

        }
        public void execBIC()
        {

        }
        public void execMVN()
        {

        }
       

    }
}
