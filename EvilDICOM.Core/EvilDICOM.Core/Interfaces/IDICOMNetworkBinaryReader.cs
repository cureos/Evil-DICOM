namespace EvilDICOM.Core.Interfaces
{
	public interface IDICOMNetworkBinaryReader
	{
		/// <summary>
		/// Reads the specified number of bytes. Will block until bytes are completely read (waiting on the network).
		/// </summary>
		/// <param name="count">the number of bytes to be read</param>
		/// <returns>the read bytes</returns>
		byte[] ReadBytesAsync(int count);

		byte[] ReadAllAvailable();

		bool AwaitingData { get; }

		bool DataAvailable { get; }
	}
}