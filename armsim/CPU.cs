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
        static TextWriterTraceListener log = new TextWriterTraceListener("trace.log");
        Registers reg;
        Memory mem;
        bool tracer = false;


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

        public uint fetch(Computer comp)
        {
            reg = comp.getRegs();
            mem = comp.getMem();
            if (tracer == true)
            {
                log.Write(step_number.ToString() + " 0x" + string.Format("{0:X8}", reg.getRegData(15)) + " ");
                log.Flush();
            }


            data = reg.getRegData(15);
            ++step_number;
            return data;
        }

        public void decode()
        {
            //this does nothing for this stage
        }

        public void execute()
        {
            //pause 1/4 second
            //await Task.Delay(250);

            System.Threading.Thread.Sleep(250);
            if (tracer == true)
            {
                log.Write(mem.getMD() + " " + printFlags() + " 0=" + reg.getRegData(0).ToString() +
                   " 1=" + reg.getRegData(1).ToString() + " 2=" + reg.getRegData(2).ToString() + " 3=" + reg.getRegData(3).ToString() + "\r\n");
                log.WriteLine(" 4=" + reg.getRegData(4).ToString() + " 0x" + " 5=" + reg.getRegData(5).ToString() + " 6=" + reg.getRegData(6).ToString() +
                    " 7=" + reg.getRegData(7).ToString() + " 8=" + reg.getRegData(8).ToString() + " 9=" + reg.getRegData(9).ToString());
                log.WriteLine(" 10=" + reg.getRegData(10).ToString() + " 11=" + reg.getRegData(11).ToString() + " 12=" + reg.getRegData(12).ToString() +
                    " 13=" + reg.getRegData(13).ToString() + " 14=" + reg.getRegData(14).ToString());
                log.Flush();
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

    }
}
