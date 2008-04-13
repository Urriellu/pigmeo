using System;
using Pigmeo;
using Pigmeo.Extensions;
using Pigmeo.MCU;

namespace Example001 {
	class Program {
		static byte foo;

		static void Main(string[] args) {
			foo = Registers.PORTA;
			while(true) {
				foo++;
			}
		}
	}
}
