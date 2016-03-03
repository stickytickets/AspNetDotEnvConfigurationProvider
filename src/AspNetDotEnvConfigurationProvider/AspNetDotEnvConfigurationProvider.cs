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
		private readonly FileInfo _file;

		public AspNetDotEnvConfigurationProvider(FileInfo file, bool optional = false)
		{
			if (!file.Exists)
			{
				if (optional)
				{
					Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
				}
				else
				{
					throw new FileNotFoundException("File not found", file.FullName);
				}
			}
			else
			{
				if (!file.Extension.Equals(".env", StringComparison.OrdinalIgnoreCase))
				{
					throw new ArgumentException("Invalid file", nameof(Path));
				}
			}

			_file = file;
		}

		private string SanitizeKey(string key)
		{
			return key.Replace("__", ":");
		}

		public override void Load()
		{
			Load(_file);
		}

		internal void Load(FileInfo file)
		{
			var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

			foreach (var line in File.ReadAllLines(file.FullName))
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
