using Newtonsoft.Json;
using Nustache.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadableCodeDemo3
{
	/*
	 * Readable Code
	 * 
	 * Maintain comments that explain why code was written.
	 * If it doesn't answer "why", it's not worth maintaining.
	 * 
	 */
	class Program
	{
		static void Main(string[] args)
		{
			// Process all the files
			FindAllMustacheFilesAndRender();

			// Wait for users to acknowledge completion
			Console.WriteLine("Done with Demo #3.");
			Console.ReadKey();
		}

		/// <summary>
		/// Finds all the Mustache files in the application directory and renders them with their paired .model data.
		/// </summary>
		static void FindAllMustacheFilesAndRender()
		{
			IEnumerable<string> mustacheFiles = FindAllMustacheFiles(); // Get all the mustache files
			RenderMustacheFiles(mustacheFiles); // Render the files
		}

		/// <summary>
		/// Renders a set of mustache files.
		/// </summary>
		/// <param name="files">A set of file paths to each mustache template</param>
		static void RenderMustacheFiles(IEnumerable<string> files)
		{
			// Loop over the files
			foreach (string file in files)
			{
				object model = GetModelForMustacheFile(file);
				string outputPath = file.Replace(".mustache", ".html"); // Get the output path name
				Render.FileToFile(file, model, outputPath); // Run through the mustache parser
			}
		}

		/// <summary>
		/// Finds all the mustache templates in our application directory (includes subdirectories).
		/// </summary>
		/// <returns>A set of file paths to each mustache template</returns>
		static IEnumerable<string> FindAllMustacheFiles()
		{
			string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mustache", System.IO.SearchOption.AllDirectories);
			return files;
		}

		/// <summary>
		/// Given a mustache file template path, looks up a corresponding model object and returns a deserialized version.
		/// </summary>
		/// <param name="mustacheTemplate">The file path to the mustache template</param>
		/// <returns>A POCO data model for the mustache file.</returns>
		static object GetModelForMustacheFile(string mustacheTemplate)
		{
			string modelFilePath = mustacheTemplate.Replace(".mustache", ".model");
			string modelFileContents = File.ReadAllText(modelFilePath);
			object model = JsonConvert.DeserializeObject(modelFileContents);
			return model;
		}
	}
}
