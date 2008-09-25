using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		/// <summary>
		/// It's a readable and writable register, which contains various control bits to configure the TMR0 prescaler/WDT postscaler (single assignable register known also as the prescaler), the External INT Interrupt, TMR0 and the weak pull-ups on PORTB.
		/// </summary>
		public static class OPTION_REG {
			/// <summary>
			/// PORTB Pull-up Enable bit. INVERTED. true = PORTB pull-ups are disabled. false = PORTB pull-ups are enabled by individual PORT latch values
			/// </summary>
			[AsmName("NOT_RBPU"), Location(true)]
			public volatile static bool _RBPU = true;

			/// <summary>
			/// Interrupt Edge Select bit. true = Interrupt on rising edge of RB0/INT pin. false = Interrupt on falling edge of RB0/INT pin
			/// </summary>
			[AsmName("INTEDG"), Location(true)]
			public volatile static bool INTEDG = true;

			/// <summary>
			/// Timer0 Clock Source Select bit. true = Transition on T0CKI pin. false = Internal instruction cycle clock (Fosc/4)
			/// </summary>
			[AsmName("T0CS"), Location(true)]
			public volatile static bool T0CS = true;

			/// <summary>
			/// Timer0 Source Edge Select bit. true = Increment on high-to-low transition on RA4/T0CKI pin. false = Increment on low-to-high transition on RA4/T0CKI pin
			/// </summary>
			[AsmName("T0SE"), Location(true)]
			public volatile static bool T0SE = true;

			/// <summary>
			/// Prescaler Assignment bit. true = Prescaler is assigned to the WDT. false = Prescaler is assigned to the Timer0 module
			/// </summary>
			[AsmName("PSA"), Location(true)]
			public volatile static bool PSA = true;

			/// <summary>
			/// Prescaler Rate Select bit 2
			/// </summary>
			[AsmName("PS2"), Location(true)]
			public volatile static bool PS2 = true;

			/// <summary>
			/// Prescaler Rate Select bit 1
			/// </summary>
			[AsmName("PS1"), Location(true)]
			public volatile static bool PS1 = true;

			/// <summary>
			/// Prescaler Rate Select bit 0
			/// </summary>
			[AsmName("PS0"), Location(true)]
			public volatile static bool PS0 = true;
		}
	}
}