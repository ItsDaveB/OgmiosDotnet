# Ogmios Schema Class Library

This project provides a .NET class library designed to auto-generate strongly-typed C# classes based on the Ogmios JSON schema. These generated types make it easier to work with Ogmios data in .NET applications by ensuring type safety and enabling more intuitive data handling. Learn more about the underlying tooling I used for automatic schema generation at the [Corvus.JsonSchema GitHub page](https://github.com/corvus-dotnet/Corvus.JsonSchema), which supports comprehensive build-time code generation for JSON schema validation and serialization.

The Corvus.JsonSchema library supports full serialization and validation for all features of JSON Schema, from drafts 4 through 2020-12, including the OpenAPI 3.0 variant of draft 4. It handles even the most complex structures gracefully. A big thank you to enjin for sponsoring this open source project you can find out more about them here. https://endjin.com/what-we-do/open-source/

The aim of this class library and documentation is not only to simplify working with Ogmios data but also to encourage contributions from the community for ongoing schema upgrades and enhancements.

---

## Features

- **Automatic Code Generation**: Generates .NET classes based on a JSON schema file, simplifying the process of working with structured data.
- **Full JSON Schema Support**: Handles all features of JSON schema, including the latest standards and OpenAPI specifications.
- **Namespace Customization**: Easily specify a custom root namespace for your generated classes.
- **Disable Naming Heuristic**: Allows you to disable automatic naming conventions to retain the original schema naming.

---

## Getting Started

### Prerequisites

- **.NET SDK**: Ensure that the latest version of the [.NET SDK](https://dotnet.microsoft.com/download) is installed on your machine to build and run the project effectively.
- **Schema Files**: Verify that `ogmios.json` and `Cardano.json` are available in your working directory. You can download these schema files from the Ogmios API documentation under the specific version you need, such as [Ogmios API v6.7](https://ogmios.dev/api/v6.7/).

### Installation

First, install the `Corvus.Json.JsonSchema.TypeGeneratorTool` globally:

```bash
dotnet tool install --global Corvus.Json.JsonSchema.TypeGeneratorTool
```

## Usage

To generate the .NET types from the `ogmios.json` schema file, run the following command in your terminal under the correct version within the context of the Ogmios folder.

```bash
generatejsonschematypes --rootNamespace Generated -disableNamingHeuristic --outputPath Generated v6.11/Source/ogmios.json
```
