using System;
using System.Collections.Specialized;

namespace OTIZ_Tabel
{
    internal static class Settings
    {
        private static StringCollection _comConnectionStringsCollection;
        private static StringCollection _webLinksCollection;
        private static string _comConnectionString;
        private static string _webLink;
        private static string _userName;
        private static string _userPassword;
        private static int? _codeCol;
        private static int? _fioCol;
        private static int? _appearCol;
        private static int? _nightCol;
        private static int? _feastCol;
        private static int? _firstRow;
        private static int? _lastRow;
        private static DateTime? _firstDate;
        private static DateTime? _lastDate;
        private static bool? _preload;
        private static ConnectionType? _onnectionType;

        internal static StringCollection COMConnectionStringsCollection
        {
            get => _comConnectionStringsCollection ??= Properties.Settings.Default.ComConnectionStrings;
            set => _comConnectionStringsCollection = Properties.Settings.Default.ComConnectionStrings = value;
        }
        internal static StringCollection WEBLinksCollection
        {
            get => _webLinksCollection ??= Properties.Settings.Default.WebConnectionStrings;
            set => _webLinksCollection = Properties.Settings.Default.WebConnectionStrings = value;
        }
        internal static string COMConnectionString
        {
            get => _comConnectionString ??= Properties.Settings.Default.COMConnectionString;
            set => _comConnectionString = Properties.Settings.Default.COMConnectionString = value;
        }
        internal static string WEBLink
        {
            get => _webLink ??= Properties.Settings.Default.WEBLink;
            set => _webLink = Properties.Settings.Default.WEBLink = value;
        }
        internal static string UserName
        {
            get => _userName ??= Properties.Settings.Default.UserName;
            set => _userName = Properties.Settings.Default.UserName = value;
        }
        internal static string UserPassword
        {
            get => _userPassword ??= Properties.Settings.Default.UserPassword;
            set => _userPassword = Properties.Settings.Default.UserPassword = value;
        }
        internal static int CodeCol
        {
            get => _codeCol ??= Properties.Settings.Default.CodeCol;
            set => _codeCol = Properties.Settings.Default.CodeCol = value;
        }
        internal static int FIOCol
        {
            get => _fioCol ??= Properties.Settings.Default.FIOCol;
            set => _fioCol = Properties.Settings.Default.FIOCol = value;
        }
        internal static int AppearCol
        {
            get => _appearCol ??= Properties.Settings.Default.AppearCol;
            set => _appearCol = Properties.Settings.Default.AppearCol = value;
        }
        internal static int NightCol
        {
            get => _nightCol ??= Properties.Settings.Default.NightCol;
            set => _nightCol = Properties.Settings.Default.NightCol = value;
        }
        internal static int FeastCol
        {
            get => _feastCol ??= Properties.Settings.Default.FeastCol;
            set => _feastCol = Properties.Settings.Default.FeastCol = value;
        }
        internal static int FirstRow
        {
            get => _firstRow ??= Properties.Settings.Default.FirstRow;
            set => _firstRow = Properties.Settings.Default.FirstRow = value;
        }
        internal static int LastRow
        {
            get => _lastRow ??= Properties.Settings.Default.LastRow;
            set => _lastRow = Properties.Settings.Default.LastRow = value;
        }
        internal static DateTime FirstDate
        {
            get => _firstDate ??= Properties.Settings.Default.FirstDate;
            set => _firstDate = Properties.Settings.Default.FirstDate = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
        }
        internal static DateTime LastDate
        {
            get => _lastDate ??= Properties.Settings.Default.LastDate;
            set => _lastDate = Properties.Settings.Default.LastDate = new DateTime(value.Year, value.Month, value.Day, 23, 59, 59);
        }
        internal static bool Preload
        {
            get => _preload ??= Properties.Settings.Default.Preload;
            set => _preload = Properties.Settings.Default.Preload = value;
        }
        internal static ConnectionType ConnectionType
        {
            get => _onnectionType ??= Properties.Settings.Default.ConnectionType.ToConnectionType();
            set => Properties.Settings.Default.ConnectionType = (int)(_onnectionType = value);
        }

        internal static void SaveChanges()
        {
            Properties.Settings.Default.Save();
        }
    }
}
