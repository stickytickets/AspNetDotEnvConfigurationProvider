using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNetDotEnvConfigurationProvider
{
	public static class AspDotEnvExtensions
	{
		public static IConfigurationBuilder AddDotEnvVariables(this IConfigurationBuilder configurationBuilder, FileInfo file, bool optional = false)
		{
			configurationBuilder.Add(new AspNetDotEnvConfigurationSource(file, optional));
			return configurationBuilder;
		}

		public static IConfigurationBuilder AddDotEnvVariables(this IConfigurationBuilder configurationBuilder)
		{
			configurationBuilder.Add(new AspNetDotEnvConfigurationSource(new FileInfo(".env")));
			return configurationBuilder;
		}
	}
}
