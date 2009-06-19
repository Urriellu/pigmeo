using System;
using System.IO.Ports;
using BclSP = System.IO.Ports.SerialPort;
using Pigmeo.Extensions;

namespace Pigmeo.PC {
	/// <summary>
	/// Represents a Serial Port
	/// </summary>
	public class SerialPort : BclSP {
		/// <summary>
		/// Initializes a new SerialPort using the specified port name, baud rate, parity bit, data bits, and stop bit.
		/// </summary>
		public SerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
			: base(portName, baudRate, parity, dataBits, stopBits) {
		}

		/// <summary>
		/// Synchronously reads one byte from the SerialPort input buffer.
		/// </summary>
		public new byte ReadByte() {
			return (byte)base.ReadByte();
		}

		/// <summary>
		/// Synchronously reads two bytes as UInt16 from the SerialPort input buffer.
		/// </summary>
		/// <remarks>
		/// The first received byte is taken as the 8 most significant bits. The second byte is taken as the 8 least significant bits. 
		/// </remarks>
		public UInt16 ReadUInt16() {
			byte Byte1, Byte0;
			Byte1 = (byte)ReadByte();
			Byte0 = (byte)ReadByte();
			return (UInt16)((Byte1 << 8) + Byte0);
		}

		/// <summary>
		/// Synchronously reads four bytes as UInt32 from the SerialPort input buffer.
		/// </summary>
		/// <remarks>
		/// The first received byte is taken as the 8 most significant bits. The fourth (last) byte is taken as the 8 least significant bits. 
		/// </remarks>
		public UInt32 ReadUInt32() {
			byte Byte3, Byte2, Byte1, Byte0;
			Byte3 = (byte)ReadByte();
			Byte2 = (byte)ReadByte();
			Byte1 = (byte)ReadByte();
			Byte0 = (byte)ReadByte();
			return (UInt32)(((UInt32)Byte3 << 24) + ((UInt32)Byte2 << 16) + ((UInt32)Byte1 << 8) + (UInt32)Byte0);
		}

		/// <summary>
		/// Writes a byte to the serial port
		/// </summary>
		public void WriteByte(byte Byte) {
			Write(new byte[] { Byte }, 0, 1);
		}

		/// <summary>
		/// Writes the two bytes of an UInt16 to the serial port
		/// </summary>
		public void WriteUInt16(UInt16 Value) {
			Write(Value.GetBytes(), 0, 2);
		}

		/// <summary>
		/// Writes the four bytes of an UInt32 to the serial port
		/// </summary>
		public void WriteUInt32(UInt32 Value) {
			Write(Value.GetBytes(), 0, 4);
		}
	}
}