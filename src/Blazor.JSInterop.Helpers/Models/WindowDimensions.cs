using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.JSInterop.Helpers.Models
{
    public struct WindowDimensions
    {
        public int InnerWidth { get; set; }
        public int InnerHeight { get; set; }
        public int OuterWidth { get; set; }
        public int OuterHeight { get; set; }

        public WindowDimensions(int innerWidth, int innerHeight, int outerWidth, int outerHeight)
        {
            InnerWidth = innerWidth;
            InnerHeight = innerHeight;
            OuterWidth = outerWidth;
            OuterHeight = outerHeight;
        }
    }
}
