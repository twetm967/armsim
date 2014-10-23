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
    public class Registers : Memory
    {
        public uint getRegData(int num)
        {
            Log.WriteToLog("Reading data from register: " + num.ToString());
            uint reg = (uint)num * 4;
            return ReadWord(reg);
        }

        public void setRegister(int reg, uint data)
        {
            Log.WriteToLog("Setting data to register: " + reg.ToString());
            uint regAddress = (uint)reg * 4;
            WriteWord(regAddress, data);
        }

        public void incrementCounter()
        {
            Log.WriteToLog("Incrementing the program counter.");
            uint data = ReadWord(15 * 4);
            data += 4;
            WriteWord(15 * 4, data);
        }

        public void clearRegs()
        {
            Log.WriteToLog("***Clearing all registers***");
            for (int i = 0; i < 16; ++i)
            {
                setRegister(i, 0);
            }
            WriteWord(15 * 4, 0);
        }

    }
}
