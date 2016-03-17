# AspNetDotEnvConfigurationProvider
Configuration provider for .env files

Install it using the package manager console

```
PM> Install-Package AspNetDotEnvConfigurationProvider -Pre

```

### Usage ###

Create a .env file on the root directory of your project

##### sample .env
```
DefaultConnection__ConnectionString = TestConnectionString
DefaultConnection__Provider = SqlClient
Inventory__ConnectionString = AnotherTestConnectionString
Inventory__Provider = MySql
```

This will read and load the ".env" file on your project root directory by default
```
var builder = new ConfigurationBuilder()
				.AddDotEnvVariables()
				
Configuration = builder.Build();
```

If you have specific file name for .env file, You can pass it to the parameter of .AddDotEnvVariables()
```
var builder = new ConfigurationBuilder()
				.AddDotEnvVariables(new System.IO.FileInfo("test.env"))

Configuration = builder.Build();
```


sample code to read values from .env
```
  Configuration["DefaultConnection:ConnectionString"]
```

### Note
* Double underscore(__) on .env will replace by colon ":"
