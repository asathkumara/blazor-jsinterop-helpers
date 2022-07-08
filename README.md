![blazor-interop-handlers-banner-700x250](https://user-images.githubusercontent.com/28933557/177880617-3097f9ae-9799-40ad-a5c7-93d9c662f84e.jpg)

![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Blazor.JSInterop.Helpers?style=plastic)

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

[WindowHandler](#windowhandler)</br>
  -- [Models](#models)</br>
  -- [Events](#events)</br>
  -- [Methods](#methods)</br>
[ElementHandler](#elementhandler)</br>
  -- [Methods](#methods-1)</br>
[Examples](#examples)</br>
  -- [Alert on window resize event](#alert-when-window-resizes)</br>
  -- [Focus an element](#focus-an-element)

### WindowHandler
Namespace: Blazor.JSInterop.Helpers.Services</br>
Inheritance: IWindowHandler &#8594; WindowHandler

Contains event handlers and methods to interact with the DOM's Window API

#### Models
Namespace: Blazor.JSInterop.Helpers.Models
<table>
    <tr>
        <td>Screen</td>
        <td>Contains information about the Screen</td>
    </tr>
    <tr>
        <td>ScreenOrientation</td>
        <td>Contains information about the screen's orientation</td>
    </tr>
    <tr>
        <td>Theme</td>
        <td>Contains information about the user's preferred theme</td>
    </tr>
    <tr>
        <td>WindowDimensions</td>
        <td>Contains information about the window's dimensions</td>
    </tr>
    <tr>
        <td>WindowEventArgs</td>
        <td>Contains information about the window event</td>
    </tr>
</table>

#### Events

<table>
    <tr>
        <td>EventHandler&lt;WindowEventArgs&gt; OnResize</td>
        <td>Fires when the window resizes</td>
    </tr>
    <tr>
        <td>EventHandler&lt;WindowEventArgs&gt; OnOrientationChange</td>
        <td>Fires when the screen's orientation changes</td>
    </tr>
</table>


#### Methods

<table>
    <tr>
        <td>ValueTask RegisterEventHandlers()</td>
        <td>Register event handlers</td>
    </tr>
    <tr>
        <td>ValueTask AlertAsync(string)</td>
        <td>Alerts the user with the given message</td>
    </tr>
    <tr>
        <td>ValueTask&lt;string&gt; PromptAsync(string)</td>
        <td>Prompts the user with the given message</td>
    </tr>
    <tr>
        <td>ValueTask FocusAsync()</td>
        <td>Focuses the window</td>
    </tr>
    <tr>
        <td>ValueTask BlurAsync()</td>
        <td>Blurs focus on the window</td>
    </tr>
    <tr>
        <td>ValueTask LogToConsoleAsync(string)</td>
        <td>Logs the given message to the console</td>
    </tr>
    <tr>
        <td>ValueTask StartConsoleTimerAsync(string)</td>
        <td>Starts a console timer with the given label</td>
    </tr>
    <tr>
        <td>ValueTask LogConsoleTimerAsync(string)</td>
        <td>Logs the console timer with the given label</td>
    </tr>
    <tr>
        <td>ValueTask StopConsoleTimerAsync(string)</td>
        <td>Stops a console timer with the given label</td>
    </tr>
    <tr>
        <td>ValueTask&lt;Screen&gt; GetScreenAsync()</td>
        <td>Gets the Screen object</td>
    </tr>
    <tr>
        <td>ValueTask&lt;WindowDimensions&gt; GetDimensionsAsync()</td>
        <td>Gets the WindowDimensions object</td>
    </tr>
    <tr>
        <td>ValueTask&lt;Theme&gt; GetThemeAsync(string)</td>
        <td>Gets the Theme object</td>
    </tr>
    <tr>
        <td>ValueTask ScrollToAsync(int, int)</td>
        <td>Scrolls the window to the given position</td>
    </tr>
    <tr>
        <td>ValueTask&lt;bool&gt; MatchesMediaAsync(string)</td>
        <td>Matches the given media query</td>
    </tr>
</table>


### ElementHandler

Namespace: Blazor.JSInterop.Helpers.Services</br>
Inheritance: IElementHandler &#8594; ElementHandler

Contains methods to interact with the DOM's Element API.

#### Methods

<table>
    <tr>
        <td>ValueTask FocusAsync(ElementReference)</td>
        <td>Sets focus on the given element</td>
    </tr>
    <tr>
        <td>ValueTask BlurAsync(ElementReference)</td>
        <td>Blurs focus on the given element</td>
    </tr>
    <tr>
        <td>ValueTask&lt;T&gt; GetPropertyAsync(ElementReference, string)</td>
        <td>Gets the value of the given element's property</td>
    </tr>
    <tr>
        <td>ValueTask SetPropertyAsync(ElementReference, string, string)</td>
        <td>Sets the specified value on the given element's property</td>
    </tr>
    <tr>
        <td>ValueTask&lt;T&gt; GetStyleAsync(ElementReference, string)</td>
        <td>Gets the value of the given element's style property</td>
    </tr>
    <tr>
        <td>ValueTask SetStyleAsync(ElementReference, string, string)</td>
        <td>Sets the specified value on the given element's style property</td>
    </tr>
    <tr>
        <td>ValueTask AddClassAsync(ElementReference, string)</td>
        <td>Adds a class to the given element</td>
    </tr>
    <tr>
        <td>ValueTask ToggleClassAsync(ElementReference, string)</td>
        <td>Toggles a class on the given element</td>
    </tr>
    <tr>
        <td>ValueTask RemoveClassAsync(ElementReference, string)</td>
        <td>Removes a class on the given element</td>
    </tr>
</table>

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
