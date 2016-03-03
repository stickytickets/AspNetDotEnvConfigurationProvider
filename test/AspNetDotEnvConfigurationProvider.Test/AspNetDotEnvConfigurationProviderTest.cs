using System.IO;
using Xunit;

namespace AspNetDotEnvConfigurationProvider.Test
{
	public class AspNetDotEnvConfigurationProviderTest
	{
		[Fact]
		public void LoadKeyValuePairsFromFile()
		{
			//var dict = new Hashtable()
			//	{
			//		{"DefaultConnection:ConnectionString", "TestConnectionString"},
			//		{"DefaultConnection:Provider", "SqlClient"},
			//		{"Inventory:ConnectionString", "AnotherTestConnectionString"},
			//		{"Inventory:Provider", "MySql"}
			//	};
			//var envConfigSrc = new AspNetDotEnvConfigurationProvider();

			//envConfigSrc.Load(new FileInfo());

			//Assert.Equal("TestConnectionString", envConfigSrc.Get("defaultconnection:ConnectionString"));
			//Assert.Equal("SqlClient", envConfigSrc.Get("DEFAULTCONNECTION:PROVIDER"));
			//Assert.Equal("AnotherTestConnectionString", envConfigSrc.Get("Inventory:CONNECTIONSTRING"));
			//Assert.Equal("MySql", envConfigSrc.Get("Inventory:Provider"));
		}


		[Fact]
		public void LastVariableAddedWhenMultipleEnvironmentVariablesWithSameNameButDifferentCaseExist()
		{
			//var dict = new Hashtable()
			//	{
			//		{"CommonEnv", "CommonEnvValue1"},
			//		{"commonenv", "commonenvValue2"},
			//		{"cOMMonEnv", "commonenvValue3"},
			//	};
			//var envConfigSrc = new EnvironmentVariablesConfigurationProvider();

			//envConfigSrc.Load(dict);

			//Assert.True(!string.IsNullOrEmpty(envConfigSrc.Get("cOMMonEnv")));
			//Assert.True(!string.IsNullOrEmpty(envConfigSrc.Get("CommonEnv")));
		}

		[Fact]
		public void ReplaceDoubleUnderscoreInEnvironmentVariables()
		{
			//var dict = new Hashtable()
			//	{
			//		{"data__ConnectionString", "connection"},
			//		{"SQLCONNSTR__db1", "connStr"}
			//	};
			//var envConfigSrc = new EnvironmentVariablesConfigurationProvider();

			//envConfigSrc.Load(dict);

			//Assert.Equal("connection", envConfigSrc.Get("data:ConnectionString"));
			//Assert.Equal("System.Data.SqlClient", envConfigSrc.Get("Data:_db1:ProviderName"));
		}
	}
}
