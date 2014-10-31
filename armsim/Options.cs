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
    public class Options
    {
        private int memSize = 32768; //holds the ram size from the user 
        private string fileName = ""; //holds the name of the file from the user to load
        private bool test = false; //this bool tells whether or not to run the unit tests
        bool load = false;
        bool exec = false;
        bool autoTest = false;
        private bool arg = true;

        //*************Getters******************
        public int getMem() { return memSize; }
        public string getFilename() { return fileName; }
        public bool getTest() { return test; }
        public bool getAutoTest() { return autoTest;}
        public void setFile(string str) { fileName = str; }
        //****************************************


        //parses command arguments and sets class variables accordingly
        public void parse(string[] args)
        {
            if (args.Length == 0)
            {
                
                Log.WriteToLog("No parameters were given.");
                arg = false;
                //Environment.Exit(0);

            }//if
            else
            {
                Log.WriteToLog("User arguments entered...");

                for (int i = 0; i < args.Length; ++i)
                {
                    string str = args[i].ToLower();

                    switch (str)
                    {

                        case "--load":
                            if (i + 1 < args.Length)
                            {
                                fileName = args[i + 1];
                                Log.WriteToLog("File Name: " + fileName);
                                load = true;
                                ++i;
                            }
                            break;
                        case "--mem":
                            if (i + 1 < args.Length)
                            {
                                memSize = Convert.ToInt32(args[i + 1]);
                                Log.WriteToLog("Memory Size: " + memSize.ToString());
                                ++i;
                            }
                            break;
                        case "--test":
                            test = true;
                            Log.WriteToLog("Test Cases: True");
                            break;
                        case "--exec":
                            exec = true;
                            break;
                        default:
                            Log.WriteToLog("You entered an invalid option.");
                            Environment.Exit(0);
                            break;
                    }//switch

                }//for loop
                if (exec == true && load == true) { autoTest = true;}
                else { exec = false;}
            }//else
        }//parse
    }//class options
}
