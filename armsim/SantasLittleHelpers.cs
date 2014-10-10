﻿using System;
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
    public class SantasLittleHelpers
    {

        //finds and saves all of the program headers 
        FileStream strm;
        public bool decodeHeaders(string args, Memory mem)
        {
            List<ELFData> elfData = new List<ELFData>();

            if (args == "")
            {
                Log.WriteToLog("Usage: ReadElf <elf file>");

            }

            string elfFilename = args;

            try
            {
                Log.WriteToLog("Attempting to open ELF file: " + elfFilename);
                using (strm = new FileStream(elfFilename, FileMode.Open))
                {
                    ELF elfHeader = new ELF();
                    byte[] data = new byte[Marshal.SizeOf(elfHeader)];

                    // Read ELF header data
                    strm.Read(data, 0, data.Length);
                    // Convert to struct
                    elfHeader = ByteArrayToStructure<ELF>(data);//use this

                    Log.WriteToLog("Entry point: " + elfHeader.e_entry.ToString("X4"));
                    Log.WriteToLog("Number of program header entries: " + elfHeader.e_phnum);

                    // Read first program header entry
                    strm.Seek(elfHeader.e_phoff, SeekOrigin.Begin);//these two put them in for loop
                    Log.WriteToLog("Number of elf segment headers to read: " + elfHeader.e_phnum.ToString());
                    for (int i = 0; i < elfHeader.e_phnum; ++i)
                    {
                        data = new byte[elfHeader.e_phentsize];
                        strm.Read(data, 0, (int)elfHeader.e_phentsize);
                        ELFData header = ByteArrayToStructure<ELFData>(data);
                        Log.WriteToLog("Populating struct header: " + (i + 1).ToString());
                        elfData.Add(header);
                    }
                    foreach (ELFData hd in elfData) //
                    {
                        byte[] info = getData(hd, args);
                        mem.populateData(data, hd.p_paddr);
                    }
                }
            }
            catch
            {
                Console.WriteLine("The selected file could not be opened or could not be found.");
                return false;

            }
            return true;

        }

        // Converts a byte array to a struct
        static T ByteArrayToStructure<T>(byte[] bytes) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            T stuff = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),
                typeof(T));
            handle.Free();
            return stuff;
        }


        //recieves a struct of header data and reads in the section from the ELF file
        public byte[] getData(ELFData header, string filename)
        {
            int size = (int)header.p_memsz;
            byte[] data = new byte[size];
            Log.WriteToLog("Reading ELF data from file.");

            strm.Seek(header.p_offset, SeekOrigin.Begin);
            strm.Read(data, 0, data.Length);

            return data;
        }

    }
}
