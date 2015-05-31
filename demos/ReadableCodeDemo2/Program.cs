using Newtonsoft.Json;
using Nustache.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadableCodeDemo2
{
	/*
	 * 
	 * 
	 * Keep methods focused on a single task
	 *
	 * 
	 */
	class Program
	{
		static void Main(string[] args)
		{
			FindAllMustacheFilesAndRender();

			Console.WriteLine("Done with Demo #2.");
			Console.ReadKey();
		}

		static void FindAllMustacheFilesAndRender()
		{
			// TODO: This method is trying to do too much at once.  Split up: Find all the mustache files, Rendering the mustache files.
			string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mustache", System.IO.SearchOption.AllDirectories); // Get all the mustache files
			foreach (string file in files) // Render all the mustache files
			{
				string modelFilePath = file.Replace(".mustache", ".model");
				string modelFileContents = File.ReadAllText(modelFilePath);
				object model = JsonConvert.DeserializeObject(modelFileContents);

				string filename = file.Replace(".mustache", ".html");
				Render.FileToFile(file, model, filename);
			}
		}
	}
}
