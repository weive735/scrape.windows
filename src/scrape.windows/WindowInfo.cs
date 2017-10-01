using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrape.windows
{
    public class WindowInfo
    {
        public string ClassName { get; set; }
        public string Title { get; set; }
        public IntPtr WindowHandle { get; set; }
        public int Style { get; set; }
    }
}
