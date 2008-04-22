namespace Pigmeo.CommonDevices {
	/// <summary>
	/// Push-button
	/// </summary>
	public class PushButton {
		private Delegates.ReadBool ReadButton;

		/// <summary>
		/// Value of the button when it's released (not pressed)
		/// </summary>
		public readonly DigitalValue ReleaseValue;

		/// <summary>
		/// Instantiates a new PushButton object
		/// </summary>
		/// <param name="ButtonReader">Delegate that reads the button status</param>
		/// <param name="ReleaseValue">Value of the button when it's released (not pressed)</param>
		public PushButton(Delegates.ReadBool ButtonReader, DigitalValue ReleaseValue) {
			ReadButton = ButtonReader;
			this.ReleaseValue = ReleaseValue;
		}

		/// <summary>
		/// Indicates if the button is pressed
		/// </summary>
		public bool IsPressed {
			get {
				bool BitStatus = ReadButton.Invoke();
				if((BitStatus && ReleaseValue == DigitalValue.Low) || (!BitStatus && ReleaseValue == DigitalValue.High)) return true;
				else return false;
			}
		}

		/// <summary>
		/// Indicates if the button is released (not pressed)
		/// </summary>
		public bool IsReleased {
			get {
				return !IsPressed;
			}
		}
	}
}
