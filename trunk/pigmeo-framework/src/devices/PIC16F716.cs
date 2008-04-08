using Pigmeo;
using Pigmeo.Extensions;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Reflection;

[assembly: AssemblyVersion("0.1")]
[assembly: DeviceLibrary(Architecture.PIC14, Branch.PIC16F716)]
[assembly: AssemblyKeyFile("../../../pigmeo.key")]

namespace Pigmeo.MCU {
	/// <summary>
	/// Constains all the information about the PIC
	/// </summary>
	public static class Info {
		public static InfoPIC8bit GetInfo() {
			InfoPIC8bit device = new InfoPIC8bit();

			device.arch = Architecture.PIC14;
			device.branch = Branch.PIC16F716;
			device.DataMemory = new DataMemoryBankPIC[2];
			device.DataMemory[0].FirstSFR = 0x00;
			device.DataMemory[0].LastSFR = 0x1F;
			device.DataMemory[0].FirstGPR = 0x20;
			device.DataMemory[0].LastGPR = 0x7F;
			device.DataMemory[1].FirstSFR = 0x00;
			device.DataMemory[1].LastSFR = 0x1F;
			device.DataMemory[1].FirstGPR = 0x20;
			device.DataMemory[1].LastGPR = 0x3F;
			device.MaxWords = 2048;
			device.IncludeFile = "p16f716.inc";

			return device;
		}
	}

	public static class Registers {
		/// <summary>
		/// Addressing this location uses contents of FSR to address data memory (not a physical register)
		/// </summary>
		[AsmName("INDF"), Location(0, 0x00)]
		public static byte INDF = 0;

		/// <summary>
		/// Timer0 module's register
		/// </summary>
		[AsmName("TMR0"), Location(0, 0x01)]
		public static byte TMR0 = 0;

		/// <summary>
		/// Program Counter's (PC) Least Significant Byte
		/// </summary>
		[AsmName("PCL"), Location(0, 0x02)]
		public static byte PCL = 0;

		/// <summary>
		/// Contains the arithmetic status of the ALU, the Reset status and the bank select bits for data memory
		/// </summary>
		public static class STATUS {
			/// <summary>Register Bank Select bit (used for direct addressing). RP0=false for bank 0, RP0=true for bank 1</summary>
			[Location(0, 3, 5)]
			public static bool RP0 = false;

			/// <summary>Time-out bit. INVERTED. true = After power-up, CLRWDT instruction or SLEEP instruction. false = A WDT time-out occurred</summary>
			[Location(0, 3, 4)]
			public static readonly bool _TO = true;

			/// <summary>Power-down bit. INVERTED. true = After power-up or by the CLRWDT instruction. false = By execution of the SLEEP instruction</summary>
			[Location(0, 3, 3)]
			public static readonly bool _PD = true;

			/// <summary>Zero bit. true = The result of an arithmetic or logic operation is zero. false = The result of an arithmetic or logic operation is not zero</summary>
			[Location(0, 3, 2)]
			public static bool Z;

			/// <summary>Digit Carry/_Borrow bit (ADDWF, ADDLW,SUBLW,SUBWF instructions). For Borrow, the polarity is reversed. true = A carry-out from the 4th low-order bit of the result occurred. false = No carry-out from the 4th low-order bit of the result</summary>
			[Location(0, 3, 1)]
			public static bool DC;

			/// <summary>Carry/_Borrow bit (ADDWF, ADDLW, SUBLW, SUBWF instructions). true = A carry-out from the Most Significant bit of the result occurred. false = No carry-out from the Most Significant bit of the result occurred</summary>
			/// <remarks>For Borrow, the polarity is reversed. A subtraction is executed by adding the two's complement of the second operand. For rotate (RRF, RLF) instructions, this bit is loaded with either the high-order or low-order bit of the source register.</remarks>
			[Location(0, 3, 0)]
			public static bool C;
		}

		/// <summary>
		/// Indirect Data Memory Address Pointer
		/// </summary>
		[AsmName("FSR"), Location(0, 0x04)]
		public static byte FSR = 0;

		[AsmName("PORTA"), Location(0,0x05)]
		public static byte PORTA = 0;


		[AsmName("PORTB"), Location(0, 0x06)]
		public static byte PORTB = 0;

		/// <summary>
		/// Write Buffer for the upper 5 bits of the Program Counter
		/// </summary>
		[AsmName("PCLATH"), Location(0, 0x0A)]
		public static byte PCLATH = 0;

		/// <summary>
		/// Contains various enable and flag bits for the TMR0 register overflow, RB Port change and external RB0/INT pin interrupts
		/// </summary>
		public static class INTCON {
			/// <summary>
			/// Global Interrupt Enable bit. true = Enables all unmasked interrupts. false = Disables all interrupts
			/// </summary>
			[Location(0, 0x0B, 7)]
			public static bool GIE = false;

			/// <summary>
			/// Peripheral Interrupt Enable bit. true = Enables all unmasked peripheral interrupts. false = Disables all peripheral interrupts
			/// </summary>
			[Location(0, 0x0B, 6)]
			public static bool PEIE = false;

			/// <summary>
			/// Timer0 Overflow Interrupt Enable bit. true = Enables the Timer0 interrupt. false = Disables the Timer0 interrupt
			/// </summary>
			[Location(0, 0x0B, 5)]
			public static bool T0IE = false;

			/// <summary>
			/// RB0/INT External Interrupt Enable bit. true = Enables the RB0/INT external interrupt. false = Disables the Timer0 interrupt
			/// </summary>
			[Location(0, 0x0B, 4)]
			public static bool INTE = false;

			/// <summary>
			/// PORTB Change Interrupt Enable bit. true = Enables the PORTB change interrupt. false = Disables the PORTB change interrupt
			/// </summary>
			/// <remarks>
			/// IOCB register must also be enabled
			/// </remarks>
			[Location(0, 0x0B, 3)]
			public static bool RBIE = false;

			/// <summary>
			/// Timer0 Overflow Interrupt Flag bit. true = TMR0 register has overflowed. false = TMR0 register did not overflow
			/// </summary>
			/// <remarks>
			/// T0IF bit is set when Timer0 rolls over. Timer0 is unchanged on Reset and should be initialized before clearing T0IF bit
			/// </remarks>
			[Location(0, 0x0B, 2)]
			public static bool T0IF = false;

			/// <summary>
			/// RB0/INT External Interrupt Flag bit. true = The RB0/INT external interrupt occurred. false = The RB0/INT external interrupt did not occur
			/// </summary>
			[Location(0, 0x0B, 1)]
			public static bool INTF = false;

			/// <summary>
			/// PORTB Change Interrupt Flag bit. true = When at least one of the PORTB general purpose I/O pins changed state. false = None of the PORTB general purpose I/O pins have changed state
			/// </summary>
			[Location(0, 0x0B, 0)]
			public static bool RBIF = false;
		}

		/// <summary>
		/// 
		/// </summary>
		public static class PIR1 {
			[Location(0, 0x0C, 6)]
			public static bool ADIF = false;

			[Location(0, 0x0C, 2)]
			public static bool CCP1IF = false;

			[Location(0, 0x0C, 1)]
			public static bool TMR2IF = false;

			[Location(0, 0x0C, 0)]
			public static bool TMR1IF = false;
		}

		[AsmName("TMR1L"), Location(0, 0x0E)]
		public static byte TMR1L = 0;

		[AsmName("TMR1H"), Location(0, 0x0F)]
		public static byte TMR1H = 0;

		public static class T1CON {
			[Location(0, 0x10, 5)]
			public static bool T1CKPS1 = false;

			[Location(0, 0x10, 4)]
			public static bool T1CKPS0 = false;

			[Location(0, 0x10, 3)]
			public static bool T1OSCEN = false;

			[Location(0, 0x10, 2)]
			public static bool _T1SYNC = false;

			[Location(0, 0x10, 1)]
			public static bool TMR1CS = false;

			[Location(0, 0x10, 0)]
			public static bool TMR1ON = false;
		}

		/* Remaining:
		 * bank 0:
		 * T1CON
		 * TMR2
		 * T2CON
		 * CCPR1L
		 * CCPR1H
		 * PWM1CON
		 * ECCPAS
		 * ADRES
		 * ADCON0
		 * bank 1:
		 * INDF ?
		 * OPTION_REG
		 * PCL ?
		 * STATUS ?
		 * FSR ?
		 * TRISA
		 * TRISB
		 * PCLATH
		 * INTCON
		 * PIE (done)
		 * PCON
		 * PR2
		 * ADCON1
		 */ 

		/// <summary>
		/// Contains the individual enable bits for the peripheral interrupts.
		/// </summary>
		public static class PIE1 {
			/// <summary>
			/// A/D Converter (ADC) Interrupt Enable bit. true = Enables the ADC interrupt. false = Disables the ADC interrupt
			/// </summary>
			[Location(1, 0x8C, 6)]
			public static bool ADIE = false;

			/// <summary>
			/// CCP1 Interrupt Enable bit. true = Enables the CCP1 interrupt. false = Disables the CCP1 interrupt
			/// </summary>
			[Location(1, 0x8C, 2)]
			public static bool CCP1IE = false;

			/// <summary>
			/// Timer2 to PR2 Match Interrupt Enable bit. true = Enables the Timer2 to PR2 match interrupt. false = Disables the Timer2 to PR2 match interrupt
			/// </summary>
			[Location(1, 0x8C, 1)]
			public static bool TMR2IE = false;

			/// <summary>
			/// Timer1 Overflow Interrupt Enable bit. true = Enables the Timer1 overflow interrupt. false = Disables the Timer1 overflow interrupt
			/// </summary>
			[Location(1, 0x8C, 0)]
			public static bool TMR1IE = false;
		}
	}
}
