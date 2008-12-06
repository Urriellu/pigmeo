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
			Nop(1);
		}

		/// <summary>
		/// No meaningful operation is performed although the given amount of cycles will be wasted
		/// </summary>
		public static void Nop(int Instructions) {
			throw new NotImplementedException();
		}

		/// <summary>
		/// Keeps the CPU doing nothing useful for a given amount of time (in milliseconds)
		/// </summary>
		/// <remarks>
		/// Note: in most microcontroller architectures, this is done by keeping the CPU on an infinite loop, wasting power. Avoid it on battery-powered devices
		/// </remarks>
		public static void Delay(int milliseconds) {
			Thread.Sleep(milliseconds);
		}

		/// <summary>
		/// Keeps the CPU doing nothing useful for a given amount of time
		/// </summary>
		public static void Delay(float Time, TimeUnitsSI Unit) {
			Thread.Sleep(((int)(new Period(Time, Unit)).GetValue(SIPrefixes.m, TimeUnits.second)));
		}
	}
}
