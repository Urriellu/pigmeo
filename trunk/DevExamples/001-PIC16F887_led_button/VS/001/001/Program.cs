using System;
using Pigmeo;
using Pigmeo.MCU;
using Pigmeo.Extensions;

namespace _001 {
	class Program {
		static void Main() {
			Registers.OSCCON.IRCF2 = false;
			Registers.OSCCON.IRCF1 = false;
			Registers.OSCCON.IRCF0 = false;
			//Registers.OSCCON.IRCF = 0;
			Registers.TRISD = 0;
			Registers.PORTD = 0xff;
			while(true) {
				//Sleep1s();
				Registers.PORTD++;
			}
		}

		static void Sleep1s() {
			//31kHz, 7750 instructions/sec, Tcy=0.00012903226, I need 30 Nop(250) or 5 Nop(1531)
			//by default: 4MHz, 1000000 instr/sec, I need 4000 Nop(250)
			//8MHz, 2000000 instr/sec, I would need 8000 Nop(250)
			Processor.Nop(1531);
			Processor.Nop(1531);
			Processor.Nop(1531);
			Processor.Nop(1531);
			Processor.Nop(1531);
		}
	}
}
