using System;
using System.Diagnostics;

namespace UninstallEAssistant
{
	class Program
	{
		static void Main(string[] args)
		{
			String code = @"{88C7BF48-2846-4271-9D5D-3AAA3DBA38F4}";
			
			Process uninstallProcess = new Process();
			uninstallProcess.StartInfo.FileName = "msiexec.exe";
			uninstallProcess.StartInfo.Arguments = String.Format("/I{0}", code);
			uninstallProcess.StartInfo.UseShellExecute = false;
			uninstallProcess.Start();
		}
	}
}
