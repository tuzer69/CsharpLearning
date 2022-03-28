using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Home_Work_8._6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем организацию
            Organization org = new Organization();
            //Выводим пустую БД на экран
            org.Display();





            Console.ReadKey();

        }


    }
}
