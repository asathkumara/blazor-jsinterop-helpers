using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.JSInterop.Helpers.Services
{
    /// <summary>
    /// Contains methods to interact with HTMLElements
    /// </summary>
    /// <remarks>Mutating the DOM in Blazor could result in undefined behavior.</remarks>
    public class ElementHandler : IElementHandler, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _elementHandlerModule;
        private readonly string scriptPath = "_content/Blazor.JSInterop.Helpers/scripts/elementHandler.min.js";

        public ElementHandler(IJSRuntime jsRuntime, NavigationManager navigationManager)
        {
            var path = navigationManager.ToAbsoluteUri(scriptPath);
            _elementHandlerModule = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", path).AsTask());
        }

        /// <summary>
        /// Sets focus to the given element
        /// </summary>
        /// <param name="element">The element to be focused</param>
        public async ValueTask FocusAsync(ElementReference element)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("focus", element);
        }

        /// <summary>
        /// Blurs focus from the given element
        /// </summary>
        /// <param name="element">The element to be blurred</param>
        public async ValueTask BlurAsync(ElementReference element)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("blur", element);
        }

        /// <summary>
        /// Gets the property of the given element that matches the given name
        /// </summary>
        /// <typeparam name="T">The expected value of the property</typeparam>
        /// <param name="element">The element whose property is to be retrieved</param>
        /// <param name="property">The property to be retrieved</param>
        /// <returns>The value of the given property</returns>
        public async ValueTask<T> GetPropertyAsync<T>(ElementReference element, string property)
        {
            var module = await _elementHandlerModule.Value;
            return await module.InvokeAsync<T>("getProperty", element, property);
        }

        /// <summary>
        /// Sets the property of the given element to the given value
        /// </summary>
        /// <param name="element">The element whose property is to be set</param>
        /// <param name="property">The property to be set</param>
        /// <param name="value">The value to be assigned</param>
        public async ValueTask SetPropertyAsync(ElementReference element, string property, string value)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("setProperty", element, property, value);
        }

        /// <summary>
        /// Gets the style of the given element that matches the given property
        /// </summary>
        /// <typeparam name="T">The expected value of the style</typeparam>
        /// <param name="element">The element whose style is to be retrieved</param>
        /// <param name="property">The property to be retrieved</param>
        /// <returns>The value of the property</returns>
        public async ValueTask<T> GetStyleAsync<T>(ElementReference element, string property)
        {
            var module = await _elementHandlerModule.Value;
            return await module.InvokeAsync<T>("getStyle", element, property);
        }


        /// <summary>
        /// Sets the style of the given element to the given value
        /// </summary>
        /// <param name="element">The element whose style is to be set</param>
        /// <param name="property">The property to be set</param>
        /// <param name="value">The value to be assigned</param>
        public async ValueTask SetStyleAsync(ElementReference element, string property, string value)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("setStyle", element, property, value);
        }

        /// <summary>
        /// Adds a class to the given element
        /// </summary>
        /// <param name="element">The element to be given a class</param>
        /// <param name="className">The name of the class to be added</param>
        public async ValueTask AddClassAsync(ElementReference element, string className)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("addClass", element, className);
        }

        /// <summary>
        /// Toggles a class on the given element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="className">The name of the class to be toggled</param>
        public async ValueTask ToggleClassAsync(ElementReference element, string className)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("toggleClass", element, className);
        }

        /// <summary>
        /// Removes a class to the given element
        /// </summary>
        /// <param name="element">The element whose class is to be removed</param>
        /// <param name="className">The name of the class to be removed</param>
        public async ValueTask RemoveClassAsync(ElementReference element, string className)
        {
            var module = await _elementHandlerModule.Value;
            await module.InvokeVoidAsync("removeClass", element, className);
        }

        public async ValueTask DisposeAsync()
        {
            if (_elementHandlerModule.IsValueCreated)
            {
                var module = await _elementHandlerModule.Value;
                await module.DisposeAsync();
            }
        }
    }
}