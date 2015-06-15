using Newtonsoft.Json;
using Nustache.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadableCodeDemo4
{
	class Program
	{
		static void Main(string[] args)
		{
			FindAllMustacheFilesAndRender();

			Console.WriteLine("Done with Dry Demo #1.");
			Console.ReadKey(); // Wait for users to acknowledge completion so that the window doesn't immediately close
		}

		static void FindAllMustacheFilesAndRender()
		{
			IEnumerable<string> mustacheFiles = FindAllMustacheFiles();
			RenderMustacheFiles(mustacheFiles);
		}

		static void RenderMustacheFiles(IEnumerable<string> files)
		{
			foreach (string file in files)
			{
				object model = GetModelForMustacheFile(file);
				string outputPath = file.Replace(".mustache", ".html"); // .mustache here
				Render.FileToFile(file, model, outputPath);
			}
		}

		static IEnumerable<string> FindAllMustacheFiles()
		{
			string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mustache", System.IO.SearchOption.AllDirectories); // .mustache here
			return files;
		}

		static object GetModelForMustacheFile(string mustacheTemplate)
		{
			string modelFilePath = mustacheTemplate.Replace(".mustache", ".model"); // .mustache here
			string modelFileContents = File.ReadAllText(modelFilePath);
			object model = JsonConvert.DeserializeObject(modelFileContents);
			return model;
		}
	}
}
