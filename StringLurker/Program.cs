#define DDEBUG
/*
 * Created by SharpDevelop.
 * User: User
 * Date: 10.02.2022
 * Time: 22:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace StringLurker
{
	class Program
	{
		public static void Main(string[] args)
		{
			#if DDEBUG
			//var dll_path = @"Z:\Il2CppDumper\Cpp2Il\cpp2il_out_1.4.51_foo\Assembly-CSharp.dll";
			var dll_path = @"Z:\Il2CppDumper\Cpp2Il\cpp2il_out_2.4.0\Assembly-CSharp.dll";
			var out_nametran_path = @"Z:\Il2CppDumper\Cpp2Il\cpp2il_out_2.4.0\nameTranslation.gen.txt";
			#else
			if (args.Length < 2)
			{
				Usage();
				return;
			}
			var dll_path = args[0];
			var out_nametran_path = args[1];		
			#endif
			
			AssemblyParser ap = new AssemblyParser(dll_path);
			
			ap.FindExcelClasses();
			
			ap.DumpNametrans(out_nametran_path);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static void Usage() {
			var param_string = "\t{0,-15} {1}";
			
			var usage = string.Join(
				Environment.NewLine,
				"ExcelConfigData classname dumping tool",
				"",
				"Usage:",
				string.Format("\t{0} dll_path out_nametran_path", AppDomain.CurrentDomain.FriendlyName),
				"",
				"Parameters:",
				string.Format(param_string, "dll_path", "Path to the UNHOLLOWED (not Dummy!) Assembly-CSharp.dll"),
				string.Format(param_string, "out_nametran_path", "Path to the generated nameTranslation.txt"),
				""
			);
			Console.WriteLine(usage);
		}
	}
}