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

        //contains unit tests to test methods in the RAM class
        public void TestMethods()
        {
            Memory ram = new Memory();
            ram.setMem(1024);
            /*ram.WriteWord(0, 823746);
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
            Log.WriteToLog("Unit Test #3 Passed");*/

            /*ram.clearRam();
            ram.SetFlag(0, 5, true);
            Debug.Assert(ram.TestFlag(0, 5) == true);
            Log.WriteToLog("Unit Test #4 Passed");*/

            ram.clearRam();
            uint number = 0xE3A02030;                  //00001100000001000000010111000111
            Instruction.decode(number);
            //Console.WriteLine("The test passed.");
            Console.ReadLine();
        }
    }
}
