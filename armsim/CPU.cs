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
    public class CPU
    {
        bool branch = false;
        Memory flags;
        private uint data;
        string dissA = "";
        string traceS = "";
        uint pc;
        int step_number = 0;
        static StreamWriter trace = new StreamWriter("trace.log", false);
        
        Registers reg;
        Memory mem;
        Instruction inst;
        Computer comp;
        bool tracer = true;

        public CPU()
        {
            flags = new Memory();
            flags.setMem(4);
        }

        public void resetStep()
        {
            step_number = 0;
        }

        public uint fetch(Computer com)
        {
            comp = com;
           
            reg = comp.getRegs();
            mem = comp.getMem();
            pc = reg.getRegData(15) - 8;
            data = mem.ReadWord(pc);
            ++step_number;
            Console.WriteLine(step_number.ToString());
            return data;
        }

        public void decode()
        {
            if (step_number == 17)
            {
                string blob = "delete me!!!";
            }
            inst = Instruction.decode(data, reg, mem, this, comp);
            inst.decode();
        }

        public void execute()
        {
            string tester = "";

            if (step_number % 10 == 0) { dissA = ""; }
            if (testCond())
            {
                inst.exec();
                dissA += tester = step_number.ToString() + "  " +  string.Format("{0:X8}", pc) + " " + string.Format("{0:X8}", data) + "  " + inst.toString() + "\r\n";
            }
            else
            {
                dissA += tester = step_number.ToString() + "  " + string.Format("{0:X8}", pc) + " " + string.Format("{0:X8}", data) + "  Non-Executed Conditional Instruction\r\n";
            }
            if (inst.getStop() == true) { comp.setStop(true); }
            //Console.WriteLine(tester);
            if (tracer == true)
            {
                writeTrace();
            }
            
        }
        public bool testCond()
        {
            uint cond = inst.getCond();
            switch (cond)
            {
                case 0:
                    if (getZ()) { return true; }
                    else { return false; }
                    break;
                case 1:
                    if (!getZ()) { return true; }
                    else { return false; }
                    break;
                case 2:
                    if (getC()) { return true; }
                    else { return false; }
                    break;
                case 3:
                    if (!getC()) { return true; }
                    else { return false; }
                    break;
                case 4:
                    if (getN()) { return true; }
                    else { return false; }
                    break;
                case 5:
                    if (!getN()) { return true; }
                    else { return false; }
                    break;
                case 6:
                    if (getV()) { return true; }
                    else { return false; }
                    break;
                case 7:
                    if (!getV()) { return true; }
                    else { return false; }
                    break;
                case 8:
                    if (getC() && !getZ()) { return true; }
                    else { return false; }
                    break;
                case 9:
                    if (!getC() || getZ()) { return true; }
                    else { return false; }
                    break;
                case 10:
                    if (getN() == getV()) { return true; }
                    else { return false; }
                    break;
                case 11:
                    if (getN() != getV()) { return true; }
                    else { return false; }
                    break;
                case 12:
                    if (!getZ() && getN() == getV()) { return true; }
                    else { return false; }
                    break;
                case 13:
                    if (getZ() || getN() != getV()) { return true; }
                    else { return false; }
                    break;
                case 14:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }
        public string printFlags()
        {
            string flags = "";
            if (getN() == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            if (getZ() == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            if (getC() == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            if (getV() == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            return flags;
        }

        public void writeTrace()
        {
            if (step_number % 10 == 0) { traceS = ""; }
            string rand = printFlags();
            string line = "";
            traceS += line = (step_number.ToString().PadLeft(6, '0') + " " + string.Format("{0:X8}", pc) + " " + /*mem.getMD()*/ "[sys]" + " " + printFlags() + "   0=" + string.Format("{0:X8}", reg.getRegData(0)) +
                   " 1=" + string.Format("{0:X8}", reg.getRegData(1)) + " 2=" + string.Format("{0:X8}", reg.getRegData(2)) + " 3=" + string.Format("{0:X8}", reg.getRegData(3)));
            traceS += "\r\n";
            trace.WriteLine(line);
            traceS += line = ("\t4=" + string.Format("{0:X8}", reg.getRegData(4)) + "  5=" + string.Format("{0:X8}", reg.getRegData(5)) + "  6=" + string.Format("{0:X8}", reg.getRegData(6)) +
                "  7=" + string.Format("{0:X8}", reg.getRegData(7)) + "  8=" + string.Format("{0:X8}", reg.getRegData(8)) + " 9=" + string.Format("{0:X8}", reg.getRegData(9)));
            traceS += "\r\n";
            trace.WriteLine(line);
            traceS += line = ("       10=" + string.Format("{0:X8}", reg.getRegData(10)) + " 11=" + string.Format("{0:X8}", reg.getRegData(11)) + " 12=" + string.Format("{0:X8}", reg.getRegData(12)) +
                " 13=" + string.Format("{0:X8}", reg.getRegData(13)) + " 14=" + string.Format("{0:X8}", reg.getRegData(14)));
            traceS += "\r\n";
            trace.WriteLine(line);
            trace.Flush();
        }



        /************getters*************/
        public bool getN() { return flags.TestFlag(0, 31); }
        public bool getZ() { return flags.TestFlag(0, 23); }
        public bool getC() { return flags.TestFlag(0, 15); }
        public bool getV() { return flags.TestFlag(0, 7); }
        public string getTrace() { return traceS; }
        public Memory getFlags() { return flags; }
        public string getDiss() { return dissA; }
        /***********setters**************/
        public void setN(bool b) { flags.SetFlag(0, 31, b); }
        public void setZ(bool b) { flags.SetFlag(0, 23, b); }
        public void setC(bool b) { flags.SetFlag(0, 15, b); }
        public void setV(bool b) { flags.SetFlag(0, 7, b); }
        public void setPC(uint number) { pc = number; }
        public void setTrace(bool b) { tracer = b; }
        /********************************/

    }

}
