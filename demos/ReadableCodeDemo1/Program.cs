using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadableCodeDemo1
{
	/*
	 * 
	 * 
	 * Naming is really important.
	 *
	 * 
	 */
	class Program
	{
		static void Main(string[] args)
		{
			Process(); // TODO: What's this do? Rename the method.
			
			Console.WriteLine("Done with Demo #1.");
			Console.ReadKey();
		}






























































		static void Process()
		{
			string[] files = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mustache", System.IO.SearchOption.AllDirectories);

			foreach (string file in files)
			{
				string modelFilePath = file.Replace(".mustache", ".model");
				string modelFileContents = System.IO.File.ReadAllText(modelFilePath);
				object model = Newtonsoft.Json.JsonConvert.DeserializeObject(modelFileContents);

				string filename = file.Replace(".mustache", ".html");
				Nustache.Core.Render.FileToFile(file, model, filename);
			}
		}
	}
}
