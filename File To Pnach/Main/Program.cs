﻿using System;
using System.IO;
using System.Text;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Byte[] FileArray;

            try
            {
                FileArray = File.ReadAllBytes(args[0]);
            }
            catch
            {
                Console.WriteLine("Error while reading input file.");
                throw new IOException("could not read file");
            }

            uint offset = Convert.ToUInt32(args[1], 16);

            string[] lines = new string[FileArray.Length + 1];
            lines[0] = "// Generated by File To Pnach by Tupelov";
            for(int i=0; i < FileArray.Length; i++)
            {
                lines[i + 1] = "patch=1,EE," +
                    (offset + (i * 2)).ToString("X8") +
                    ",byte," + FileArray[i].ToString("X2");
            }


            File.WriteAllLines(Directory.GetCurrentDirectory() + "\\"
            + args[2] + ".pnach", lines, Encoding.UTF8);
            Console.WriteLine("Done!");
            Console.ReadLine();
            return;
        }
    }
}
