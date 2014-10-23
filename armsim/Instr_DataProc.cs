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
            op = new Operand(instr, s);
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

        public uint computeShift(uint type)
        {
            uint num = 0;

            uint shiftAm = 0;
            uint data = reg.getRegData(op.getRm());
            if (type == 1) //immediate shift register
            {
                shiftAm = op.getShiftAm();
            }
            else //register shifted register
            {
                shiftAm = reg.getRegData(op.getRs());
            }
            uint shiftType = op.getShiftType();

            switch (shiftType)
            {
                case 0: //LSL
                    num = (data << Convert.ToInt32(shiftAm));
                    break;
                case 1: //ASR
                    num = Convert.ToUInt32((Convert.ToInt32(data) >> Convert.ToInt32(shiftAm)));
                    break;
                case 2: //LSR
                    num = (data >> Convert.ToInt32(shiftAm));
                    break;
                case 3: //ROR*/RRX
                    if(op.getROR() == true) //ROR
                    {
                        num = (data >> Convert.ToInt32(shiftAm)) | (data << (32 - Convert.ToInt32(shiftAm)));
                    }
                    else //RRX
                    {
                        num = (data >> 1) | (data << (32 - 1));
                    }
                    break;
            }

            return num;
        }

        public void execAND()
        {

        }

        public void execEOR()
        {

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
                    uint num = computeShift(type);
                    reg.setRegister(Rd, num - reg.getRegData(Rn));
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = computeShift(type);
                    reg.setRegister(Rd, num1 - reg.getRegData(Rn));
                    break;
            }
        }
        public void execRSB()
        {

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
                    uint num = computeShift(type);
                    reg.setRegister(Rd, num + reg.getRegData(Rn));
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = computeShift(type);
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
                    uint num = computeShift(type);
                    reg.setRegister(Rd, num);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = computeShift(type);
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
                    reg.setRegister(Rd, (uint)data);
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    uint num = computeShift(type);
                    reg.setRegister(Rd, num);
                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    uint num1 = computeShift(type);
                    reg.setRegister(Rd, num1);
                    break;
            }
        }
       

    }
}
