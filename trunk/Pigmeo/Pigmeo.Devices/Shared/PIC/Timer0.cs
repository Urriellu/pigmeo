using Pigmeo.Internal.PIC;
using System;
using Pigmeo.Physics;
using Pigmeo.Internal;

namespace Pigmeo.MCU {
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

	public static partial class Registers {
		/// <summary>
		/// Timer0 module's register
		/// </summary>
		[AsmName("TMR0"), Location(true)]
		public volatile static byte TMR0 = 0;
	}

	/// <summary>
	/// Timer 0: integrated 8-bit timer/counter with prescaler, programmable internal or external clock source, programmable external clock edge selection and interrupt on overflow
	/// </summary>
	public class TMR0:ITimer, ITimerInterrupts {
		/// <summary>
		/// Clears the interrupt flag
		/// </summary>
		public void ClearIF() {
			Registers.INTCON.T0IF = false;
		}

		/// <summary>
		/// Enables the interrupts thrown by Timer 0
		/// </summary>
		public void EnableInterrupts() {
			Registers.INTCON.T0IE = true;
			Registers.INTCON.PEIE = true;
			Registers.INTCON.GIE = true;
			ClearIF();
		}

		/// <summary>
		/// Configure the prescaler to the Timer0 (not the watchdog)
		/// </summary>
		/// <param name="rate">Timer0 desired rate. It must be 1, 2, 4, 8, 16, 32, 64, 128 or 256</param>
		public void SetPrescaler(UInt16 rate) {
			switch(rate) {
				case 1:
					Registers.OPTION_REG.PS0 = false;
					Registers.OPTION_REG.PS1 = false;
					Registers.OPTION_REG.PS2 = false;
					Registers.OPTION_REG.PSA = true; //assign to the watchdog
					break;
				case 2:
					Registers.OPTION_REG.PS0 = false;
					Registers.OPTION_REG.PS1 = false;
					Registers.OPTION_REG.PS2 = false;
					Registers.OPTION_REG.PSA = false;
					break;
				case 4:
					Registers.OPTION_REG.PS0 = true;
					Registers.OPTION_REG.PS1 = false;
					Registers.OPTION_REG.PS2 = false;
					Registers.OPTION_REG.PSA = false;
					break;
				case 8:
					Registers.OPTION_REG.PS0 = false;
					Registers.OPTION_REG.PS1 = true;
					Registers.OPTION_REG.PS2 = false;
					Registers.OPTION_REG.PSA = false;
					break;
				case 16:
					Registers.OPTION_REG.PS0 = true;
					Registers.OPTION_REG.PS1 = true;
					Registers.OPTION_REG.PS2 = false;
					Registers.OPTION_REG.PSA = false;
					break;
				case 32:
					Registers.OPTION_REG.PS0 = false;
					Registers.OPTION_REG.PS1 = false;
					Registers.OPTION_REG.PS2 = true;
					Registers.OPTION_REG.PSA = false;
					break;
				case 64:
					Registers.OPTION_REG.PS0 = true;
					Registers.OPTION_REG.PS1 = false;
					Registers.OPTION_REG.PS2 = true;
					Registers.OPTION_REG.PSA = false;
					break;
				case 128:
					Registers.OPTION_REG.PS0 = false;
					Registers.OPTION_REG.PS1 = true;
					Registers.OPTION_REG.PS2 = true;
					Registers.OPTION_REG.PSA = false;
					break;
				case 256:
					Registers.OPTION_REG.PS0 = true;
					Registers.OPTION_REG.PS1 = true;
					Registers.OPTION_REG.PS2 = true;
					Registers.OPTION_REG.PSA = false;
					break;
				default:
					throw new Exception("Invalid prescaler rate: " + rate.ToString());
			}
		}

		/// <summary>
		/// Disables the interrupts thrown by Timer 0
		/// </summary>
		/// <remarks>
		/// TMR0.Overflowed will work even if the interrupts are disabled
		/// </remarks>
		public void DisableInterrupts() {
			Registers.INTCON.T0IE = false;
		}

		/// <summary>
		/// Restarts the Timer 0 counter
		/// </summary>
		public void Restart() {
			Registers.TMR0 = 0;
		}

		/// <summary>
		/// Indicates if Timer 0 overflowed. Remember to call ClearIF() after each Timer0 overflow
		/// </summary>
		public bool Overflowed {
			get {
				return Registers.INTCON.T0IF;
			}
		}

		/// <summary>
		/// Indicates whether interrupts are enabled or not
		/// </summary>
		public bool HasInterruptsEnabled {
			get {
				return (Registers.INTCON.GIE && Registers.INTCON.PEIE && Registers.INTCON.T0IE);
			}
		}

		/// <summary>
		/// Configures the Timer 0 (without interrupts and internal clock source)
		/// </summary>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqPrefix">Oscillator frequency value prefix</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured</param>
		/// <param name="Period">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		/// <param name="PerPrefix">Period prefix</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		public void Configure(float frequency, SIPrefixes FreqPrefix, FrequencyUnits FreqUnit, float Period, SIPrefixes PerPrefix, TimeUnits PeriodUnit) {
			Configure(false, Tmr0ClockSource.Internal, DigitalEdge.Rising, new Frequency(frequency, FreqPrefix, FreqUnit), new Period(Period, PerPrefix, PeriodUnit));
		}

		/// <summary>
		/// Configures the Timer 0 (internal clock source)
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqPrefix">Oscillator frequency value prefix</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured</param>
		/// <param name="Period">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		/// <param name="PerPrefix">Period prefix</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		public void Configure(bool enableInterrupts, float frequency, SIPrefixes FreqPrefix, FrequencyUnits FreqUnit, float Period, SIPrefixes PerPrefix, TimeUnits PeriodUnit) {
			Configure(enableInterrupts, Tmr0ClockSource.Internal, DigitalEdge.Rising, new Frequency(frequency, FreqPrefix, FreqUnit), new Period(Period, PerPrefix, PeriodUnit));
		}

		/// <summary>
		/// Configures the Timer 0 (internal clock source)
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured. International System of Units</param>
		/// <param name="period">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		public void Configure(bool enableInterrupts, float frequency, FrequencyUnitsSI FreqUnit, float period, TimeUnitsSI PeriodUnit) {
			Configure(enableInterrupts, Tmr0ClockSource.Internal, DigitalEdge.Rising, new Frequency(frequency, FreqUnit), new Period(period, PeriodUnit));
		}

		/// <summary>
		/// Configures the Timer 0
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="source">Source for incrementing the value of TMR0</param>
		/// <param name="edge">Which edge (rising or falling) will increment TMR0 value</param>
		/// <param name="frequency">Oscillator frequency value</param>
		/// <param name="FreqUnit">Units in which oscillator frequency is measured. International System of Units</param>
		/// <param name="period">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		/// <param name="PeriodUnit">Units in which the period is measured</param>
		public void Configure(bool enableInterrupts, Tmr0ClockSource source, DigitalEdge edge, float frequency, FrequencyUnitsSI FreqUnit, float period, TimeUnitsSI PeriodUnit) {
			Configure(enableInterrupts, source, edge, new Frequency(frequency, FreqUnit), new Period(period, PeriodUnit));
		}

		/// <summary>
		/// Configures the Timer 0
		/// </summary>
		/// <param name="enableInterrupts">Indicates if interrupts should be enabled</param>
		/// <param name="source">Source for incrementing the value of TMR0</param>
		/// <param name="IncrementEdgeT0CK">Which edge (rising or falling) will increment TMR0 value</param>
		/// <param name="Fosc">Oscillator frequency</param>
		/// <param name="Ttmr">Period of TMR0 overflows. Time elapsed between two consecutive TMR0 overflows</param>
		[PigmeoToDo("Not finished. We need to support interruptions and delegates first")]
		public void Configure(bool enableInterrupts, Tmr0ClockSource source, DigitalEdge IncrementEdgeT0CK, Frequency Fosc, Period Ttmr) {
			if(enableInterrupts) this.EnableInterrupts();

			if(source == Tmr0ClockSource.Internal) Registers.OPTION_REG.T0CS = false;
			else {
				Registers.OPTION_REG.T0CS = true;
				if(IncrementEdgeT0CK == DigitalEdge.Rising) Registers.OPTION_REG.T0SE = false;
				else Registers.OPTION_REG.T0SE = true;
			}

			Frequency Fcy = Fosc / 4; //instruction frequency
			Period Tcy = Fcy.ToPeriod(); //instruction period

			Console.WriteLine("oscillator frequency: {0}kHz", Fosc.GetValue(SIPrefixes.k, FrequencyUnits.Hz));
			Console.WriteLine("instruction frequency: {0}kHz", Fcy.GetValue(SIPrefixes.k, FrequencyUnits.Hz));
			Console.WriteLine("instruction period: {0}ns", Tcy.GetValue(SIPrefixes.n, TimeUnits.second));
			Console.WriteLine("Desired timer period: {0}ns", Ttmr.GetValue(SIPrefixes.n, TimeUnits.second));

			byte prescaler = 1;
			float RequiredCycles = Ttmr / Tcy;

			Console.WriteLine("Required cycles: {0}", RequiredCycles);

			if(RequiredCycles < 20) throw new Exception("Oscillator frequency too low or timer too fast. Only " + RequiredCycles.ToString() + " instructions between interruptions");
			while(RequiredCycles > 255) {
				prescaler *= 2;
				SetPrescaler(prescaler);
				RequiredCycles /= 2;
			}

			Console.WriteLine("Required cycles with prescaler: {0}", RequiredCycles);
			Console.WriteLine("Prescaler: {0}", prescaler);
			Console.WriteLine("PS<2:0> => {0}{1}{2}", Registers.OPTION_REG.PS2, Registers.OPTION_REG.PS1, Registers.OPTION_REG.PS0);

			//interruption time if timer 0 is not preloaded
			Period IntTimeWoPrel = Tcy * 256 * prescaler;
			if(IntTimeWoPrel < Ttmr) throw new Exception("Prescaler wrongly calculated. This is an internal bug");
			byte preload = (byte)((IntTimeWoPrel - Ttmr) / (Tcy * prescaler));

			Console.WriteLine("Preload: {0}", preload);

			UInt16 DesiredTime = (UInt16)Ttmr.GetValue(SIPrefixes.m, TimeUnits.second);
			UInt16 CalculatedTime = (UInt16)(Tcy * prescaler * (256 - preload)).GetValue(SIPrefixes.m, TimeUnits.second);
			Console.WriteLine("Desired time: {0}ms, calculated time: {1}ms", DesiredTime, CalculatedTime);
			if(DesiredTime == CalculatedTime) Console.WriteLine("Everything fine");
			else throw new Exception("Wrongly calculated");
		}

		/// <summary>
		/// Sets the source for the timer 0. This is how the timer 0 gets incremented
		/// </summary>
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
}