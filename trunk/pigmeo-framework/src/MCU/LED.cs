/*namespace Pigmeo.MCU {
	public enum LedStatus { OFF, ON }



	public class LED {
		private ReadPin_del ReadPinOfLed;
		public readonly LogicType logic;

		public LED(ReadPin_del del, LogicType logic) {
			ReadPinOfLed = del;
			this.logic = logic;
		}

		public LedStatus Status {
			get {
				LedStatus ret = LedStatus.OFF;
				if(ReadPinOfLed.Invoke()) ret = LedStatus.ON;
				return ret;
			}
			set {

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
}*/
