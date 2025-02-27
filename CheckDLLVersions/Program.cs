using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("CheckDLLVersion v1.0");

		if (args.Length == 0)
		{
			Console.WriteLine("Using: CheckDllVersions.exe <folder>");
			return;
		}

		string directory = args[0];
		if (!Directory.Exists(directory))
		{
			Console.WriteLine($"Folder doesn't exists : {directory}");
			return;
		}

		var files = Directory.GetFiles(directory, "*.dll").Concat(Directory.GetFiles(directory, "*.exe"));
		Dictionary<string, Dictionary<string, List<string>>> dllReferences = new Dictionary<string, Dictionary<string, List<string>>>();

		foreach (var file in files)
		{
			try
			{
				Assembly assembly = Assembly.LoadFrom(file);
				foreach (var reference in assembly.GetReferencedAssemblies())
				{
					if (!dllReferences.ContainsKey(reference.Name))
					{
						dllReferences[reference.Name] = new Dictionary<string, List<string>>();
					}
					string version = reference.Version.ToString();
					if (!dllReferences[reference.Name].ContainsKey(version))
					{
						dllReferences[reference.Name][version] = new List<string>();
					}
					dllReferences[reference.Name][version].Add(file);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error reading {file}: {ex.Message}");
			}
		}

		foreach (var dll in dllReferences)
		{
			if (dll.Value.Count > 1)
			{
				Console.WriteLine($"DLL version conflict for: {dll.Key}");
				foreach (var version in dll.Value)
				{
					Console.WriteLine($"  Version: {version.Key}");
					foreach (var refFile in version.Value)
					{
						Console.WriteLine($"    Referenced in: { Path.GetFileName(refFile)}");
					}
				}
			}
		}
	}
}
