using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using NahkLogic.Common;

namespace Nahk.Utils;
[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    public int Left;        // x position of upper-left corner  
    public int Top;         // y position of upper-left corner  
    public int Right;       // x position of lower-right corner  
    public int Bottom;      // y position of lower-right corner  
}

public static class Nhk
{
    private static Bitmap? _bmp;
    private static readonly object Lock = new object();

    [DllImport("user32.dll", SetLastError = true)]
    public static extern nint GetDesktopWindow();
    [DllImport("user32.dll", SetLastError = true)]
    public static extern nint GetWindowDC(nint window);
    
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int ReleaseDC(nint window, nint dc);
    //[DllImport("user32.dll", SetLastError = true)]
    //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(nint hWnd);
    [DllImport("user32.dll")]
    static extern nint GetForegroundWindow();
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(nint hWnd, out Rect lpRect);
    
    public static Point ScreenToWindowPoint(nint hWnd, Point screenPoint)
    {
        GetWindowRect(hWnd, out var winRect);
        return new Point(screenPoint.X - winRect.Left, screenPoint.Y - winRect.Top);
    }

    public static Point WindowToScreenPoint(nint hWnd, Point windowPoint)
    {
        GetWindowRect(hWnd, out var winRect);
        return new Point(winRect.Left + windowPoint.X, winRect.Top + windowPoint.Y);
    }

    public static nint GetWindowHandle(string partialTitle)
    {
        foreach (var proc in Process.GetProcesses())
        {
            if (proc.MainWindowTitle.ToLower().Equals(partialTitle.ToLower()))
            {
                return proc.MainWindowHandle;
            }
        }
        return nint.Zero;
    }

    public static string ToHex(this Color c) => $"0x{c.R:X2}{c.G:X2}{c.B:X2}";
    public static string ToRgb(this Color c) => $"RGB({c.R},{c.G},{c.B})";
    public static Color FromHexString(string hex) => Color.FromArgb(int.Parse(hex.Replace("0x", "FF"), NumberStyles.HexNumber));

    public static bool IsWinActive(nint hWndToCheck) => GetForegroundWindow() == hWndToCheck;

    /// <summary>
    /// Call this a few times per frame, then call GetBmpPixel to sample colors from the most recent screen grab.
    /// </summary>
    /// <param name="hWnd">Handle to window that will be captured</param>
    public static void CaptureWindowBmp(nint hWnd)
    {
        if (hWnd == nint.Zero) return;

        GetWindowRect(hWnd, out var rect);
        var width = rect.Right - rect.Left;
        var height = rect.Bottom - rect.Top;

        if (width <= 0 || height <= 0) return;

        var tmp = new Bitmap(width, height);
        using var graphics = Graphics.FromImage(tmp);
        graphics.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

        lock (Lock)
        {
            _bmp?.Dispose();
            _bmp = tmp;
        }
    }

    public static Color? GetBmpPixel(Point wndPoint)
    {
        try
        {
            lock (Lock)
            {
                if (_bmp == null) return null;
                if (wndPoint.X < 0 || wndPoint.Y < 0) return null;
                if (wndPoint.X > _bmp.Width || wndPoint.Y > _bmp.Height) return null;

                return _bmp.GetPixel(wndPoint.X, wndPoint.Y);
            }

        }
        catch (Exception e)
        {
            return null;
        }
    }

    public static Point? SearchAreaForColors(IntPtr hWnd, Point wndStartPoint, PixelCheck[] pixelsChecks, int maxSearchDist, bool precise, int granularity = 2)
    {
        var layer = 1;
        var leg = 0;
        var xOffset = 0;
        var yOffset = 0;
        var iteration = 0;

        while (layer <= maxSearchDist)
        {
            switch (leg)
            {
                case 0:
                    ++xOffset;
                    if (xOffset == layer)
                    {
                        ++leg;
                    }

                    break;
                case 1:
                    ++yOffset;
                    if (yOffset == layer)
                    {
                        ++leg;
                    }

                    break;
                case 2:
                    --xOffset;
                    if (-xOffset == layer)
                    {
                        ++leg;
                    }

                    break;
                case 3:
                    --yOffset;
                    if (-yOffset == layer)
                    {
                        leg = 0;
                        ++layer;
                    }

                    break;
            }

            ++iteration;
            if (iteration % granularity != 0) continue;

            var point = new Point(wndStartPoint.X + xOffset, wndStartPoint.Y + yOffset);
            var pixelColor = GetBmpPixel(point);

            if (pixelColor == null) return null;

            for (int i = 0; i < pixelsChecks.Length; i++)
            {
                if (layer > pixelsChecks[i].AreaSearchDistance) continue;

                if (pixelColor == pixelsChecks[i].Color && (!precise || pixelColor == GetColorAtWndPoint(hWnd, point))) return point;
            }
        }

        return null;
    }

    public static Color GetColorAt(Point screenPoint)
    {
        IntPtr desk = GetDesktopWindow();
        IntPtr dc = GetWindowDC(desk);
        int a = (int)GetPixel(dc, screenPoint.X, screenPoint.Y);
        ReleaseDC(desk, dc);
        return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
    }

    [DllImport("gdi32.dll", SetLastError = true)]
    private static extern uint GetPixel(IntPtr dc, int x, int y);

    private static Color GetColorAtWndPoint(IntPtr hWnd, Point wndPoint) => GetColorAt(WindowToScreenPoint(hWnd, wndPoint));

}

