using System;
using System.Runtime.InteropServices;
using System.IO;

namespace SyscallTest
{
	class MainClass
	{
		[DllImport("SyscallTest", EntryPoint = "chmodsc")]
		public static extern int NativeChmod(string filename, int accessMask);

		public static void Main (string[] args)
		{
			Console.WriteLine ("Input filename");
			var filename = Console.ReadLine ();

			if (!File.Exists (filename)) 
			{
				Console.WriteLine ("The file specified does not exist");
				return;
			}

			Console.WriteLine ("Input access mask");
			var accessMaskString = Console.ReadLine ();
			var accessMask = 0;

			if (!int.TryParse (accessMaskString, out accessMask)) 
			{
				Console.WriteLine ("Invalid access mask specified");
				return;
			}

			var callResult = NativeChmod (filename, accessMask);
			Console.WriteLine ("chmod result: " + callResult);
		}
	}
}
