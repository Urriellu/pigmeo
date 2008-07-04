namespace Pigmeo.Displays.LEDs {
	/// <summary>
	/// Light-Emitting Diode (write-only). Positive logic (it lights when the pin is set to High)
	/// </summary>
	public class LEDPositive {
		private Delegates.SetBool WriteLed;

		/// <summary>
		/// Instantiates a new LED object which works with positive logic
		/// </summary>
		/// <param name="LedWriter">Delegate that writes the LED status</param>
		public LEDPositive(Delegates.SetBool LedWriter) {
			WriteLed = LedWriter;
		}

		/// <summary>
		/// Sets the LED status
		/// </summary>
		public OnOffStatus Status {
			set {
				if(value == OnOffStatus.ON) WriteLed.Invoke(true);
				else WriteLed.Invoke(false);
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
