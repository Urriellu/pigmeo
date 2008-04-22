namespace Pigmeo.CommonDevices {
	public enum LedStatus { OFF, ON }

	public class LED {
		private Delegates.ReadBool ReadLed;
		private Delegates.SetBool WriteLed;
		public readonly LogicType logic;

		public LED(Delegates.ReadBool LedReader, Delegates.SetBool LedWriter, LogicType logic) {
			ReadLed = LedReader;
			WriteLed = LedWriter;
			this.logic = logic;
		}

		/// <summary>
		/// Gets or sets the LED status
		/// </summary>
		public LedStatus Status {
			get {
				if(ReadLed.Invoke()) return LedStatus.ON;
				else return LedStatus.OFF;
			}
			set {
				if((logic == LogicType.Positive && value == LedStatus.ON) || logic == LogicType.Negative && value == LedStatus.OFF) WriteLed.Invoke(true);
				else WriteLed.Invoke(false);
			}
		}

		public void TurnON() {
			this.Status = LedStatus.ON;
		}

		public void TurnOFF() {
			this.Status = LedStatus.OFF;
		}

		public bool IsON {
			get {
				if(this.Status == LedStatus.ON) return true;
				return false;
			}
		}

		public bool IsOFF {
			get {
				return !IsON;
			}
		}
	}
}
