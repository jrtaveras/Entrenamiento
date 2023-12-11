using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {   var destino = @"\\pegasus\Facturas\processed\";
            var files = Directory.GetFiles(@"\\pegasus\Facturas\");
            //foreach (var item in files)
            //{
            //    if (item.Contains("processed")) {
            //        var fileRename = item.Replace("processed", "");
            //        File.Move(item, fileRename);
            //    }
                
            //}
            StringBuilder sb = new StringBuilder();
            foreach (var item in files)
            {
               var fileName = Path.GetFileName(item);
               sb.AppendLine(fileName);
               //File.Move(item, destino + fileName);
            }
            Console.ReadKey();
        }
    }
}
