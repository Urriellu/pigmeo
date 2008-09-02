using System;
using System.Threading;
using Pigmeo.Physics;

namespace Pigmeo.MCU {
	public static class Processor {
		/// <summary>
		/// Oscillator frequency
		/// </summary>
		public static Frequency Fosc;

		/// <summary>
		/// No meaningful operation is performed although a processing cycle will be consumed
		/// </summary>
		public static void Nop() {
		}

		/// <summary>
		/// Keeps the CPU doing nothing useful for a given amount of time (in milliseconds)
		/// </summary>
		public static void Delay(int milliseconds) {
			Thread.Sleep(milliseconds);
		}

		/// <summary>
		/// Keeps the CPU doing nothing useful for a given amount of time
		/// </summary>
		public static void Delay(float Time, TimeUnitsSI Unit) {
			Thread.Sleep(((int)(new Period(Time, Unit)).GetValue(SIPrefixes.m, TimeUnits.second)));
		}

		/// <summary>
		/// Keeps the CPU doing nothing useful for a given amount of time
		/// </summary>
		public static void Delay(TimeSpan Time) {
			Thread.Sleep(Time);
		}

		/// <summary>
		/// Keeps the CPU doing nothing useful for a given amount of time
		/// </summary>
		public static void Delay(Period T) {
			Thread.Sleep(((int)T.GetValue(SIPrefixes.m, TimeUnits.second)));
		}
	}
}
