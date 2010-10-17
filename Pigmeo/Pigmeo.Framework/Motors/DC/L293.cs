namespace Pigmeo.Motors.DC {
	/// <summary>
	/// Push-Pull 4 channel driver integrated circuit. Can be used for controlling DC motors, converting square waves to sine waves...
	/// </summary>
	public class L293 {
		private Delegates.SetBool IN1;
		private Delegates.SetBool IN2;
		private Delegates.SetBool IN3;
		private Delegates.SetBool IN4;
		private Delegates.SetBool EN1;
		private Delegates.SetBool EN2;

		/// <summary>
		/// Push-Pull 4 channel driver integrated circuit. Can be used for controlling DC motors, converting square waves to sine waves...
		/// </summary>
		/// <param name="IN1">Microcontroller's digital pin at which L293's IN1 is connected to</param>
		/// <param name="IN2">Microcontroller's digital pin at which L293's IN2 is connected to</param>
		/// <param name="IN3">Microcontroller's digital pin at which L293's IN3 is connected to</param>
		/// <param name="IN4">Microcontroller's digital pin at which L293's IN4 is connected to</param>
		/// <param name="EN1">Microcontroller's digital pin at which L293's EN1 is connected to</param>
		/// <param name="EN2">Microcontroller's digital pin at which L293's EN2 is connected to</param>
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
