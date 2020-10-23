namespace OTIZ_Tabel
{
    internal interface IConnector1C
    {
        public ConnectionStatusType ConnectionStatus { get; }
        public void Connection(LoggerForm logger, ConnectData conDate);
        public void Disonnection();
        public void TestConnection(LoggerForm logger, ConnectData conDate);
        public void SetWorkingHours(LoggerForm logger);
    }
}
