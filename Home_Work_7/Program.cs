using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;

namespace Home_Work_7._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Diary diar = new Diary("file.dat");
            diar.Display();

        }

    }
}
