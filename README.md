![blazor-interop-handlers-banner-700x250](https://user-images.githubusercontent.com/28933557/177880617-3097f9ae-9799-40ad-a5c7-93d9c662f84e.jpg)

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Blazor.JSInterop.Helpers?style=plastic)](https://www.nuget.org/packages/Blazor.JSInterop.Helpers) [![Nuget](https://img.shields.io/nuget/dt/Blazor.JSInterop.Helpers?style=plastic)](https://www.nuget.org/packages/Blazor.JSInterop.Helpers)

## Table of Contents
1. [Overview](#overview)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Documentation](#documentation)
5. [License](#license)

## Overview

When building robust and complex razor components using Blazor, interactions with the Document Object Model (DOM) become inevitable.

 This package extends the JavaScript (JS) interoperability in Blazor through helpers for interacting with the DOM's Window and Element APIs.

## Installation

Package Manager

```powershell
Install-Package Blazor.JSInterop.Handlers -Version 1.1.1
```

.NET CLI

```powershell
dotnet add package Blazor.JSInterop.Handlers
```

PackageReference

```xml
<PackageReference Include="Blazor.JSInterop.Handlers" Version="1.1.1">
```

## Usage

To use the package, you first need to configure your dependency injection (DI) container. Add the following line of code to your `Program.cs`:

```csharp
builder.Services.AddBlazorInteropHandlers();
```

Then add references to the namespaces in your `_Imports.razor` or as directives at the top of your razor component's page:

```csharp
@using Blazor.JSInterop.Helpers.Services
@using Blazor.JSInterop.Helpers.Models
```

Finally, inject instances of the service as needed in your razor component in your directive section or code section:

```csharp
// In directive section
@inject IElementHandler elementHandler
@inject IWindowHandler windowHandler

// In code section
@code
{
    [Inject] IElementHandler elementHandler;
    [Inject] IWindowHandler windowHandler;
}
```

## Documentation

> [View complete API documentation and examples on the wiki](https://github.com/asathkumara/blazor-jsinterop-helpers/wiki/API)

## License

This project is licensed under [MIT](https://github.com/asathkumara/blazor-jsinterop-helpers/blob/master/LICENSE.txt). Feel free to re-use any libraries or code for **non-commercial use** but do your due diligence with attributing credit.
