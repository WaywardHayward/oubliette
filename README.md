# OUBLIETTE

[![.NET](https://github.com/WaywardHayward/oubliette/actions/workflows/dotnet.yml/badge.svg)](https://github.com/WaywardHayward/oubliette/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/WaywardHayward/oubliette/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/WaywardHayward/oubliette/actions/workflows/codeql-analysis.yml)

This is a dotnet worker service which is used to monitor the Downloads folder of the current user and organize the files into a folder structure.

## Getting Started

To build this service you will need dotnet cli and dotnet 6.

Run the following command to install dotnet cli and dotnet 6.

```
dotnet tool install --global dotnet-cli-tools
dotnet tool install --global dotnet-core-sdk-6.0.0
```

Run the following command to build the service.

```
dotnet build -c Release
```

run the following command to run the service.

```
dotnet run -c Release
```

## Additional Setup

In order to get the service to work automatically you will need to run the following command as administrator.

```
 ./Schedule.ps1 [publisher_output_directory]\oubliette.dll
```

where the [publisher_output_directory] is the directory where the service has been built.

