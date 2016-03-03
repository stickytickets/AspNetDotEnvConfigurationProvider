using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Collections;

namespace AspNetDotEnvConfigurationProvider
{
	// This project can output the Class library as a NuGet Package.
	// To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
	public class AspNetDotEnvConfigurationProvider : ConfigurationProvider
	{
		public string Path { get; }
		public bool Optional { get; }

		public AspNetDotEnvConfigurationProvider(string path, bool optional = false)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentException("Invalid file path", nameof(path));
			}

			Optional = optional;
			Path = path;
		}

		public void Load(Hashtable dic)
		{
			Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			
			foreach (DictionaryEntry entry in dic)
			{
				var key = SanitizeKey((string)entry.Key);
				Data[key] = (string)entry.Value;
			}
		}

		private string SanitizeKey(string key)
		{
			return key.Replace("__", ":");
		}

		public override void Load()
		{
			if (!File.Exists(Path))
			{
				if (Optional)
				{
					Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				}
				else
				{
					throw new FileNotFoundException("File not found", Path);
				}
			}
			else
			{
				var file = new FileInfo(Path);

				if (!file.Extension.Equals(".env", StringComparison.OrdinalIgnoreCase))
				{
					throw new ArgumentException("Invalid file", nameof(Path));
				}
				
				Load(Path);
			}
		}

		internal void Load(string fileName)
		{
			var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			foreach (var line in File.ReadAllLines(fileName))
			{
				var split = line.Split(new char[] { '=' }, 2);

				if (split.Length != 2)
					continue;

				var key = SanitizeKey(split[0]);

				if (String.IsNullOrWhiteSpace(key)) continue;

				result[key.Trim()] = split[1].Trim();
			}

			Data = result;
		}

		public string Get(string key)
		{
			return Data[key];
		} 
	}
}
