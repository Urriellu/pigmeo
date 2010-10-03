using System;
using System.Threading;
using Pigmeo;
using Pigmeo.Internal;
using Pigmeo.Physics;

namespace Pigmeo.MCU {
	/// <summary>
	/// Generic options available for the microcontroller
	/// </summary>
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
		/// <remarks>
		/// On managed environments and architectures that don't implement this in assembly language, this will be processed as an approximate delay.
		/// </remarks>
		[InternalImplementation, InLine]
		public static void Nop(int Instructions) {
			float time = 0.0000002f * Instructions;
			int DelayMs = (int)Math.Ceiling(time * 1000);
			Thread.Sleep(DelayMs);
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
