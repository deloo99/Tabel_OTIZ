using OTIZ_Tabel.Types;

namespace OTIZ_Tabel.Connectors
{
    internal abstract class BaseConnector
    {
        protected Properties.Settings Settings => Properties.Settings.Default;

        public virtual ConnectionStatus ConnectionStatus { get; protected set; }
        public virtual ConnectorType ConnectorType => ConnectorType.BaseConnector;

        public virtual void Connection() => ConnectionStatus = ConnectionStatus.Connected;
        public abstract void TestConnection(LoggerForm logger, string connectionString, string login, string password);
        public virtual void Disonnection() => ConnectionStatus = ConnectionStatus.Disconnected;
        public abstract void SetWorkingHours(LoggerForm logger);
    }
}
