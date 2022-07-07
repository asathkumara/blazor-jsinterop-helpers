using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.JSInterop.Helpers.Models
{
    public struct ScreenOrientation
    {
        public string Type { get; set; }

        public int Angle { get; set; }

        public ScreenOrientation(string type, int angle)
        {
            Type = type;
            Angle = angle;
        }
    }
}
