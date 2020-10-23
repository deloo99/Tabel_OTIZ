using System;
using System.Drawing;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal static class ExtensionMethods
    {
        internal static int ToInt(this string source)
        {
            int.TryParse(source, out int result);
            return result;
        }
        internal static bool IsInt(this string source)
        {
            return int.TryParse(source, out _);
        }
        internal static void AppendText(this RichTextBox rtBox, string text, Color color, FontStyle fontStyle)
        {
            rtBox.SelectionStart = rtBox.TextLength;
            rtBox.SelectionLength = 0;
            rtBox.SelectionFont = new Font(rtBox.Font, fontStyle);
            rtBox.SelectionColor = color;
            rtBox.AppendText(text);
            rtBox.SelectionFont = rtBox.Font;
            rtBox.SelectionColor = rtBox.ForeColor;
        }
        internal static ConnectionType GetValue(this ConnectionType _, int num)
        {
            return (ConnectionType)Enum.GetValues(typeof(ConnectionType)).GetValue(num);
        }
        internal static ConnectionType ToConnectionType(this int num)
        {
            return (ConnectionType)Enum.GetValues(typeof(ConnectionType)).GetValue(num);
        }
        internal static string To_1CDate(this DateTime date)
        {
            return date.Hour == 0 && date.Minute == 0 && date.Second == 0
                ? date.ToString("yyyyMMdd")
                : date.ToString("yyyyMMddHHmmss");
        }
    }
}
