![blazor-interop-handlers-banner-700x250](https://user-images.githubusercontent.com/28933557/177880617-3097f9ae-9799-40ad-a5c7-93d9c662f84e.jpg)

## Table of Contents
1. [Overview](#overview)
2. [Installation](#installation)
3. [Usage](#usage)
4. [Documentation](#documentation)
5. [Examples](#examples)
6. [License](#license)

## Overview

When building robust and complex razor components using Blazor, interactions with the Document Object Model (DOM) become inevitable.

 This package extends the JavaScript (JS) interoperability in Blazor through helpers for interacting with the DOM's Window and Element APIs.

## Installation

Package Manager

```powershell
Install-Package Blazor.JSInterop.Handlers -Version 1.0.1
```

.NET CLI

```powershell
dotnet add package Blazor.JSInterop.Handlers
```

PackageReference

```xml
<PackageReference Include="Blazor.JSInterop.Handlers" Version="1.0.1">
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

[WindowHandler](#windowhandler)\
  -- [Models](#models)\
  -- [Events](#events)\
  -- [Methods](#methods)\
[ElementHandler](#elementhandler)\
  -- [Methods](#methods-1)\
[Examples](#examples)\
  -- [Alert on window resize event](#alert-when-window-resizes)\
  -- [Focus an element](#focus-an-element)

### WindowHandler
Namespace: Blazor.JSInterop.Helpers.Services\
Inheritance: IWindowHandler &#8594; WindowHandler

Contains event handlers and methods to interact with the DOM's Window API

#### Models
Namespace: Blazor.JSInterop.Helpers.Models

|  |  |
|---|---|
| Screen | Contains information about the Screen |
| ScreenOrientation | Contains information about the screen's orientation |
| Theme | Contains information about the user's preferred theme |
| WindowDimensions | Contains information about the window's dimensions |
| WindowEventArgs | Contains information about the window event |

#### Events

|  |  |
|---|---|
| EventHandler<WindowEventArgs> OnResize | Fires when the window resizes |
| EventHandler<WindowEventArgs> OnOrientationChange | Fires when the screen's orientation changes |


#### Methods

|  |  |
|---|---|
| ValueTask RegisterEventHandlers() | Register event handlers |
| ValueTask AlertAsync(string) | Alerts the user with the given message |
| ValueTask<string> PromptAsync(string) | Prompts the user with the given message |
| ValueTask FocusAsync() | Focuses the window |
| ValueTask BlurAsync() | Blurs focus on the window |
| ValueTask LogToConsoleAsync(string) | Logs the given message to the console |
| ValueTask StartConsoleTimerAsync(string) | Starts a console timer with the given label |
| ValueTask LogConsoleTimerAsync(string) | Logs the console timer with the given label |
| ValueTask StopConsoleTimerAsync(string) | Stops a console timer with the given label |
| ValueTask<Screen> GetScreenAsync() | Gets the Screen object |
| ValueTask<WindowDimensions> GetDimensionsAsync() | Gets the WindowDimensions object |
| ValueTask<Theme> GetThemeAsync(string) | Gets the Theme object |
| ValueTask ScrollToAsync(int, int) | Scrolls the window to the given position |
| ValueTask<bool> MatchesMediaAsync(string) | Matches the given media query |


### ElementHandler

Namespace: Blazor.JSInterop.Helpers.Services\
Inheritance: IElementHandler &#8594; ElementHandler

Contains methods to interact with the DOM's Element API.

#### Methods

|  |  |
|---|---|
| ValueTask FocusAsync(ElementReference) | Sets focus on the given element |
| ValueTask BlurAsync(ElementReference) | Blurs focus on the given element |
| ValueTask<T> GetPropertyAsync(ElementReference, string) | Gets the value of the given element's property |
| ValueTask SetPropertyAsync(ElementReference, string, string) | Sets the specified value on the given element's property |
| ValueTask<T> GetStyleAsync(ElementReference, string) | Gets the value of the given element's style property |
| ValueTask SetStyleAsync(ElementReference, string, string) | Sets the specified value on the given element's style property |
| ValueTask AddClassAsync(ElementReference, string) | Adds a class to the given element |
| ValueTask ToggleClassAsync(ElementReference, string) | Toggles a class on the given element |
| ValueTask RemoveClassAsync(ElementReference, string) | Removes a class on the given element |

### Examples

>When performing JS interop calls and when dealing with component references, it is recommended that you use the `OnAfterRender{Async}` stage as component references will have finished populating at this point.
>
>Some helpers may mutate DOM objects directly. It is recommended that you only mutate the DOM object when the object doesn't interact with Blazor. Otherwise it may invalidate Blazor's internal representation of the DOM, resulting in undefined behavior.

#### Alert when window resizes

Before adding subscribers to events, you must first register the event handlers.

`Example.razor`

```csharp
@page "/"

@using Blazor.JSInterop.Helpers.Services
@using Blazor.JSInterop.Helpers.Models

@implements IDisposable

@inject IWindowHandler windowHandler

<PageTitle>Index</PageTitle>

<h1>Hello, world!</h1>

@code
{
    // Register event handlers and add subscriber
    protected override async Task OnInitializedAsync()
    {
        await windowHandler.RegisterEventHandlers();
        windowHandler.OnResize += OnResizeHandler;
    }

    // When the window resizes, alert the user
    private async void OnResizeHandler(object sender, WindowEventArgs windowEventArgs)
    {
        await windowHandler.AlertAsync("The window was resized!");
    }

    // Unsubscribe when the component is disposed.
    public void Dispose()
    {
        windowHandler.OnResize -= OnResizeHandler;
    }
}
```

> Note: In the preceding example, the component implements IDisposable. It is recommended that you implement either IDisposable or IAsyncDisposable when subscribing to events. If both are implemented, the framework only executes the asynchronous overload.

#### Focus an element

Focus an element when a button is clicked. The component reference is bound and passed to the `FocusAsync(ElementReference)` method.

`Example.razor`

```csharp
@page "/"

@using Blazor.JSInterop.Helpers.Services
@using Blazor.JSInterop.Helpers.Models

@inject IElementHandler elementHandler

<PageTitle>Index</PageTitle>

// @ref binds the component reference
<h1 @ref=@_headingRef>Hello, world!</h1>

<button @onclick=@FocusHeadingOne>Click Me!</button>

@code
{
    // Store component reference
    ElementReference _headingRef;

    private async void FocusHeadingOne()
    {
        await elementHandler.FocusAsync(_headingRef);
    }
}
```

> Note: In the preceding example, the reference to the FocusHeadingOne method was bound to the button tag directly so overriding `OnAfterRender{Async}` was not necessary. 

## License

This project is licensed under [MIT](https://github.com/asathkumara/blazor-jsinterop-helpers/blob/master/LICENSE.txt). Feel free to re-use any libraries or code for **non-commercial use** but do your due diligence with attributing credit.