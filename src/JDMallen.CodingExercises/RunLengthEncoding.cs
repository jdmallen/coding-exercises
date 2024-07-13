using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace JDMallen.CodingExercises;

public class RunLengthEncoding
{
	public static async Task Encode()
	{
		byte[] input = await File.ReadAllBytesAsync(@"D:\Temp\floccus-4.1.0-2020-04-16.log");
		await using var output = File.OpenWrite(@"D:\Temp\floccus-4.1.0-2020-04-16.log.rle");

		byte lastByte = input[0];
		var lastHex = lastByte.ToString("X");
		byte lastByteCount = 1;
		for (var i = 1; i < input.LongLength; i++)
		{
			if (i == 705624)
			{
				Debugger.Break();
			}

			byte b = input[i];
			var hex = b.ToString("X");
			var chr = (char)b;
			if (b == lastByte)
			{
				lastByteCount++;

				continue;
			}

			if (lastByteCount == 1)
			{
				output.WriteByte(lastByte);
				lastByte = b;

				continue;
			}

			output.WriteByte(lastByte);
			output.WriteByte(lastByte);
			output.WriteByte(lastByteCount);
			lastByte = b;
			lastByteCount = 1;
		}

		output.WriteByte(lastByte);
		output.Flush(true);
		output.Close();
	}

	public static async Task Decode()
	{
		byte[] input =
			await File.ReadAllBytesAsync(@"D:\Temp\floccus-4.1.0-2020-04-16.log.rle");
		await using var output =
			File.OpenWrite(@"D:\Temp\floccus-4.1.0-2020-04-16-restored.log");

		for (var i = 0; i < input.LongLength;)
		{
			byte b1 = input[i];
			byte b2 = input[i + 1];
			if (b1 != b2)
			{
				output.WriteByte(b1);
				i++;

				continue;
			}

			byte count = input[i + 3];

			for (var j = 0; j < count; j++)
			{
				output.WriteByte(b1);
			}

			i += 3;
		}
	}
}
