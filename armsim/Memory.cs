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
    //this class holds my simulated RAM
    public class Memory
    {
        private byte[] Ram;
        public void setMem(int memsize)
        {
            Ram = new byte[memsize];
        }


        //calculates and returns Hash data from the ram array
        public string getMD()
        {
            byte[] MD = new MD5CryptoServiceProvider().ComputeHash(Ram);
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < MD.Length; i++)
            {
                sBuilder.Append(MD[i].ToString("x2"));
            }
            return sBuilder.ToString();


        }

        //reads and returns a word from the ram array at a specified address
        public uint ReadWord(uint address)
        {
            if (address % 4 == 0)
            {
                Log.WriteToLog("Reading Word from address: " + address.ToString());
                uint place = address;
                uint outP = 0;
                byte[] store = new byte[4];
                for (int i = 0; i < 4; ++i)
                {
                    store[i] = Ram[place];
                    ++place;
                }
                outP = (uint)BitConverter.ToInt32(store, 0);
                return outP;
            }
            return 0;
        }

        //recieves and writes a word to ram at a specified address
        public bool WriteWord(uint address, uint data)
        {
            if (address % 4 == 0)
            {
                Log.WriteToLog("Writing Word to address: " + address.ToString());
                byte[] buff = new byte[4];
                uint place = address;
                buff = BitConverter.GetBytes(data);
                //Array.Reverse(buff);
                for (int i = 0; i < 4; ++i, ++place)
                {
                    Ram[place] = buff[i];
                }
                return true;
            }
            return false;
        }

        //reads and returns a halfword from the ram array at a specified address
        public ushort ReadHalfWord(uint address)
        {
            if (address % 2 == 0)
            {
                Log.WriteToLog("Reading HalfWord from address: " + address.ToString());
                uint place = address;
                ushort outP = 0;
                byte[] store = new byte[2];
                for (int i = 0; i < 2; ++i)
                {
                    store[i] = Ram[place];
                    ++place;
                }
                outP = (ushort)Convert.ToInt16(BitConverter.ToInt16(store, 0));
                return outP;
            }
            return 0;
        }

        //recieves and writes a halfword to ram at a specified address
        public bool WriteHalfWord(uint address, short data)
        {
            if (address % 2 == 0)
            {
                Log.WriteToLog("Writing HalfWord to address: " + address.ToString());
                byte[] buff = new byte[2];
                uint place = address;
                buff = BitConverter.GetBytes(data);
                //Array.Reverse(buff);
                for (int i = 0; i < 2; ++i, ++place)
                {
                    Ram[place] = buff[i];
                }
                return true;
            }
            return false;
        }
        //reads and returns a byte from the ram array at a specified address
        public uint ReadNibble(uint address)
        {
            uint num = 0;
            for (int i = 0; i < 4; ++i)
            {
                bool b = TestFlag(0, (int)address + i);
                if (b == true)
                {
                    num += Convert.ToUInt32(Math.Pow(2 , i));
                    //Console.WriteLine("Num: " + num.ToString());
                }
            }
           //Console.WriteLine("Num: " + num.ToString());
           return num;
        }
        public byte ReadByte(uint address)
        {

            Log.WriteToLog("Reading byte from address: " + address.ToString());
            return Ram[address];

        }

        //recieves and writes a byte to ram at a specified address
        public bool WriteByte(uint address, byte data)
        {
            Log.WriteToLog("Writing byte to address: " + address.ToString());
            byte[] buff = new byte[1];
            uint place = address;
            buff = BitConverter.GetBytes(data);
            //Array.Reverse(buff);
            for (int i = 0; i < 1; ++i, ++place)
            {
                Ram[place] = buff[i];
            }
            return true;

        }

        public bool TestFlag(uint addr, int bit)
        {
            byte[] bytes = new byte[4];
            bytes = BitConverter.GetBytes(ReadWord(addr));
            BitArray bits = new BitArray(bytes);
            return bits[bit];
        }

        //sets a specified bit in the ram array
        public void SetFlag(uint addr, int bit, bool flag)
        {
            if (bit < 0 || bit > 31)
            {
                return;
            }
            byte[] bytes = new byte[4];
            bytes = BitConverter.GetBytes(ReadWord(addr));
            BitArray bits = new BitArray(bytes);
            bits[bit] = flag;
            bits.CopyTo(bytes, 0);
            WriteWord(addr, BitConverter.ToUInt32(bytes, 0));
        }


        //writes large amounts of data from the elf file to the ram array
        public void populateData(byte[] data, uint address)
        {
            Log.WriteToLog("Populating Ram at address: " + address.ToString());
            data.CopyTo(Ram, address);
        }

        //clears the ram array for testing purposes
        public void clearRam()
        {
            Log.WriteToLog("***Clearing all simulated RAM***");
            Array.Clear(Ram, 0, Ram.Length);
        }


        public void PrintArray()
        {
            for(int i = 31; i >= 0; --i)
            {
                if (TestFlag(0, i) == true) { Console.Write("1"); }
                else
                {
                    Console.Write("0");
                }
            }
            Console.Write("\n");
        }
    }//Memory
}
