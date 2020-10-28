using Microsoft.Office.Tools.Ribbon;
using OTIZ_Tabel.Connectors;
using OTIZ_Tabel.Types;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal partial class MainRibbon
    {
        internal BaseConnector Connector { get; set; }

        private void GetWorkedTime_Click(object sender, RibbonControlEventArgs e)
        {
            switch (Connector.ConnectionStatus)
            {
                case (ConnectionStatus.Connected):
                    using (var loggerForm = new LoggerForm())
                    {
                        new Task(delegate () { Connector.SetWorkingHours(loggerForm); }).Start();
                        loggerForm.ShowDialog();
                    }
                    break;
                case (ConnectionStatus.Disconnected):
                    ChangeConnectionState_Click(sender, e);
                    break;
                case (ConnectionStatus.Progress):
                    MessageBox.Show(null, "В настоящий момент устанавливается соединение.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
        private void Settings_Click(object sender, RibbonControlEventArgs e)
        {
            using var settingsForm = new SettingsForm(Connector.ConnectionStatus != ConnectionStatus.Disconnected);
            settingsForm.ShowDialog();
            UpdateConnectionType();
        }
        private void ChangeConnectionState_Click(object sender, RibbonControlEventArgs e)
        {
            switch (Connector.ConnectionStatus)
            {
                case ConnectionStatus.Disconnected:
                    new Task(() =>
                    {
                        using (var loggerForm = new LoggerForm())
                        {
                            Connector.Connection();
                            UpdateConnectionStatus(Connector.ConnectionStatus);
                            if (Connector.ConnectorType != ConnectorType.WebConnector)
                                loggerForm.ShowDialog();
                        };
                    }).Start();
                    UpdateConnectionStatus(ConnectionStatus.Progress);
                    return;
                case ConnectionStatus.Connected:
                    if (MessageBox.Show("Отключиться от сервера 1С?", "Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        Connector.Disonnection();
                    break;
            }
            UpdateConnectionStatus(Connector.ConnectionStatus);
        }
        private void UpdateConnectionStatus(ConnectionStatus connectionStatus)
        {
            ChangeConnectionState.Image = connectionStatus switch
            {
                ConnectionStatus.Disconnected => Properties.Resources.disconnect,
                ConnectionStatus.Progress => Properties.Resources.exchange,
                ConnectionStatus.Connected => Properties.Resources.connect,
                _ => null
            };
        }
        private void UpdateConnectionType()
        {
            Connector = Properties.Settings.Default.ConnectionType switch
            {
                0 => new WebConnector(),
                1 => new ComConnector(),
                _ => throw new System.NotImplementedException("Неизвестный тип подключения"),
            };
        }
    }
}
