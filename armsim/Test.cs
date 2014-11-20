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
    public class Test
    {
        Computer comp;
        //contains unit tests to test methods in the RAM class
        public Test(Computer c) { comp = c; }
        public void TestMethods()
        {
            Memory ram = new Memory();
            ram.setMem(1024);
            ram.WriteWord(0, 823746);
            Debug.Assert(ram.ReadWord(0) == 823746);
            Log.WriteToLog("Unit Test #1 Passed!");

            ram.clearRam();
            short i = 4556;
            ram.WriteHalfWord(0, i);
            Debug.Assert(ram.ReadHalfWord(0) == 4556);
            Log.WriteToLog("Unit Test #2 Passed");

            ram.clearRam();
            byte blob = 215;
            ram.WriteByte(0, blob);
            Debug.Assert(ram.ReadByte(0) == 215);
            Log.WriteToLog("Unit Test #3 Passed");

            

            ram.clearRam();
            Registers reg = new Registers();
            Memory flags = new Memory();
            flags.setMem(4);
            reg.setMem(64);
            uint number = 0xE3A02030;                  //00001100000001000000010111000111 0xE3A02030
            Instruction inst = Instruction.decode(number, reg, ram, comp.getCPU());
            inst.decode();
            inst.exec();
            Debug.Assert(reg.getRegData(2) == 48);

            Console.WriteLine("The MOV test Passed.");
            Console.ReadLine();
        }

        public void testRun(Computer comp)
        {
            comp.getCPU().setTrace(true);
            comp.run();
            Console.ReadLine();
        }
    }
}
