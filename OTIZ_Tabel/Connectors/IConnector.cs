namespace OTIZ_Tabel
{
    internal interface IConnector
    {
        public ConnectionStatusType ConnectionStatus { get; }
        public void Connection(LoggerForm logger);
        public void Disonnection();
        public void TestConnection(LoggerForm logger);
        public void SetWorkingHours(LoggerForm logger);
    }
}
