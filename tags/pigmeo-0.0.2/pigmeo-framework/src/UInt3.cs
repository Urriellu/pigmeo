namespace Pigmeo {
	public struct UInt3 {
		public bool Bit0;
		public bool Bit1;
		public bool Bit2;

		public UInt3(bool Bit2, bool Bit1, bool Bit0) {
			this.Bit0 = Bit0;
			this.Bit1 = Bit1;
			this.Bit2 = Bit2;
		}

		public string ToBinaryString() {
			return string.Format("{0}:X", Bit2) + string.Format("{0}:X", Bit1) + string.Format("{0}:X", Bit0);
		}

		#region operators
		public static implicit operator byte(UInt3 n) {
			byte v = 0;
			if(n.Bit0) v+=1;
			if(n.Bit1) v += 2;
			if(n.Bit2) v += 4;
			return v;
		}
		#endregion
	}
}
