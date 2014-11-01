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
        bool n = false;
        bool z = false;
        bool c = false;
        bool f = false;
        private uint data;
        int step_number = 0;
        static StreamWriter trace = new StreamWriter("trace.log", false);
        
        Registers reg;
        Memory mem;
        Instruction inst;
        Computer comp;
        bool tracer = true;

        
        /************getters*************/
        public bool getN() { return n; }
        public bool getZ() { return z; }
        public bool getC() { return c; }
        public bool getF() { return f; }
        /***********setters**************/
        public void setN(bool b) { n = b; }
        public void setZ(bool b) { z = b; }
        public void setC(bool b) { c = b; }
        public void setF(bool b) { f = b; }
        public void setTrace(bool b) { tracer = b; }
        /********************************/

        public void resetStep()
        {
            step_number = 0;
        }

        public uint fetch(Computer com)
        {
            comp = com;
            reg = comp.getRegs();
            mem = comp.getMem();

            data = mem.ReadWord(reg.getRegData(15) - 8);
            ++step_number;
            Console.WriteLine(step_number.ToString() + " " + string.Format("{0:X8}", data));
            return data;
        }

        public void decode()
        {
            //this does nothing for this stage
            inst = Instruction.decode(data, reg, mem);
            inst.decode();
        }

        public void execute()
        {
            inst.exec();
            if (inst.getStop() == true) { comp.setStop(true); }
            if (tracer == true)
            {
                writeTrace();
            }
        }

        public string printFlags()
        {
            string flags = "";
            if (n == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            if (z == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            if (c == true)
            {
                flags += "1";
            }
            else
            {
                flags += "0";
            }
            if (f == true)
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
            trace.WriteLine(step_number.ToString().PadLeft(6, '0') + " " + string.Format("{0:X8}", reg.getRegData(15) - 8) + " " + mem.getMD() + " " + printFlags() + "   0=" + string.Format("{0:X8}", reg.getRegData(0)) +
                   " 1=" + string.Format("{0:X8}", reg.getRegData(1)) + " 2=" + string.Format("{0:X8}", reg.getRegData(2)) + " 3=" + string.Format("{0:X8}", reg.getRegData(3)));
            trace.WriteLine("\t4=" + string.Format("{0:X8}", reg.getRegData(4)) + "  5=" + string.Format("{0:X8}", reg.getRegData(5)) + "  6=" + string.Format("{0:X8}", reg.getRegData(6)) +
                "  7=" + string.Format("{0:X8}", reg.getRegData(7)) + "  8=" + string.Format("{0:X8}", reg.getRegData(8)) + " 9=" + string.Format("{0:X8}", reg.getRegData(9)));
            trace.WriteLine("       10=" + string.Format("{0:X8}", reg.getRegData(10)) + " 11=" + string.Format("{0:X8}", reg.getRegData(11)) + " 12=" + string.Format("{0:X8}", reg.getRegData(12)) +
                " 13=" + string.Format("{0:X8}", reg.getRegData(13)) + " 14=" + string.Format("{0:X8}", reg.getRegData(14)));
            trace.Flush();
        }

    }

}
