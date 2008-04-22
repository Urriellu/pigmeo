namespace Pigmeo.CommonDevices {
	/// <summary>
	/// Light-Emitting Diode
	/// </summary>
	public class LED {
		private Delegates.ReadBool ReadLed;
		private Delegates.SetBool WriteLed;

		/// <summary>
		/// Digital logic in which the LED works
		/// </summary>
		public readonly LogicType logic;

		/// <summary>
		/// Instantiates a new LED object
		/// </summary>
		/// <param name="LedReader">Delegate that reads the LED status</param>
		/// <param name="LedWriter">Delegate that writes the LED status</param>
		/// <param name="logic">Digital logic in which the LED works</param>
		public LED(Delegates.ReadBool LedReader, Delegates.SetBool LedWriter, LogicType logic) {
			ReadLed = LedReader;
			WriteLed = LedWriter;
			this.logic = logic;
		}

		/// <summary>
		/// Gets or sets the LED status
		/// </summary>
		public OnOffStatus Status {
			get {
				bool BitValue = ReadLed.Invoke();
				if((BitValue && logic == LogicType.Positive) || (!BitValue && logic == LogicType.Negative)) return OnOffStatus.ON;
				else return OnOffStatus.OFF;
			}
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

		/// <summary>
		/// Indicates if the LED is lighting
		/// </summary>
		public bool IsON {
			get {
				if(this.Status == OnOffStatus.ON) return true;
				else return false;
			}
		}

		/// <summary>
		/// Indicates if the LED is OFF (not lighting)
		/// </summary>
		public bool IsOFF {
			get {
				return !IsON;
			}
		}
	}
}
