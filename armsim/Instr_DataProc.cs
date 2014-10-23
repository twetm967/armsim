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
        uint opcode, Rn, Rd, cond;
        Operand op;
        Registers reg;
        Memory instr;
        bool s = false;

        public Instr_DataProc(Memory inst, Registers r)
        {
            instr = inst;
            reg = r;
        }

        
        //sets instance variables then calls exec()
        public override void decode()
        {
            Console.WriteLine("Running Data_Proc decode..."); 
            Rn = instr.ReadNibble(16);
            Console.WriteLine("RN: " + Rn.ToString());
            Rd = instr.ReadNibble(12);
            cond = instr.ReadNibble(28);
            opcode = instr.ReadNibble(21);
            Console.WriteLine("Opcode: " + opcode.ToString());
            s = instr.TestFlag(0, 25);
            op = new Operand(instr, s, reg);
            //exec();

        }

        //uses switch and instance variables to call the corresct execute command
        public override void exec()
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
                    Console.WriteLine("Running MOV command...");
                    execMOV();
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
           uint type = op.getType();
           switch (type)
           {
               case 0: //immediate
                   Console.WriteLine("Case 0");
                   uint shift = op.getRot();
                   uint data = op.getImmed();
                   data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                   Console.WriteLine("Data: " + data.ToString());
                   //data += (int)reg.getRegData(Rn);
                   reg.setRegister(Rd, data & reg.getRegData(Rn));
                   Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                   break;
               case 1:
                   Console.WriteLine("Case 1");
                   uint num = op.computeShift(type);
                   reg.setRegister(Rd, num & reg.getRegData(Rn));
                   break;
               case 2:
                   Console.WriteLine("Case 2");
                   uint num1 = op.computeShift(type);
                   reg.setRegister(Rd, num1 & reg.getRegData(Rn));
                   break;
           }
        }

        public void execEOR()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    //data += (int)reg.getRegData(Rn);
                    reg.setRegister(Rd, data ^ reg.getRegData(Rn));
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num ^ reg.getRegData(Rn));
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 ^ reg.getRegData(Rn));
                    break;
            }
        }
        public void execSUB()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    //data += (int)reg.getRegData(Rn);
                    reg.setRegister(Rd, data - reg.getRegData(Rn));
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num - reg.getRegData(Rn));
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 - reg.getRegData(Rn));
                    break;
            }
        }
        public void execRSB()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    //data += (int)reg.getRegData(Rn);
                    reg.setRegister(Rd, reg.getRegData(Rn) - data);
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, reg.getRegData(Rn) - num);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, reg.getRegData(Rn) - num1);
                    break;
            }
        }
        public void execADD()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    data += reg.getRegData(Rn);
                    reg.setRegister(Rd, data);
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num + reg.getRegData(Rn));
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 + reg.getRegData(Rn));
                    break;
            }
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
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    //data += (int)reg.getRegData(Rn);
                    reg.setRegister(Rd, data | reg.getRegData(Rn));
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num | reg.getRegData(Rn));
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 | reg.getRegData(Rn));
                    break;
            }
        }
        public void execMOV()
        {
            //do fun things
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    reg.setRegister(Rd, (uint)data);
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1);
                    break;
            }

        }
        public void execBIC()
        {

        }
        public void execMVN()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    Console.WriteLine("Case 0");
                    uint shift = op.getRot();
                    uint data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    Console.WriteLine("Data: " + data.ToString());
                    reg.setRegister(Rd, ~data);
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, ~num);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, ~num1);
                    break;
            }
        }
       

    }
}
