using Microsoft.Office.Tools.Ribbon;
using OTIZ_Tabel.Classes;
using OTIZ_Tabel.Connectors;
using OTIZ_Tabel.Forms;
using OTIZ_Tabel.Types;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal partial class MainRibbon
    {
        private BaseConnector _connector;
        private FieldSettingWidget _widget;

        private void GetWorkedTime_Click(object sender, RibbonControlEventArgs e)
        {
            switch (_connector.ConnectionStatus)
            {
                case (ConnectionStatus.Connected):
                    using (var loggerForm = new LoggerForm())
                    {
                        new Task(delegate () { _connector.SetWorkingHours(loggerForm); }).Start();
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
            using var settingsForm = new SettingsForm(_connector.ConnectionStatus != ConnectionStatus.Disconnected);
            settingsForm.ShowDialog();
            UpdateConnectionType();
            _widget?.UpdateSettings();
        }
        private void ChangeConnectionState_Click(object sender, RibbonControlEventArgs e)
        {
            switch (_connector.ConnectionStatus)
            {
                case ConnectionStatus.Disconnected:
                    new Task(() =>
                    {
                        using (var loggerForm = new LoggerForm())
                        {
                            _connector.Connection();
                            UpdateConnectionStatus(_connector.ConnectionStatus);
                            if (_connector.ConnectorType != ConnectorType.WebConnector)
                                loggerForm.ShowDialog();
                        };
                    }).Start();
                    UpdateConnectionStatus(ConnectionStatus.Progress);
                    return;
                case ConnectionStatus.Connected:
                    if (MessageBox.Show("Отключиться от сервера 1С?", "Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        _connector.Disonnection();
                    break;
            }
            UpdateConnectionStatus(_connector.ConnectionStatus);
        }
        private void OpenWidget_Click(object sender, RibbonControlEventArgs e)
        {
            if (_widget == null || _widget.IsDisposed)
                _widget = new FieldSettingWidget();

            _widget.Show();
        }
        private void WeldedAssemblies_Click(object sender, RibbonControlEventArgs e)
        {
            using var loggerForm = new LoggerForm
            {
                Text = "Работа со сварными узлами"
            };
            new Task(delegate () { LaborIntensityUpdater.SetWeldedAssembliesList(loggerForm); }).Start();
            loggerForm.ShowDialog();
        }
        private void LaborIntensityOfProducts_Click(object sender, RibbonControlEventArgs e)
        {
            using var loggerForm = new LoggerForm
            {
                Text = "Работа с трудоемкостю изделий"
            };
            new Task(delegate () { LaborIntensityUpdater.SetLaborIntensityOfProducts(loggerForm); }).Start();
            loggerForm.ShowDialog();
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
            _connector = (ConnectorType)Properties.Settings.Default.ConnectionType switch
            {
                ConnectorType.WebConnector => new WebConnector(),
                ConnectorType.ComConnector => new ComConnector(),
                _ => throw new System.NotImplementedException("Неизвестный тип подключения"),
            };
        }

    }
}
