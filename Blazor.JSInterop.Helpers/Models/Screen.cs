using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.JSInterop.Helpers.Models
{
    public struct Screen
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public ScreenOrientation Orientation { get; set; }

        public Screen(int width, int height, ScreenOrientation orientation)
        {
            Width = width;
            Height = height;
            Orientation = orientation;
        }
    }
}
