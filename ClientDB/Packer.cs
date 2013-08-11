using System;
using System.IO;
using System.IO.Compression;

namespace GAssistant
{
	class Packer
	{
		public static void Compress(FileInfo fileToCompress, String szOutFile)
		{
			using (FileStream originalFileStream = fileToCompress.OpenRead())
			{
				using (FileStream archFileStream = File.Create(szOutFile))
				{
					using (GZipStream archStream = new GZipStream(archFileStream, CompressionMode.Compress))
					{
						byte[] buffer = new byte[1024];
						int nRead;
						while ((nRead = originalFileStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							archStream.Write(buffer, 0, nRead);
						}
						Logger.Info(string.Format("Compressed {0} from {1} to {2} bytes.",
							  fileToCompress.Name
							, fileToCompress.Length.ToString()
							, archFileStream.Length.ToString()
						));
					}
				}
			}
		}

		public static void Decompress(FileInfo archFile, out String szOutFile)
		{
			using (FileStream archFileStream = archFile.OpenRead())
			{
				String currentFileName = archFile.FullName;
				String newFileName = currentFileName.Remove(
					currentFileName.Length - archFile.Extension.Length);

				using (FileStream normalFileStream = File.Create(newFileName))
				{
					using (GZipStream decompressionStream = new GZipStream(archFileStream, CompressionMode.Decompress))
					{
						byte[] buffer = new byte[1024];
						int nRead;
						while ((nRead = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
						{
							normalFileStream.Write(buffer, 0, nRead);
						}

						szOutFile = newFileName;
						Console.WriteLine("Decompressed: {0}", archFile.Name);
					}
				}
			}
		}
	}
}
