//Thomas Wetmore twetm967 (639306)
//all test cases pass
//inheritance was giving me issues and is still being worked on 

namespace armsim
{
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

    // A struct that mimics memory layout of ELF file header
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct ELF
    {
        public byte EI_MAG0, EI_MAG1, EI_MAG2, EI_MAG3, EI_CLASS, EI_DATA, EI_VERSION;
        byte unused1, unused2, unused3, unused4, unused5, unused6, unused7, unused8, unused9;
        public ushort e_type;
        public ushort e_machine;
        public uint e_version;
        public uint e_entry;
        public uint e_phoff;
        public uint e_shoff;
        public uint e_flags; 
        public ushort e_ehsize;
        public ushort e_phentsize;
        public ushort e_phnum;
        public ushort e_shentsize;
        public ushort e_shnum;
        public ushort e_shstrndx;
    }

    //a struct that holds ELF segment headers
    public struct ELFData
    {
        public uint p_type;
        public uint p_offset;
        public uint p_vaddr;
        public uint p_paddr;
        public uint p_filesz;
        public uint p_memsz;
        public uint p_flags;
        public uint p_align;
    }  

    class armsim
    {
        //main method
        [STAThread]
        static void Main(string[] args)
        {
            
            Options options = new Options();
            options.parse(args);
            Computer comp = new Computer(options);
            
            bool testing = options.getTest();
            bool autoTest = options.getAutoTest();
            if (testing == false && autoTest == false)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ui form = new ui(ref comp);
                comp.setForm(form);
                Application.Run(form);
            }
            else
            {
                Test test = new Test(comp);
                if (testing) { test.TestMethods(); }
                else if (autoTest) { test.testRun(comp); }
            }
        }//Main
    }//class armsim
}//namespace
