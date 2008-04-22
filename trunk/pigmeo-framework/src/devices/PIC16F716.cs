using Pigmeo;
using Pigmeo.Extensions;
using Pigmeo.Internal;
using Pigmeo.Internal.PIC14;
using System;
using System.Reflection;
using Pigmeo.Physics;

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
		/// <remarks>
		/// The upper byte of the program counter is not directly accessible. PCLATH is a holding register for PC[12:8] whose contents are transferred to the upper byte of the program counter
		/// </remarks>
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
		/// Contains the individual flag bits for the peripheral interrupts
		/// </summary>
		public static class PIR1 {
			/// <summary>
			/// A/D Interrupt Flag bit. true = A/D conversion complete. false = A/D conversion has not completed or has not been started
			/// </summary>
			[Location(0, 0x0C, 6)]
			public static bool ADIF = false;

			/// <summary>
			/// CCP1 Interrupt Flag bit. Capture Mode {true = A TMR1 register capture occurred (must be cleared in software), false = No TMR1 register capture occurred}. Compare Mode {true = A TMR1 register compare match occurred (must be cleared in software), false = No TMR1 register compare match occurred}. PWM Mode {Unused in this mode}
			/// </summary>
			[Location(0, 0x0C, 2)]
			public static bool CCP1IF = false;

			/// <summary>
			/// Timer2 to PR2 Match Interrupt Flag bit. true = Timer2 to PR2 match occurred (must be cleared in software). false = Timer2 to PR2 match occurred (must be cleared in software)
			/// </summary>
			[Location(0, 0x0C, 1)]
			public static bool TMR2IF = false;

			/// <summary>
			/// Timer1 Overflow Interrupt Flag bit. true = Timer1 register overflowed (must be cleared in software). false = Timer1 register overflowed (must be cleared in software)
			/// </summary>
			[Location(0, 0x0C, 0)]
			public static bool TMR1IF = false;
		}

		/// <summary>
		/// Holding Register for the Least Significant Byte of the 16-bit TMR1 Register
		/// </summary>
		[AsmName("TMR1L"), Location(0, 0x0E)]
		public static byte TMR1L = 0;

		/// <summary>
		/// Holding Register for the Most Significant Byte of the 16-bit TMR1 Register
		/// </summary>
		[AsmName("TMR1H"), Location(0, 0x0F)]
		public static byte TMR1H = 0;

		/// <summary>
		/// It's used to control Timer1 and select the various features of the Timer1 module
		/// </summary>
		public static class T1CON {
			/// <summary>
			/// Timer1 Input Clock Prescale Select bit 1
			/// </summary>
			[Location(0, 0x10, 5)]
			public static bool T1CKPS1 = false;

			/// <summary>
			///  Timer1 Input Clock Prescale Select bit 0
			/// </summary>
			[Location(0, 0x10, 4)]
			public static bool T1CKPS0 = false;

			/// <summary>
			/// Timer1 Oscillator Enable Control bit. true = Timer1 oscillator is enabled, false = Timer1 oscillator is disabled
			/// </summary>
			[Location(0, 0x10, 3)]
			public static bool T1OSCEN = false;

			/// <summary>
			/// Timer1 External Clock Input Synchronization Control bit. INVERTED. If TMR1CS==false {This bit is ignored. Timer1 uses the internal clock}. If TMR1CS==true {true = Do not synchronize external clock input, false = Synchronize external clock input}
			/// </summary>
			[Location(0, 0x10, 2)]
			public static bool _T1SYNC = false;

			/// <summary>
			/// Timer1 Clock Source Select bit. true = External clock from T1CKI pin (on the rising edge). false = Internal clock (Fosc/4)
			/// </summary>
			[Location(0, 0x10, 1)]
			public static bool TMR1CS = false;

			/// <summary>
			/// Timer1 On bit. true = Enables Timer1. false = Stops Timer1
			/// </summary>
			[Location(0, 0x10, 0)]
			public static bool TMR1ON = false;
		}

		/// <summary>
		/// Timer2 Module's Register
		/// </summary>
		[AsmName("TMR2"), Location(0, 0x11)]
		public static byte TMR2 = 0;



		/* Remaining:
		 * bank 0:
		 * T2CON
		 * CCPR1L
		 * CCPR1H
		 * PWM1CON
		 * ECCPAS
		 * ADRES
		 * ADCON0
		 * 
		 * bank 1:
		 * INDF ?
		 * PCL ?
		 * STATUS ?
		 * FSR ?
		 * PCLATH ?
		 * INTCON ?
		 */

		/// <summary>
		/// It's a readable and writable register, which contains various control bits to configure the TMR0 prescaler/WDT postscaler (single assignable register known also as the prescaler), the External INT Interrupt, TMR0 and the weak pull-ups on PORTB.
		/// </summary>
		public static class OPTION_REG {
			/// <summary>
			/// PORTB Pull-up Enable bit. INVERTED. true = PORTB pull-ups are disabled. false = PORTB pull-ups are enabled by individual PORT latch values
			/// </summary>
			[Location(1, 0x01, 7)]
			public static bool _RBPU = true;

			/// <summary>
			/// Interrupt Edge Select bit. true = Interrupt on rising edge of RB0/INT pin. false = Interrupt on falling edge of RB0/INT pin
			/// </summary>
			[Location(1, 0x01, 6)]
			public static bool INTEDG = true;

			/// <summary>
			/// Timer0 Clock Source Select bit. true = Transition on T0CKI pin. false = Internal instruction cycle clock (Fosc/4)
			/// </summary>
			[Location(1, 0x01, 5)]
			public static bool T0CS = true;

			/// <summary>
			/// Timer0 Source Edge Select bit. true = Increment on high-to-low transition on RA4/T0CKI pin. false = Increment on low-to-high transition on RA4/T0CKI pin
			/// </summary>
			[Location(1, 0x01, 4)]
			public static bool T0SE = true;

			/// <summary>
			/// Prescaler Assignment bit. true = Prescaler is assigned to the WDT. false = Prescaler is assigned to the Timer0 module
			/// </summary>
			[Location(1, 0x01, 3)]
			public static bool PSA = true;

			/// <summary>
			/// Prescaler Rate Select bit 2
			/// </summary>
			[Location(1, 0x01, 2)]
			public static bool PS2 = true;

			/// <summary>
			/// Prescaler Rate Select bit 1
			/// </summary>
			[Location(1, 0x01, 1)]
			public static bool PS1 = true;

			/// <summary>
			/// Prescaler Rate Select bit 0
			/// </summary>
			[Location(1, 0x01, 0)]
			public static bool PS0 = true;
		}

		/// <summary>
		/// PORTA data direction register. true = Input. false = Output
		/// </summary>
		[AsmName("TRISA"), Location(1, 0x05)]
		public static byte TRISA = 0;

		/// <summary>
		/// PORTB data direction register. true = Input. false = Output
		/// </summary>
		[AsmName("TRISB"), Location(1, 0x06)]
		public static byte TRISB = 0;

		/// <summary>
		/// Contains the individual enable bits for the peripheral interrupts.
		/// </summary>
		public static class PIE1 {
			/// <summary>
			/// A/D Converter (ADC) Interrupt Enable bit. true = Enables the ADC interrupt. false = Disables the ADC interrupt
			/// </summary>
			[Location(1, 0x0C, 6)]
			public static bool ADIE = false;

			/// <summary>
			/// CCP1 Interrupt Enable bit. true = Enables the CCP1 interrupt. false = Disables the CCP1 interrupt
			/// </summary>
			[Location(1, 0x0C, 2)]
			public static bool CCP1IE = false;

			/// <summary>
			/// Timer2 to PR2 Match Interrupt Enable bit. true = Enables the Timer2 to PR2 match interrupt. false = Disables the Timer2 to PR2 match interrupt
			/// </summary>
			[Location(1, 0x0C, 1)]
			public static bool TMR2IE = false;

			/// <summary>
			/// Timer1 Overflow Interrupt Enable bit. true = Enables the Timer1 overflow interrupt. false = Disables the Timer1 overflow interrupt
			/// </summary>
			[Location(1, 0x0C, 0)]
			public static bool TMR1IE = false;
		}

		/// <summary>
		/// The Power Control (PCON) register contains a flag bit to allow differentiation between a Power-on Reset (POR) to an external MCLR Reset or WDT Reset. These devices contain an additional bit to differentiate a Brown-out Reset condition from a Power-on Reset condition
		/// </summary>
		public static class PCON {
			/// <summary>
			/// Power-on Reset Status bit. INVERTED. true = No Power-on Reset occurred. false = A Power-on Reset occurred (must be set in software after a Power-on Reset occurs)
			/// </summary>
			[Location(1, 0x0E, 1)]
			public static bool _POR = false;

			/// <summary>
			/// Brown-out Reset Status bit. INVERTED. true = No Brown-out Reset occurred. false = A Brown-out Reset occurred (must be set in software after a Brown-out Reset occurs)
			/// </summary>
			[Location(1, 0x0E, 0)]
			public static bool _BOR = false;
		}

		/// <summary>
		/// Timer2 Period Register
		/// </summary>
		[AsmName("PR2"), Location(1, 0x12)]
		public static byte PR2 = 0xFF;

		/// <summary>
		/// A/D Control Register 1
		/// </summary>
		public static class ADCON1 {
			/// <summary>
			/// A/D Port Configuration Control bit 2
			/// </summary>
			[Location(1, 0x1F, 2)]
			public static bool PCFG2 = false;

			/// <summary>
			/// A/D Port Configuration Control bit 1
			/// </summary>
			[Location(1, 0x1F, 1)]
			public static bool PCFG1 = false;

			/// <summary>
			/// A/D Port Configuration Control bit 0
			/// </summary>
			[Location(1, 0x1F, 0)]
			public static bool PCFG0 = false;
		}
	}
}

namespace Pigmeo.MCU {
	public enum DigitalIOConfig { Input, Output }

	/// <summary>
	/// Available Timer0 sources. These are the available ways of incrementing the value of TMR0 registers
	/// </summary>
	public enum Tmr0ClockSource {
		/// <summary>
		/// Transition on T0CKI pin
		/// </summary>
		T0CKI,
		/// <summary>
		/// Internal instruction cycle clock (Fosc/4)
		/// </summary>
		Internal
	}

	public class PORTA {
		public void ConfigAllBitsAs(DigitalIOConfig value) {
			switch(value) {
				case DigitalIOConfig.Input:
					Registers.TRISA = 0xFF;
					break;
				case DigitalIOConfig.Output:
					Registers.TRISA = 0;
					break;
			}
		}

		public Delegates.ReadBool ReadPin0 = new Delegates.ReadBool(Pin0Reader);
		public Delegates.SetBool WritePin0 = new Delegates.SetBool(Pin0Writer);

		private static bool Pin0Reader() {
			return Registers.PORTA.GetBit(0);
		}

		private static void Pin0Writer(bool value) {
			Registers.PORTA.SetBit(0, value);
		}
	}

	public class PORTB {
		public void ConfigAllBitsAs(DigitalIOConfig value) {
			switch(value) {
				case DigitalIOConfig.Input:
					Registers.TRISB = 0xFF;
					break;
				case DigitalIOConfig.Output:
					Registers.TRISB = 0;
					break;
			}
		}
	}

	public class TMR0 {
		/// <summary>
		/// Clears the interrupt flag
		/// </summary>
		public void ClearIF() {
			Registers.INTCON.T0IF = false;
		}

		public void EnableInterrupts() {
			Registers.INTCON.T0IE = true;
			Registers.INTCON.PEIE = true;
			Registers.INTCON.GIE = true;
			ClearIF();
		}

		public void DisableInterrupts(){
			Registers.INTCON.T0IE=false;
		}

		public void Restart() {
			Registers.TMR0 = 0;
		}

		public bool Overflowed {
			get {
				return Registers.INTCON.T0IF;
			}
		}
		public bool HasInterruptsEnabled {
			get {
				return (Registers.INTCON.GIE && Registers.INTCON.PEIE && Registers.INTCON.T0IE);
			}
		}

		/// <summary>
		/// Configures the Timer 0
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqPrefix">Oscillator frequency value prefix</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured</param>
		/// <param name="Period">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		/// <param name="PerPrefix">Period prefix</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		public void Configure(bool enableInterrupts, Tmr0ClockSource source, float frequency, SIPrefixes FreqPrefix, FrequencyUnits FreqUnit, float Period, SIPrefixes PerPrefix, TimeUnits PeriodUnit) {
			Configure(enableInterrupts, source, new Frequency(frequency, FreqPrefix, FreqUnit), new Period(Period, PerPrefix, PeriodUnit));
		}

		/// <summary>
		/// Configures the Timer 0
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured. International System of Units</param>
		/// <param name="period">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		public void Configure(bool enableInterrupts, Tmr0ClockSource source, float frequency, FrequencyUnitsSI FreqUnit, float period, TimeUnitsSI PeriodUnit) {
			Configure(enableInterrupts, source, new Frequency(frequency, FreqUnit), new Period(period, PeriodUnit));
		}

		/// <summary>
		/// Configures the Timer 0
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="Fosc">Oscillator frequency</param>
		/// <param name="Ttmr">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		[PigmeoToDo("algorithm not designed yet")]
		public void Configure(bool enableInterrupts, Tmr0ClockSource source, Frequency Fosc, Period Ttmr) {
			if(enableInterrupts) this.EnableInterrupts();
			//...
		}

		public void SetClockSource(Tmr0ClockSource source) {
			switch(source) {
				case Tmr0ClockSource.T0CKI:
					Registers.OPTION_REG.T0CS = true;
					break;
				case Tmr0ClockSource.Internal:
					Registers.OPTION_REG.T0CS = false;
					break;
			}
		}
	}

	public sealed class Ports {
		public static PORTA A = new PORTA();
		public static PORTB B = new PORTB();
	}

	public sealed class Timers {
		public static TMR0 Timer0 = new TMR0();
	}
}
