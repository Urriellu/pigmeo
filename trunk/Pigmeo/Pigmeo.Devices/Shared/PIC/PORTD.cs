using Pigmeo.MCU;
using Pigmeo.Extensions;
using Pigmeo.Internal.PIC;

namespace Pigmeo.MCU {
	public static partial class Registers {
		[AsmName("PORTD"), Location(true)]
		public volatile static byte PORTD = 0;

		/// <summary>
		/// PORTD data direction register. true = Input. false = Output
		/// </summary>
		[AsmName("TRISD"), Location(true)]
		public volatile static byte TRISD = 0;
	}

	public class PORTD {
		/// <summary>
		/// Configures all the bits as digital inputs or outputs
		/// </summary>
		/// <param name="value">Set them as Inputs or Outputs</param>
		public void ConfigAll(DigitalIOConfig value) {
			switch(value) {
				case DigitalIOConfig.Input:
					Registers.TRISD = 0xFF;
					break;
				case DigitalIOConfig.Output:
					Registers.TRISD = 0;
					break;
			}
		}

		/// <summary>
		/// Configures a single pin as digital input or output
		/// </summary>
		/// <param name="pin">Pin being configured</param>
		/// <param name="value">Set it as Input or Output</param>
		public void ConfigPin(byte pin, DigitalIOConfig value) {
			switch(value) {
				case DigitalIOConfig.Input:
					Registers.TRISD.SetBit(pin, true);
					break;
				case DigitalIOConfig.Output:
					Registers.TRISD.SetBit(pin, false);
					break;
			}
		}

		/// <summary>
		/// Gets or set the digital value of a single pin/bit
		/// </summary>
		public bool this[byte bit] {
			get {
				return Registers.PORTD.GetBit(bit);
			}
			set {
				Registers.PORTD.SetBit(bit, value);
			}
		}

		#region delegates
		/// <summary>
		/// Delegate that reads the value of Pin 0
		/// </summary>
		public Delegates.ReadBool ReadPin0 = delegate() { return Registers.PORTD.GetBit(0); };

		/// <summary>
		/// Delegate that writes a given value to pin 0
		/// </summary>
		public Delegates.SetBool WritePin0 = delegate(bool value) { Registers.PORTD.SetBit(0, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 1
		/// </summary>
		public Delegates.ReadBool ReadPin1 = delegate() { return Registers.PORTD.GetBit(1); };

		/// <summary>
		/// Delegate that writes a given value to pin 1
		/// </summary>
		public Delegates.SetBool WritePin1 = delegate(bool value) { Registers.PORTD.SetBit(1, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 2
		/// </summary>
		public Delegates.ReadBool ReadPin2 = delegate() { return Registers.PORTD.GetBit(2); };

		/// <summary>
		/// Delegate that writes a given value to pin 2
		/// </summary>
		public Delegates.SetBool WritePin2 = delegate(bool value) { Registers.PORTD.SetBit(2, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 3
		/// </summary>
		public Delegates.ReadBool ReadPin3 = delegate() { return Registers.PORTD.GetBit(3); };

		/// <summary>
		/// Delegate that writes a given value to pin 3
		/// </summary>
		public Delegates.SetBool WritePin3 = delegate(bool value) { Registers.PORTD.SetBit(3, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 4
		/// </summary>
		public Delegates.ReadBool ReadPin4 = delegate() { return Registers.PORTD.GetBit(4); };

		/// <summary>
		/// Delegate that writes a given value to pin 4
		/// </summary>
		public Delegates.SetBool WritePin4 = delegate(bool value) { Registers.PORTD.SetBit(4, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 5
		/// </summary>
		public Delegates.ReadBool ReadPin5 = delegate() { return Registers.PORTD.GetBit(5); };

		/// <summary>
		/// Delegate that writes a given value to pin 5
		/// </summary>
		public Delegates.SetBool WritePin5 = delegate(bool value) { Registers.PORTD.SetBit(5, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 6
		/// </summary>
		public Delegates.ReadBool ReadPin6 = delegate() { return Registers.PORTD.GetBit(6); };

		/// <summary>
		/// Delegate that writes a given value to pin 6
		/// </summary>
		public Delegates.SetBool WritePin6 = delegate(bool value) { Registers.PORTD.SetBit(6, value); };

		/// <summary>
		/// Delegate that reads the value of Pin 7
		/// </summary>
		public Delegates.ReadBool ReadPin7 = delegate() { return Registers.PORTD.GetBit(7); };

		/// <summary>
		/// Delegate that writes a given value to pin 7
		/// </summary>
		public Delegates.SetBool WritePin7 = delegate(bool value) { Registers.PORTD.SetBit(7, value); };
		#endregion
	}
}