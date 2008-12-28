namespace Pigmeo.CommonDevices {
	/// <summary>
	/// Light-Emitting Diode (write-only)
	/// </summary>
	public class LED {
		private Delegates.SetBool WriteLed;

		/// <summary>
		/// Digital logic in which the LED works
		/// </summary>
		public readonly LogicType logic;

		/// <summary>
		/// Instantiates a new LED object
		/// </summary>
		/// <param name="LedWriter">Delegate that writes the LED status</param>
		/// <param name="logic">Digital logic in which the LED works</param>
		public LED(Delegates.SetBool LedWriter, LogicType logic) {
			WriteLed = LedWriter;
			this.logic = logic;
		}

		/// <summary>
		/// Sets the LED status
		/// </summary>
		public OnOffStatus Status {
			set {
				if((logic == LogicType.Positive && value == OnOffStatus.ON) || logic == LogicType.Negative && value == OnOffStatus.OFF) WriteLed.Invoke(true);
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
