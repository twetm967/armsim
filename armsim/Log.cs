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
    //this class does all logging for the program
    public class Log
    {
        //holds the logging object
        static TextWriterTraceListener log = new TextWriterTraceListener("log_file.log");

        //writes a given string to my log file
        public static void WriteToLog(string str)
        {
            log.WriteLine(str);
            log.Flush();
        }
    }
}
