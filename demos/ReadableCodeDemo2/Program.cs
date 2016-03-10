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
	 * Name methods what they do.
	 * Keep methods focused on a single task.
	 */
	class Program
	{
		static void Main(string[] args)
		{
			FindAllMustacheFilesAndRenderToHTML();

			Console.WriteLine("Done.");
			Console.ReadKey();
		}

		/*
		 *             |~
		 *			   |.---.
		 *			  .'_____`. /\
		 *			  |~xxxxx~| ||
		 *			  |_  #  _| ||
		 *		 .------`-#-'-----.
		 *		(___|\_________/|_.`.
		 *		 /  | _________ | | |
		 *		/   |/   _|_   \| | |
		 *	   /   /X|  __|__  |/ `.|
		 *	  (  --< \\/    _\//|_ |`.
		 *	  `.    ~----.-~=====,:=======
		 *		~-._____/___:__(``/| |
		 *		  |    |      XX|~ | |
		 *		   \__/======| /|  `.|
		 *		   |_\|\    /|/_|    )
		 *		   |_   \__/   _| .-'
		 *		   | \ .'||`. / |(_|
		 *		LS |  ||.'`.||  |   )
		 *		   |  `'|  |`'  |  /
		 *		   |    |  |    |\/   Boba Fett
		 * 
		 * http://www.chris.com/ascii/index.php?art=movies/star%20wars
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 * 
		 *       
		 */

		static void FindAllMustacheFilesAndRenderToHTML()
		{
			IEnumerable<string> mustacheFiles = FindAllMustacheFilePaths();
			RenderMustacheFilesToHTML(mustacheFiles);
		}

		static IEnumerable<string> FindAllMustacheFilePaths()
		{
			string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mustache", System.IO.SearchOption.AllDirectories);
			return files;
		}

		static void RenderMustacheFilesToHTML(IEnumerable<string> files)
		{
			foreach (string file in files)
			{
				RenderMustacheFile(file);
			}
		}

		static void RenderMustacheFile(string file)
		{
			object model = GetModelForMustacheFile(file);
			string outputPath = file.Replace(".mustache", ".html");
			Nustache.Core.Render.FileToFile(file, model, outputPath);
		}

		static object GetModelForMustacheFile(string mustacheTemplate)
		{
			string modelFilePath = mustacheTemplate.Replace(".mustache", ".model");
			string modelFileContents = File.ReadAllText(modelFilePath);
			object model = JsonConvert.DeserializeObject(modelFileContents);
			return model;
		}
	}
}