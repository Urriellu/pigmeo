using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pigmeo.EmbeddedHost {
	class Program {
		static void Main(string[] args) {
			Logger.LogHost("Starting the Pigmeo Embedded Host");
			Logger.LogHost("This program is run on remote systems and allows your main development station to send your own programs to this computer, and execute, monitor and stop them");
			Logger.LogHost("To stop this program, press control+C or close this terminal");
			while (true) Console.ReadKey(true);
		}
	}
}
