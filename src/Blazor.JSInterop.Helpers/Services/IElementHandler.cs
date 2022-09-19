using Microsoft.AspNetCore.Components;

namespace Blazor.JSInterop.Helpers.Services
{
    public interface IElementHandler
    {
        ValueTask FocusAsync(ElementReference element);
        ValueTask BlurAsync(ElementReference element);
        ValueTask<T> GetPropertyAsync<T>(ElementReference element, string property);
        ValueTask SetPropertyAsync(ElementReference element, string property, string value);
        ValueTask<T> GetStyleAsync<T>(ElementReference element, string property);
        ValueTask SetStyleAsync(ElementReference element, string property, string value);
        ValueTask AddClassAsync(ElementReference element, string className);
        ValueTask ToggleClassAsync(ElementReference element, string className);
        ValueTask RemoveClassAsync(ElementReference element, string className);
    }
}