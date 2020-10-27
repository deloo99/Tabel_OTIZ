using System;
using System.Drawing;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal static class ExtensionMethods
    {
        internal static int ToInt(this string source)
           => int.TryParse(source, out int result) ? result : 0;
        internal static bool IsInt(this string source)
            => int.TryParse(source, out _);
        internal static string ToSolidDate(this DateTime date)
            => date.Hour == 0 && date.Minute == 0 && date.Second == 0
                ? date.ToString("yyyyMMdd")
                : date.ToString("yyyyMMddHHmmss");

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
    }
}
