using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.JSInterop.Helpers.Models
{
    public class WindowEventArgs : EventArgs
    {
        public WindowDimensions WindowDimensions { get; set; }
        public Screen Screen { get; set; }
    }
}
