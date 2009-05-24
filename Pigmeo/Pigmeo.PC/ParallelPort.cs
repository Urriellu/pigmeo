using System;
using System.Runtime.InteropServices;
using Pigmeo.Extensions;

namespace Pigmeo.PC {
	public class ParallelPort:IDisposable {
		static int FileDescriptor;

		const int O_RDWR = 2;
		const UInt32 PPCLAIM = 28811;
		const UInt32 PPSETMODE = 1074032768;
		const UInt32 PPRELEASE = 28812;
		const UInt32 PPWDATA = 1073836166;
		const UInt32 PPRDATA = 2147577989;
		const UInt32 PPWCONTROL = 1073836164;
		const UInt32 PPRSTATUS = 2147577985;
		const UInt32 PPDATADIR = 1074032784;
		static int IEEE1284_MODE_BYTE = 1;

		byte ControlValue = 0;

		#region p/invokes
		[DllImport("libc", SetLastError = true)]
		private static extern int open([MarshalAs(UnmanagedType.LPStr)]string Path, int Flags);

		[DllImport("libc", SetLastError = true)]
		private static extern int close(int fd);

		[DllImport("libc", SetLastError = true)]
		private static extern int ioctl(int fd, UInt32 request);

		[DllImport("libc", SetLastError = true)]
		private static extern byte Ioctl(int fd, UInt32 request);

		[DllImport("libc", SetLastError = true)]
		private static extern int ioctl(int fd, UInt32 request, int d1);

		[DllImport("libc", SetLastError = true)]
		private static extern int ioctl(int fd, UInt32 request, ref int d1);

		[DllImport("libc", SetLastError = true)]
		private static extern int ioctl(int fd, UInt32 request, ref byte d1);
		#endregion

		/// <summary>
		/// Initializes the parallel port. This must be called before using anything else.
		/// </summary>
		public void Initialize() {
			FileDescriptor = open("/dev/parport0", O_RDWR);
			if(FileDescriptor == -1) throw new Exception("Device not found");
			if(ioctl(FileDescriptor, PPCLAIM, 0) == -1) throw new Exception("Failed to claim the parallel port. It's already being used or you haven't got enough privileges");
			if(ioctl(FileDescriptor, PPSETMODE, ref IEEE1284_MODE_BYTE) == -1) {
				Close();
				throw new Exception("Unable to set byte mode");
			}
			SetDataOutput();
		}

		/// <summary>
		/// Release the Parallel Port, so other programs can use it
		/// </summary>
		public void Close() {
			ioctl(FileDescriptor, 28812);
			close(FileDescriptor);
		}

		/// <summary>
		/// Sets Data bits (2-9) as outputs
		/// </summary>
		public void SetDataOutput() {
			int dir = 0;
			if(ioctl(FileDescriptor, PPDATADIR, ref dir) == -1) {
				Close();
				throw new Exception("Unable to set the data port as output");
			}
		}

		/// <summary>
		/// Sets Data bits (2-9) as inputs
		/// </summary>
		public void SetDataInput() {
			int dir = 1;
			if(ioctl(FileDescriptor, PPDATADIR, ref dir) == -1) {
				Close();
				throw new Exception("Unable to set the data port as input");
			}
		}

		/// <summary>
		/// Writes to the Control bits
		/// </summary>
		protected int WriteControl(byte value) {
			ControlValue = value;
			return ioctl(FileDescriptor, PPWCONTROL, ref value);
		}

		/// <summary>
		/// Writes to the Data bits
		/// </summary>
		protected int WriteData(byte value) {
			return ioctl(FileDescriptor, PPWDATA, ref value);
		}

		/// <summary>
		/// Reads the Data bits
		/// </summary>
		protected byte ReadData() {
			return Ioctl(FileDescriptor, PPRDATA);
		}

		/// <summary>
		/// Reads the Status bits
		/// </summary>
		protected byte ReadStatus() {
			return Ioctl(FileDescriptor, PPRSTATUS);
		}

		public void Dispose() {
			Close();
		}

		/// <summary>
		/// Parallel Port Data pins
		/// </summary>
		/// <remarks>
		/// Control bit 0. "Strobe". Hardware inverted. Automatically inverted by software
		/// </remarks>
		public byte Data {
			get {
				return ReadData();
			}
			set {
				WriteData(value);
			}
		}

		#region Control bits
		/// <summary>
		/// Parallel Port pin 1
		/// </summary>
		/// <remarks>
		/// Control bit 0. "Strobe". Hardware inverted. Automatically inverted by software
		/// </remarks>
		public bool Pin1 {
			set {
				WriteControl(ControlValue.SetBit(0, !value));
			}
		}

		/// <summary>
		/// Parallel Port pin 14
		/// </summary>
		/// <remarks>
		/// Control bit 1. "Autofeed". Hardware inverted. Automatically inverted by software
		/// </remarks>
		public bool Pin14 {
			set {
				WriteControl(ControlValue.SetBit(1, !value));
			}
		}

		/// <summary>
		/// Parallel Port pin 16
		/// </summary>
		/// <remarks>
		/// Control bit 2. "Init". Hardware inverted. Automatically inverted by software
		/// </remarks>
		public bool Pin16 {
			set {
				WriteControl(ControlValue.SetBit(2, !value));
			}
		}

		/// <summary>
		/// Parallel Port pin 17
		/// </summary>
		/// <remarks>
		/// Control bit 3. "Select In". Hardware inverted. Automatically inverted by software
		/// </remarks>
		public bool Pin17 {
			set {
				WriteControl(ControlValue.SetBit(3, !value));
			}
		}
		#endregion

		#region Status bits
		/// <summary>
		/// Parallel port pin 10
		/// </summary>
		/// <remarks>
		/// Status bit 6. "Acknowledge". Hardware inverted. Automatically inverted by software
		/// </remarks>
		public bool Pin10 {
			get {
				return ReadStatus().GetBit(6);
			}
		}
		#endregion
	}
}
