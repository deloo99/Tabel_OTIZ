using Microsoft.Office.Tools.Ribbon;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal partial class MainRibbon
    {
        private readonly COMConnector1C _comEntity1C = new COMConnector1C();
        private readonly WEBConnector1C _webEntity1C = new WEBConnector1C();
        internal IConnector1C Entity1C;

        private void BTSetWorkingHours_Click(object sender, RibbonControlEventArgs e)
        {
            if (Entity1C.ConnectionStatus == ConnectionStatusType.Connected)
            {
                using var loggerForm = new LoggerForm();
                new Task(delegate () { Entity1C.SetWorkingHours(loggerForm); }).Start();
                loggerForm.ShowDialog();
            }
            else
            {
                BTChangeConnection_Click(sender, e);
                //   MessageBox.Show(null, "Сначала установите соединения с базой 1С", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BTSettings_Click(object sender, RibbonControlEventArgs e)
        {
            using var settingsForm = new SettingsForm(Entity1C.ConnectionStatus != ConnectionStatusType.Disconnected);
            settingsForm.ShowDialog();
            CheckEntity1C();
        }
        private void BTChangeConnection_Click(object sender, RibbonControlEventArgs e)
        {
            switch (Entity1C.ConnectionStatus)
            {
                case ConnectionStatusType.Disconnected:
                    new Task(() =>
                    {
                        using (var loggerForm = new LoggerForm())
                        {
                            Entity1C.Connection(loggerForm, new ConnectData());
                            CheckConnectionStatus(Entity1C.ConnectionStatus);
                            loggerForm.ShowDialog();
                        };
                    }).Start();
                    CheckConnectionStatus(ConnectionStatusType.Progress);
                    return;
                case ConnectionStatusType.Connected:
                    if (MessageBox.Show("Вы уверены что хотите разорвать соединение с сервером 1С?", "Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        Entity1C.Disonnection();
                    break;
            }
            CheckConnectionStatus(Entity1C.ConnectionStatus);
        }
        private void CheckConnectionStatus(ConnectionStatusType connectionStatus)
        {
            BTChangeConnection.Image = connectionStatus switch
            {
                ConnectionStatusType.Disconnected => Properties.Resources.disconnect,
                ConnectionStatusType.Progress => Properties.Resources.exchange,
                ConnectionStatusType.Connected => Properties.Resources.connect,
                _ => null
            };
        }
        private void CheckEntity1C()
        {
            Entity1C = Settings.ConnectionType switch
            {
                ConnectionType.WEBService => _webEntity1C,
                _ => _comEntity1C,
            };
        }
    }
}
