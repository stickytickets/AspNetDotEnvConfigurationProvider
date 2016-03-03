using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetDotEnvConfigurationProvider
{
	public static class AspDotEnvExtensions
	{
		public static IConfigurationBuilder AddDotEnvVariables(this IConfigurationBuilder configurationBuilder, FileInfo file, bool optional = false)
		{
			configurationBuilder.Add(new AspNetDotEnvConfigurationProvider(file, optional));
			return configurationBuilder;
		}
	}
}
