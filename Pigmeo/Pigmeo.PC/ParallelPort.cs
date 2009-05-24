using System;
using System.Runtime.InteropServices;
using Pigmeo.Extensions;
using Pigmeo.Internal;

namespace Pigmeo.PC {
	public class ParallelPort:IDisposable {
		int FileDescriptor;

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

		public DigitalIOConfig DataIoStatus;


		#region p/invokes
		[DllImport("libc", SetLastError = true)]
		private static extern int open([MarshalAs(UnmanagedType.LPStr)]string Path, int Flags);

		[DllImport("libc", SetLastError = true)]
		private static extern int close(int fd);

		/*[DllImport("libc", SetLastError = true)]
		private static extern int ioctl(int fd, UInt32 request);*/

		[DllImport("libc", SetLastError = true)]
		private static extern byte ioctl(int fd, UInt32 request);

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
			DataIoStatus = DigitalIOConfig.Output;
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
			DataIoStatus = DigitalIOConfig.Input;
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
		[PigmeoToDo("Not tested")]
		protected byte ReadData() {
			return ioctl(FileDescriptor, PPRDATA);
		}

		/// <summary>
		/// Reads the Status bits
		/// </summary>
		[PigmeoToDo("Doesn't work")]
		protected byte ReadStatus() {
			int a=230;
			Console.WriteLine("STATUS ref: " + ioctl(FileDescriptor, PPRSTATUS, ref a));
			Console.WriteLine("DATA ref: " + ioctl(FileDescriptor, PPRDATA, ref a));
			Console.WriteLine("STATUS: " + ioctl(FileDescriptor, PPRSTATUS));
			Console.WriteLine("DATA: " + ioctl(FileDescriptor, PPRDATA));
			return ioctl(FileDescriptor, PPRSTATUS);
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

		#region Control bits (outputs)
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
		/// Control bit 2. "Init".
		/// </remarks>
		public bool Pin16 {
			set {
				WriteControl(ControlValue.SetBit(2, value));
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

		#region Status bits (inputs)
		/// <summary>
		/// Parallel port pin 10
		/// </summary>
		/// <remarks>
		/// Status bit 6. "Acknowledge"
		/// </remarks>
		public bool Pin10 {
			get {
				return ReadStatus().GetBit(6);
			}
		}

		/// <summary>
		/// Parallel port pin 11
		/// </summary>
		/// <remarks>
		/// Status bit 7. "Busy"
		/// </remarks>
		public bool Pin11 {
			get {
				return ReadStatus().GetBit(7);
			}
		}

		/// <summary>
		/// Parallel port pin 12
		/// </summary>
		/// <remarks>
		/// Status bit 5. "Paper End"
		/// </remarks>
		public bool Pin12 {
			get {
				return ReadStatus().GetBit(5);
			}
		}

		/// <summary>
		/// Parallel port pin 13
		/// </summary>
		/// <remarks>
		/// Status bit 4. "Select"
		/// </remarks>
		public bool Pin13 {
			get {
				return ReadStatus().GetBit(4);
			}
		}

		/// <summary>
		/// Parallel port pin 15
		/// </summary>
		/// <remarks>
		/// Status bit 3. "Error"
		/// </remarks>
		public bool Pin15 {
			get {
				return ReadStatus().GetBit(3);
			}
		}
		#endregion
	}
}
