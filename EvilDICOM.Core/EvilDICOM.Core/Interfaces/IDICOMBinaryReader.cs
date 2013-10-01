using System;
using EvilDICOM.Core.IO.Reading;

namespace EvilDICOM.Core.Interfaces
{
	public interface IDICOMBinaryReader : IDisposable
	{
		/// <summary>
		/// Reads the specified number of bytes
		/// </summary>
		/// <param name="count">the number of bytes to be read</param>
		/// <returns>the read bytes</returns>
		byte[] ReadBytes(int count);

		/// <summary>
		/// Reads the specified number of bytes (shorthand for ReadBytes method).
		/// </summary>
		/// <param name="count">the number of bytes to be read</param>
		/// <returns>the read bytes</returns>
		byte[] Take(int count);

		byte[] Peek(int count);

		/// <summary>
		/// Creates a new stream that is trimmed to the specification length.
		/// </summary>
		/// <param name="substreamLength">the number of bytes to include in the new stream (starting from the current position)</param>
		IDICOMBinaryReader GetSubStream(int substreamLength);

		/// <summary>
		/// Reads the specified number of chars
		/// </summary>
		/// <param name="count">the number of chars to be read</param>
		/// <returns>the read chars</returns>
		char[] ReadChars(int count);

		/// <summary>
		/// Reads the specified number of chars and converts to a string
		/// </summary>
		/// <param name="count">the number of chars to be read</param>
		/// <returns>the read chars</returns>
		string ReadString(int length);

		void ReadBytes(byte[] buffer, int index, int count);

		/// <summary>
		/// Will return the index of a given byte pattern in the byte stream
		/// </summary>
		/// <param name="bytePattern">the pattern to be found</param>
		/// <returns>the index of the pattern</returns>
		long IndexOf(byte[] bytePattern);

		/// <summary>
		/// Returns the current position of the byte stream
		/// </summary>
		long StreamPosition { get; set; }

		/// <summary>
		/// Returnts the length of the byte stream
		/// </summary>
		long StreamLength { get; }

		void Reset();
	}
}