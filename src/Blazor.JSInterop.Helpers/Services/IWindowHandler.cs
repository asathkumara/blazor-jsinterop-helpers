using Blazor.JSInterop.Helpers.Models;

namespace Blazor.JSInterop.Helpers.Services
{
    public interface IWindowHandler
    {
        event EventHandler<WindowEventArgs> OnOrientationChange;
        event EventHandler<WindowEventArgs> OnResize;

        ValueTask RegisterEventHandlers();
        ValueTask AlertAsync(string message);
        ValueTask<string> PromptAsync(string message);
        ValueTask FocusAsync();
        ValueTask BlurAsync();
        ValueTask PrintAsync();
        ValueTask LogToConsoleAsync(string message);
        ValueTask StartConsoleTimerAsync(string timerLabel = "default");
        ValueTask LogConsoleTimerAsync(string timerLabel = "default");
        ValueTask StopConsoleTimerAsync(string timerLabel = "default");
        ValueTask<Screen> GetScreenAsync();
        ValueTask<WindowDimensions> GetDimensionsAsync();
        ValueTask<Theme> GetThemeAsync();
        ValueTask ScrollToAsync(int x, int y);
        ValueTask<bool> MatchesMediaAsync(string mediaQuery);

    }
}