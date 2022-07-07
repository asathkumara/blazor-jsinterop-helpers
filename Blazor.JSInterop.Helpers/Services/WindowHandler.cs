using Blazor.JSInterop.Helpers.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.JSInterop.Helpers.Services
{
    /// <summary>
    /// Contains methods to interact with the Window
    /// </summary>
    /// <remarks>Mutating the DOM in Blazor could result in undefined behavior.</remarks>
    public class WindowHandler : IWindowHandler, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _windowHandlerModule;

        public event EventHandler<WindowEventArgs> OnResize;
        public event EventHandler<WindowEventArgs> OnOrientationChange;

        public WindowHandler(IJSRuntime jsRuntime)
        {
            _windowHandlerModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/Blazor.JSInterop.Helpers/windowHandler.js").AsTask());
        }

        /// <summary>
        /// Register event handlers for the Window object
        /// </summary>
        public async ValueTask RegisterEventHandlers()
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("registerEventHandlers", DotNetObjectReference.Create(this));
        }

        /// <summary>
        /// Notifies subscribers of the window resize event
        /// </summary>
        /// <param name="windowEventArgs">The window event arguments to forward</param>
        /// <remarks>This method is invoked from JavaScript</remarks>
        [JSInvokable]
        public void OnResizeNotifier(WindowEventArgs windowEventArgs)
        {
            OnResize?.Invoke(this, windowEventArgs);

        }

        /// <summary>
        /// Notifies subscribers of the screen's orientation change event
        /// </summary>
        /// <param name="windowEventArgs">The window event arguments to forward</param>
        /// <remarks>This method is invoked from JavaScript</remarks>
        [JSInvokable]
        public void OnOrientationChangeNotifier(WindowEventArgs windowEventArgs)
        {
            OnOrientationChange?.Invoke(this, windowEventArgs);
        }

        /// <summary>
        /// Alerts the user using the given message
        /// </summary>
        /// <param name="message">The alert message</param>
        public async ValueTask AlertAsync(string message)
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("alert", message);
        }

        /// <summary>
        /// Prompts the user with the given message
        /// </summary>
        /// <param name="message">The prompt's message</param>
        /// <returns>The user's response</returns>
        public async ValueTask<string> PromptAsync(string message)
        {
            var module = await _windowHandlerModule.Value;
            return await module.InvokeAsync<string>("prompt", message);
        }

        /// <summary>
        /// Focuses the window
        /// </summary>
        public async ValueTask FocusAsync()
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("focus");
        }

        /// <summary>
        /// Blurs focus on the window
        /// </summary>
        public async ValueTask BlurAsync()
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("blur");
        }

        /// <summary>
        /// Opens the print dialogue for the window
        /// </summary>
        public async ValueTask PrintAsync()
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("print");
        }

        /// <summary>
        /// Logs the given message to the console
        /// </summary>
        /// <param name="message">The message to be logged</param>
        public async ValueTask LogToConsoleAsync(string message)
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("logToConsole", message);
        }

        /// <summary>
        /// Starts a console timer with the given label
        /// </summary>
        /// <param name="timerLabel">The timer's label</param>
        public async ValueTask StartConsoleTimerAsync(string timerLabel = "default")
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("startConsoleTimer", timerLabel);
        }

        /// <summary>
        /// Logs the console timer with the given label
        /// </summary>
        /// <param name="timerLabel">The timer's label</param>
        public async ValueTask LogConsoleTimerAsync(string timerLabel = "default")
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("logConsoleTimer", timerLabel);
        }

        /// <summary>
        /// Stops the console timer with the given label
        /// </summary>
        /// <param name="timerLabel">The timer's label</param>
        public async ValueTask StopConsoleTimerAsync(string timerLabel = "default")
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("stopConsoleTimer", timerLabel);
        }

        /// <summary>
        /// Gets the screen
        /// </summary>
        /// <returns>The screen object</returns>
        public async ValueTask<Screen> GetScreenAsync()
        {
            var module = await _windowHandlerModule.Value;
            return await module.InvokeAsync<Screen>("getScreen");
        }

        /// <summary>
        /// Gets the window dimensions
        /// </summary>
        /// <returns>The window dimensions object</returns>
        public async ValueTask<WindowDimensions> GetDimensionsAsync()
        {
            var module = await _windowHandlerModule.Value;
            return await module.InvokeAsync<WindowDimensions>("getWindowDimensions");
        }

        /// <summary>
        /// Gets the user's preferred theme
        /// </summary>
        /// <returns>The dark or light theme</returns>
        public async ValueTask<Theme> GetThemeAsync()
        {
            return await MatchesMediaAsync("(prefers-color-scheme: dark)") ? Theme.Dark
                                                                           : Theme.Light;
        }


        /// <summary>
        /// Scrolls to the given X and Y
        /// </summary>
        /// <param name="x">The X position</param>
        /// <param name="y">The Y position</param>
        public async ValueTask ScrollToAsync(int x, int y)
        {
            var module = await _windowHandlerModule.Value;
            await module.InvokeVoidAsync("scrollTo", x, y);
        }


        /// <summary>
        /// Checks whether the given media query matches
        /// </summary>
        /// <param name="mediaQuery">The media query to be matched</param>
        /// <returns>True if the query matches; False otherwise</returns>
        public async ValueTask<bool> MatchesMediaAsync(string mediaQuery)
        {
            var module = await _windowHandlerModule.Value;
            return await module.InvokeAsync<bool>("matchesMedia", mediaQuery);
        }

        public async ValueTask DisposeAsync()
        {
            if (_windowHandlerModule.IsValueCreated)
            {
                var module = await _windowHandlerModule.Value;
                await module.DisposeAsync();
            }
        }


    }
}