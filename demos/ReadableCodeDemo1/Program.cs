using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadableCodeDemo1
{
	class Program
	{
		static void Main(string[] args)
		{
			Process();

			Console.WriteLine("Done.");
			Console.ReadKey();
		}

		/*
		 *
		 *
		 * Scroll for dramatic effect.
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
		 *   http://www.chris.com/ascii/index.php?art=movies/star%20wars
		 *   
		 *                  c==o
		 *				  _/____\_
		 *		   _.,--'" ||^ || "`z._
		 *		  /_/^ ___\||  || _/o\ "`-._
		 *		_/  ]. L_| || .||  \_/_  . _`--._
		 *	   /_~7  _ . " ||. || /] \ ]. (_)  . "`--.
		 *	  |__7~.(_)_ []|+--+|/____T_____________L|
		 *	  |__|  _^(_) /^   __\____ _   _|
		 *	  |__| (_){_) J ]K{__ L___ _   _]
		 *	  |__| . _(_) \v     /__________|________
		 *	  l__l_ (_). []|+-+-<\^   L  . _   - ---L|
		 *	   \__\    __. ||^l  \Y] /_]  (_) .  _,--'
		 *		 \~_]  L_| || .\ .\\/~.    _,--'"
		 *		  \_\ . __/||  |\  \`-+-<'"
		 *			"`---._|J__L|X o~~|[\\      "Millenium Falcon"
		 *	               \____/ \___|[//      Modified Corellian YT-1300 Transport (1)
		 *					`--'   `--+-'
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
