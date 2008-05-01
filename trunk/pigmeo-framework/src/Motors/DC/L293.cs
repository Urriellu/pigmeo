namespace Pigmeo.Motors.DC {
	public class L293 {
		private Delegates.SetBool IN1;
		private Delegates.SetBool IN2;
		private Delegates.SetBool IN3;
		private Delegates.SetBool IN4;
		private Delegates.SetBool EN1;
		private Delegates.SetBool EN2;

		public L293(Delegates.SetBool IN1, Delegates.SetBool IN2, Delegates.SetBool IN3, Delegates.SetBool IN4, Delegates.SetBool EN1, Delegates.SetBool EN2) {
			this.IN1 = IN1;
			this.IN2 = IN2;
			this.IN3 = IN3;
			this.IN4 = IN4;
			this.EN1 = EN1;
			this.EN2 = EN2;
		}

		#region Motor 1
		public void Motor1_MoveForward() {
			EN1.Invoke(true);
			IN1.Invoke(true);
			IN2.Invoke(false);
		}

		public void Motor1_MoveBackward() {
			EN1.Invoke(true);
			IN1.Invoke(false);
			IN2.Invoke(true);
		}

		public void Motor1_FastStop() {
			EN1.Invoke(true);
			IN1.Invoke(true);
			IN2.Invoke(true);
		}

		public void Motor1_FreeRun() {
			EN1.Invoke(false);
		}
		#endregion

		#region Motor 2
		public void Motor2_MoveForward() {
			EN2.Invoke(true);
			IN3.Invoke(true);
			IN4.Invoke(false);
		}

		public void Motor2_MoveBackward() {
			EN2.Invoke(true);
			IN3.Invoke(false);
			IN4.Invoke(true);
		}

		public void Motor2_FastStop() {
			EN2.Invoke(true);
			IN3.Invoke(true);
			IN4.Invoke(true);
		}

		public void Motor2_FreeRun() {
			EN2.Invoke(false);
		}
		#endregion
	}
}
