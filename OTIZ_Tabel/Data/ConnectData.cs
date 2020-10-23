namespace OTIZ_Tabel
{
    internal class ConnectData
    {
        internal string COMConnectString => $"{ConnectString}Usr=\"{UserName}\";Pwd =\"{UserPassword}\"";
        internal string ConnectString { get; set; } = Settings.COMConnectionString;
        internal string WEBLink { get; set; } = Settings.WEBLink;
        internal string UserName { get; set; } = Settings.UserName;
        internal string UserPassword { get; set; } = Settings.UserPassword;
    }
}
