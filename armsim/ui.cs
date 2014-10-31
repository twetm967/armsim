using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace armsim
{
    public partial class ui : Form
    {
        private Computer comp;
        private uint address = 0;

        public ui(ref Computer val)
        {
            InitializeComponent();
            this.Focus();
            comp = val;
            data_box.Text = @"factorial:     file format elf64-x86-64
Disassembly of section .interp:
0000000000400238 <.interp> (bad)
0000000000400239 <.interp+0x1> insb   (%dx),%es:(%rdi)
000000000040023a <.interp+0x2> imul   $0x646c2f34,0x36(%rdx),%esp
0000000000400241 <.interp+0x9> sub    $0x756e696c,%eax
0000000000400246 <.interp+0xe> js     0000000000400275 <_init-0x17b>
0000000000400248 <.interp+0x10> js     0000000000400282 <_init-0x16e>
000000000040024a <.interp+0x12> ss
000000000040024b <.interp+0x13> sub    $0x732e3436,%eax
0000000000400250 <.interp+0x18> outsl  %ds:(%rsi),(%dx)
0000000000400251 <.interp+0x19> xor    %cs:(%rax),%al";
            for (int i = 0; i < 15; ++i)
            {
                regData_grid.Rows.Add();
            }
            for (int i = 0; i < 16; ++i)
            {
                memory_Grid.Rows.Add();
            }
            updateForm();
            if (comp.getOptions().getFilename() == "" || comp.getLoad() == false)
            {
                run_Btn.Enabled = false;
                step_Btn.Enabled = false;
                stop_Btn.Enabled = false;
                reset_Btn.Enabled = false;
                run_menu.Enabled = false;
                step_menu.Enabled = false;
                reset_strip.Enabled = false;
                stop_menu.Enabled = false;
                
            }
            
        }

        public void updateForm()
        {
            updateRegs();
            updateMem();
            updateFlags();
            updateStack();
        }

        public void updateStack()
        {
            uint pointer = 0;
            for (int i = 0; i < 5; ++i)
            {
                if (i == 0)
                {
                    pointer = comp.getRegs().getRegData(13);
                    stack_grid.Rows[0].Cells[i].Value = "0x" + string.Format("{0:X8}", pointer);
                }
                else
                {
                    stack_grid.Rows[0].Cells[i].Value = "0x" + string.Format("{0:X8}", comp.getMem().ReadWord(pointer));
                    pointer += 4;
                }
            }
        }



        public void updateFlags()
        {
            //update the flags
            CPU cpu = comp.getCPU();
            string str = "Flags:\r\n***********\r\n";
            //test N flag
            if (cpu.getN() == true)
            {
                str += "N: 1\r\n\r\n";
            }
            else
            {
                str += "N: 0\r\n\r\n";
            }
            //test Z flag
            if (cpu.getZ() == true)
            {
                str += "Z: 1\r\n\r\n";
            }
            else
            {
                str += "Z: 0\r\n\r\n";
            }
            //test C flag
            if (cpu.getC() == true)
            {
                str += "C: 1\r\n\r\n";
            }
            else
            {
                str += "C: 0\r\n\r\n";
            }
            //test F flag
            if (cpu.getF() == true)
            {
                str += "F: 1\r\n\r\n";
            }
            else
            {
                str += "F: 0\r\n\r\n";
            }
           

            flag_box.Text = str;

        }

        public void updateRegs()
        {
           //fill the grid
            Registers regs = comp.getRegs();
            for (int i = 0; i < 16; ++i)
            {
                if (i == 15)
                {
                    regData_grid.Rows[i].Cells[0].Value = "R" + i.ToString();
                    string data = string.Format("{0:X8}", regs.getRegData(Convert.ToUInt32(i))-8);
                    regData_grid.Rows[i].Cells[1].Value = "0x" + data;
                }
                else
                {
                    regData_grid.Rows[i].Cells[0].Value = "R" + i.ToString();
                    string data = string.Format("{0:X8}", regs.getRegData(Convert.ToUInt32(i)));
                    regData_grid.Rows[i].Cells[1].Value = "0x" + data;
                }
            }

        }

        public void updateMem()
        {
            //update the memory grid
            Memory mem = comp.getMem();
            for (int i = 0; i < 17; ++i)
            {
                //do things
                string ascii = "";
                for (int j = 0; j < 6; ++j)
                {
                    string data = "";
                    
                    switch (j)
                    {
                        case 0:
                            data = "0x" + string.Format("{0:X8}", address);
                            memory_Grid.Rows[i].Cells[j].Value = data;
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            data = "0x" + string.Format("{0:X8}", mem.ReadWord(address));
                            address += 4;
                            ascii += data;
                            memory_Grid.Rows[i].Cells[j].Value = data;
                            break;
                        case 5:
                            memory_Grid.Rows[i].Cells[j].Value = "ascii";
                            break;
                    }

                }
            }
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadFile_menu_Click_1(object sender, EventArgs e)
        {
            // Configure open file dialog box
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = ""; // Default file name
            dlg.DefaultExt = ".exe"; // Default file extension
            dlg.Filter = "Program Files (.exe)|*.exe|All Files (*.*)|*.*"; // Filter files by extension 

            // Show open file dialog box
            dlg.ShowDialog();

            // Process open file dialog box results 
            
            if (dlg.FileName != null)
            {
                // Open document 
                comp.getOptions().setFile( dlg.FileName);
            }
            //dlg.Dispose();
            bool load = comp.getElf().decodeHeaders(comp.getOptions().getFilename(), comp.getMem());
            if (load == false)
            {
                reset_Btn_Click(sender, e);
            }
            updateForm();
            run_Btn.Enabled = true;
            step_Btn.Enabled = true;
            reset_Btn.Enabled = true;
            
            run_menu.Enabled = true;
            step_menu.Enabled = true;
            reset_strip.Enabled = true;
            
        }

        private void step_Btn_Click(object sender, EventArgs e)
        {
            run_Btn.Enabled = false;
            step_Btn.Enabled = false;
            reset_Btn.Enabled = false;
            run_menu.Enabled = false;
            step_menu.Enabled = false;
            reset_strip.Enabled = false;
            comp.setStop(false);
            new Thread(comp.step).Start();
            updateForm();
            run_Btn.Enabled = true;
            step_Btn.Enabled = true;
            reset_Btn.Enabled = true;
            run_menu.Enabled = true;
            step_menu.Enabled = true;
            reset_strip.Enabled = true;

        }

        private void run_Btn_Click(object sender, EventArgs e)
        {
            run_Btn.Enabled = false;
            step_Btn.Enabled = false;
            reset_Btn.Enabled = false;
            run_menu.Enabled = false;
            step_menu.Enabled = false;
            reset_strip.Enabled = false;
            stop_menu.Enabled = true;
            stop_Btn.Enabled = true;

            comp.setStop(false);
            new Thread(comp.run).Start();
            updateForm();
            run_Btn.Enabled = true;
            step_Btn.Enabled = true;
            reset_Btn.Enabled = true;
            run_menu.Enabled = true;
            step_menu.Enabled = true;
            reset_strip.Enabled = true;
            stop_menu.Enabled = false;
            stop_Btn.Enabled = false;

        }

        private void address_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                address = Convert.ToUInt32(address_box.Text);
                updateForm();
            }
            catch
            {
                address_box.Text = "Invalid";
            }
        }

        private void log_check_CheckedChanged(object sender, EventArgs e)
        {
            if (log_check.Checked == true)
            {
                comp.getCPU().setTrace(true);
            }
            else
            {
                comp.getCPU().setTrace(false);
            }
        }

        private void stop_Btn_Click(object sender, EventArgs e)
        {
            comp.setStop(true);
            updateForm();
        }

        private void reset_Btn_Click(object sender, EventArgs e)
        {
            run_Btn.Enabled = false;
            step_Btn.Enabled = false;
            reset_Btn.Enabled = false;
            stop_Btn.Enabled = false;
            run_menu.Enabled = false;
            step_menu.Enabled = false;
            reset_strip.Enabled = false;
            stop_menu.Enabled = false;
            comp.getMem().clearRam();
            comp.getRegs().clearRegs();
            comp.getCPU().resetStep();
            updateForm();
        }

        private void reset_strip_Click(object sender, EventArgs e)
        {
            reset_Btn_Click(sender, e);
        }

        private void step_menu_Click(object sender, EventArgs e)
        {
            step_Btn_Click(sender, e);
        }

        private void run_menu_Click(object sender, EventArgs e)
        {
            run_Btn_Click(sender, e);
        }

        private void stop_menu_Click(object sender, EventArgs e)
        {
            stop_Btn_Click(sender, e);
        }

        private void tracing_menu_Click(object sender, EventArgs e)
        {
            if (log_check.Checked == true)
            {
                log_check.Checked = false;
            }
            else
            {
                log_check.Checked = true;
            }
            log_check_CheckedChanged(sender, e);

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
          
        
    }
}
