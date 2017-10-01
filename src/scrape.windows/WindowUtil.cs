using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrape.windows
{
    public static class WindowUtil
    {
        public static WindowInfo GetWindowInfo(IntPtr windowHandle)
        {
            int textLen = Win32API.GetWindowTextLength(windowHandle);
            string windowText = null;
            if (0 < textLen)
            {
                //ウィンドウのタイトルを取得する
                StringBuilder windowTextBuffer = new StringBuilder(textLen + 1);
                Win32API.GetWindowText(windowHandle, windowTextBuffer, windowTextBuffer.Capacity);
                windowText = windowTextBuffer.ToString();
            }

            //ウィンドウのクラス名を取得する
            StringBuilder classNameBuffer = new StringBuilder(256);
            Win32API.GetClassName(windowHandle, classNameBuffer, classNameBuffer.Capacity);

            // スタイルを取得する
            int style = Win32API.GetWindowLong(windowHandle, Win32API.GWL_STYLE);

            return new WindowInfo()
            {
                WindowHandle = windowHandle,
                Title = windowText,
                ClassName = classNameBuffer.ToString(),
                Style = style
            };

        }
    }
}
