using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testDLL;

namespace testApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1() { Test = "ide to" };
			Console.WriteLine($"text: {c.Test}");
			System.Buffers.ArrayPool<string> s;
		}
    }
}
