using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace scrape.windows
{
    public class Win32API
    {
        public static int WM_LBUTTONDOWN = 0x201;
        public static int WM_LBUTTONUP = 0x202;
        public static int MK_LBUTTON = 0x0001;
        public static int GWL_STYLE = -16;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 指定された座標を含むウィンドウのハンドルを取得します。
        /// この関数は、非表示のウィンドウや無効化されているウィンドウのハンドルは取り出しません。
        /// このような制限のない検索を行いたい場合は、ChildWindowFromPoint 関数を使ってください。
        /// </summary>
        /// <param name="point">調査する座標が入った 構造体を指定します。</param>
        /// <returns>
        /// 関数が成功すると、指定した座標を含むウィンドウのハンドルが返ります。
        /// 指定した座標にウィンドウがないときは、NULL が返ります。
        /// 指定した座標がスタティックテキストコントロールに重なっていた場合は、そのスタティックテキストコントロールの下にあるウィンドウのハンドルが返ります。
        /// </returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr WindowFromPoint(POINT point);

    }
}
