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
        uint opcode, Rn, Rd, cond;
        Operand op;
        uint data = 0;
        string diss = "";
        Registers reg;
        Memory instr;
        CPU cpu;
        bool s = false;

        public override bool getStop() { return false; }
        public override uint getCond() { return cond; }
        
        public Instr_DataProc(Memory inst, Registers r, CPU f)
        {
            instr = inst;
            reg = r;
            cpu = f;
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
        public override string toString() { return diss; }
        //sets instance variables then calls exec()
        public override void decode()
        { 
            Rn = instr.ReadNibble(16);
            Rd = instr.ReadNibble(12);
            cond = instr.ReadNibble(28);
            opcode = instr.ReadNibble(21);
            s = instr.TestFlag(0, 25);
            op = new Operand(instr, s, reg);

        }

        public void makeDiss()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    if (opcode == 13 || opcode == 15 || opcode == 10)
                    {
                        diss += "r" + Rd.ToString() + ", #" + data.ToString();
                    }
                    else
                    {
                        diss += "r" + Rd.ToString() + ", r" + Rn.ToString() + ", #" + data.ToString();
                    }
                    
                    break;
                case 1:
                    diss += "r" + Rd.ToString() + ", r" + op.getRm().ToString(); 
                    if (op.getShiftAm() != 0)
                    {
                        diss += ", " + op.getShifter() + " #" + op.getShiftAm().ToString();
                    }
                    break;
                case 2:
                    diss += "r" + Rd.ToString() + ", r" + op.getRm().ToString() ;
                    if (op.getShiftAm() != 0)
                    {
                        diss += ", " + op.getShifter() + " #" + op.getRs().ToString();
                    }
                    break;
            }
        }
        //uses switch and instance variables to call the corresct execute command
        public override void exec()
        {
            switch (opcode)
            {
                case 0:
                    diss = "and ";
                    execAND();
                    break;
                case 1:
                    diss = "eor ";
                    execEOR();
                    break;
                case 2:
                    diss = "sub ";
                    execSUB();
                    break;
                case 3:
                    diss = "srb ";
                    execRSB();
                    break;
                case 4:
                    diss = "add ";
                    execADD();
                    break;
                case 5:
                    diss = "adc ";
                    execADC();
                    break;
                case 6:
                    diss = "sbc ";
                    execSBC();
                    break;
                case 7:
                    diss = "rsc ";
                    execRSC();
                    break;
                case 8:
                    diss = "tst ";
                    execTST();
                    break;
                case 9:
                    diss = "teq ";
                    execTEQ();
                    break;
                case 10:
                    diss = "cmp ";
                    execCMP();
                    break;
                case 11:
                    diss = "cmn ";
                    execCMN();
                    break;
                case 12:
                    diss = "orr ";
                    execORR();
                    break;
                case 13:
                    diss = "mov ";
                    execMOV();
                    break;
                case 14:
                    diss = "bic ";
                    execBIC();
                    break;
                case 15:
                    diss = "mvn ";
                    execMVN();
                    break;

            }
            makeDiss(); 
        }

        public void execAND()
        {
           uint type = op.getType();
           switch (type)
           {
               case 0: //immediate
                   uint shift = op.getRot();
                   data = op.getImmed();
                   data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                   reg.setRegister(Rd, data & reg.getRegData(Rn));
                   break;
               case 1:
                   uint num = op.computeShift(type);
                   reg.setRegister(Rd, num & reg.getRegData(Rn));
                   break;
               case 2:
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
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, data ^ reg.getRegData(Rn));
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num ^ reg.getRegData(Rn));
                    break;
                case 2:
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
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, reg.getRegData(Rn) - data);
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, reg.getRegData(Rn)- num);
                    break;
                case 2:
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, reg.getRegData(Rn) - num1);
                    break;
            }
        }
        public void execRSB()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, data - reg.getRegData(Rn));
                    Console.WriteLine("R" + Rd + ": " + reg.getRegData(Rd));
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num - reg.getRegData(Rn));
                    break;
                case 2:
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 - reg.getRegData(Rn));
                    break;
            }
        }
        public void execADD()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    data += reg.getRegData(Rn);
                    reg.setRegister(Rd, data);
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num + reg.getRegData(Rn));
                    break;
                case 2:
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
            uint type = op.getType();
            uint num = op.computeShift(type);
            uint info = reg.getRegData(Rn);
            uint data =  info - num;
            if ((data >> 31) == 1) { cpu.setN(true); } 
            else { cpu.setN(false); }

            if (num > info) { cpu.setC(false); }
            else { cpu.setC(true); }

            if (data == 0) { cpu.setZ(true); }
            else { cpu.setZ(false); }

            if (((int)info >= 0 && (int)num < 0 && (int)data < 0) || ((int)info < 0 && (int)num >= 0 && (int)data >= 0)) 
            { 
                cpu.setV(true);
            }
            else
            {
                cpu.setV(false);
            }

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
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, data | reg.getRegData(Rn));
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num | reg.getRegData(Rn));
                    break;
                case 2:
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 | reg.getRegData(Rn));
                    break;
            }
        }
        public void execMOV()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, (uint)data);
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num);
                    break;
                case 2:
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1);
                    break;
            }

        }
        public void execBIC()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, data & ~reg.getRegData(Rn));
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, num & ~reg.getRegData(Rn));
                    break;
                case 2:
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, num1 & ~reg.getRegData(Rn));
                    break;
            }
        }
        public void execMVN()
        {
            uint type = op.getType();
            switch (type)
            {
                case 0: //immediate
                    uint shift = op.getRot();
                    data = op.getImmed();
                    data = (data >> Convert.ToInt32(shift)) | (data << (32 - Convert.ToInt32(shift)));
                    reg.setRegister(Rd, ~data);
                    break;
                case 1:
                    uint num = op.computeShift(type);
                    reg.setRegister(Rd, ~num);
                    break;
                case 2:
                    uint num1 = op.computeShift(type);
                    reg.setRegister(Rd, ~num1);
                    break;
            }
        }
       

    }
}
