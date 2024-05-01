
using System.Dynamic;
using System.Runtime.InteropServices;

[DllImport("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
static extern int Multiply(int num1, int num2);

Console.WriteLine("[Calling C++ DLL from C# Console application]"+" Multiply of 5 and 8 is "+ Multiply(5, 8));
