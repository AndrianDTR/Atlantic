using System;
using System.IO;
using System.IO.Compression;
using AY.Log;

namespace AY
{
	namespace Packer
	{
		public class Archive
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
								Logger.Info("Write: "+ nRead.ToString());
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
				Logger.Enter();
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
				Logger.Leave();
			}

			public static Byte[] CompressArray(Byte[] inBuf)
			{
				Logger.Enter();

				MemoryStream memory = new MemoryStream();

				using (GZipStream gzip = new GZipStream(memory, CompressionMode.Compress))
				{
					gzip.Write(inBuf, 0, inBuf.Length);
				}

				Logger.Leave();
				return memory.ToArray();
			}

			public static Byte[] DecompressArray(Byte[] inBuf)
			{
				Logger.Enter();
				MemoryStream memory = new MemoryStream();
				
				using (GZipStream stream = new GZipStream(new MemoryStream(inBuf), CompressionMode.Decompress))
				{
					const int size = 4096;
					byte[] buffer = new byte[size];
					
					int count = 0;
					do
					{
						count = stream.Read(buffer, 0, size);
						if (count > 0)
						{
							memory.Write(buffer, 0, count);
						}
					}
					while (count > 0);
				}

				Logger.Leave();
				return memory.ToArray();
			}
		}
	}
}