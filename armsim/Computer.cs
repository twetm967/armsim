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
    public class Computer
    {
        bool stop = false;
        bool load = false;
        Options option;
        CPU cpu;
        Memory memory;
        Memory flags;
        Registers regs;
        SantasLittleHelpers elfs;
        Log logs;
        ui form;
        //do more fun things

        public Computer(Options nOp)
        {

            option = nOp;
            cpu = new CPU();
            memory = new Memory();
            regs = new Registers();
            regs.setMem(64);
            elfs = new SantasLittleHelpers();
            logs = new Log();
            memory.setMem(option.getMem());
            if (option.getFilename() != "")
            {
                load = elfs.decodeHeaders(option.getFilename(), memory);
                regs.setRegister(15, elfs.getEntry() + 8);
                regs.setRegister(13, 28672);
            }
        }//end of constructor

        /********************Getters*************************/
        public CPU getCPU() { return cpu; }
        public bool getStop() { return stop; }
        public Options getOptions() { return option; }
        public Memory getMem() { return memory; }
        public Registers getRegs() { return regs; }
        public SantasLittleHelpers getElf() { return elfs; }
        public Log getLog() { return logs; }
        public bool getLoad() { return load; }
        /********************Setters************************/
        public void setCPU(CPU val) { cpu = val; }
        public void setOptions(Options op) { option = op; }
        public void setMem(Memory val) { memory = val; }
        public void setRegs(Registers val) { regs = val; }
        public void setElf(SantasLittleHelpers val) { elfs = val; }
        public void setLog(Log val) { logs = val; }
        public void setStop(bool b) { stop = b; }
        public void setForm(ui f) { form = f; }

        public void run()
        {
            uint num = 1;

            
                while (stop == false)
                {
                    num = cpu.fetch(this);
                    cpu.decode();
                    cpu.execute();
                    regs.incrementCounter();
                }
                //cpu.writeTrace();
                try
                {
                    if (!option.getAutoTest())
                    {
                        form.Invoke(form.delegate1);
                    }
                }
                catch { }
        }
        public void step()
        {
            if (!stop)
            {
                cpu.fetch(this);
                cpu.decode();
                cpu.execute();
                regs.incrementCounter();
            }
        }

    }
}
