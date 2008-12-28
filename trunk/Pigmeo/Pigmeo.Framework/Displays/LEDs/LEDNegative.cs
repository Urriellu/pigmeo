namespace Pigmeo.Displays.LEDs {
	/// <summary>
	/// Light-Emitting Diode (write-only). Negative logic (it lights when the pin is set to Low)
	/// </summary>
	public class LEDNegative {
		private Delegates.SetBool WriteLed;

		/// <summary>
		/// Digital logic in which the LED works
		/// </summary>
		public readonly LogicType logic;

		/// <summary>
		/// Instantiates a new LED object which works with negative logic
		/// </summary>
		/// <param name="LedWriter">Delegate that writes the LED status</param>
		public LEDNegative(Delegates.SetBool LedWriter) {
			WriteLed = LedWriter;
		}

		/// <summary>
		/// Sets the LED status
		/// </summary>
		public OnOffStatus Status {
			set {
				if(value == OnOffStatus.ON) WriteLed.Invoke(false);
				else WriteLed.Invoke(true);
			}
		}

		/// <summary>
		/// Turns ON the LED
		/// </summary>
		public void TurnON() {
			this.Status = OnOffStatus.ON;
		}

		/// <summary>
		/// Turns OFF the LED
		/// </summary>
		public void TurnOFF() {
			this.Status = OnOffStatus.OFF;
		}
	}
}
