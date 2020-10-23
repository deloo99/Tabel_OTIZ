using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal partial class SettingsForm : Form
    {
        internal SettingsForm(bool hideConnectSetting = false)
        {
            InitializeComponent();
            if (hideConnectSetting)
            {
                TCSettings.TabPages.Remove(TConnectSetting);
                BTTestConnection.Visible = false;
            }
        }

        private readonly Color _greenColor = Color.FromArgb(235, 241, 222);
        private readonly Color _pinkColor = Color.FromArgb(242, 220, 219);
        private ConnectData NewConnectData
            => new ConnectData
            {
                ConnectString = TBoxCOMConnectionString.Text,
                WEBLink = TBoxWEBLink.Text,
                UserName = TBoxUserName.Text,
                UserPassword = TBoxUserPassword.Text,
            };
        private IConnector1C NewConnector1C
            => TCConnectionSettings.SelectedIndex.ToConnectionType() switch
            {
                ConnectionType.WEBService => new WEBConnector1C(),
                _ => new COMConnector1C(),
            };

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LBoxCOMConnectionStrings.Items.Clear();
            foreach (var item in Settings.COMConnectionStringsCollection)
                LBoxCOMConnectionStrings.Items.Add(item);
            LBoxWEBLinks.Items.Clear();
            foreach (var item in Settings.WEBLinksCollection)
                LBoxWEBLinks.Items.Add(item);
            TBoxCOMConnectionString.Text = Settings.COMConnectionString;
            TBoxWEBLink.Text = Settings.WEBLink;
            TBoxUserName.Text = Settings.UserName;
            TBoxUserPassword.Text = Settings.UserPassword;
            TBoxCodeCol.Text = Settings.CodeCol.ToString();
            TBoxFIOCol.Text = Settings.FIOCol.ToString();
            TBoxAppearCol.Text = Settings.AppearCol.ToString();
            TBoxNightCol.Text = Settings.NightCol.ToString();
            TBoxFeastCol.Text = Settings.FeastCol.ToString();
            TBoxFirstRow.Text = Settings.FirstRow.ToString();
            TBoxLastRow.Text = Settings.LastRow.ToString();
            DTimeFirstDate.Value = Settings.FirstDate;
            DTimeLastDate.Value = Settings.LastDate;
            CBoxPreload.Checked = Settings.Preload;
            TCConnectionSettings.SelectedTab = Settings.ConnectionType switch
            {
                ConnectionType.COMPort => TPCOMSetting,
                ConnectionType.WEBService => TPWEBSetting,
                _ => TCConnectionSettings.SelectedTab
            };
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = textBox.Text.IsInt() ? _greenColor : _pinkColor;
        }
        private void BTTestConnection_Click(object sender, EventArgs e)
        {
            using var loggerForm = new LoggerForm();
            var connector = NewConnector1C;
            var conData = NewConnectData;
            new Task(delegate () { connector.TestConnection(loggerForm, conData); }).Start();
            loggerForm.ShowDialog();
        }
        private void BTSave_Click(object sender, EventArgs e)
        {
            foreach (var control in TCSettings.TabPages[0].Controls)
                if (control is TextBox textBox && textBox.BackColor == Color.LightPink)
                    if (DialogResult.Yes != MessageBox.Show(this, "Некоторые данные указаны не корректно.\r\nПродолжить сохраниени?"
                        , "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
                        return;
                    else
                        break;

            Settings.COMConnectionStringsCollection.Clear();
            foreach (var item in LBoxCOMConnectionStrings.Items)
                Settings.COMConnectionStringsCollection.Add(item.ToString());
            Settings.WEBLinksCollection.Clear();
            foreach (var item in LBoxWEBLinks.Items)
                Settings.WEBLinksCollection.Add(item.ToString());
            Settings.COMConnectionString = TBoxCOMConnectionString.Text;
            Settings.WEBLink = TBoxWEBLink.Text;
            Settings.UserName = TBoxUserName.Text;
            Settings.UserPassword = TBoxUserPassword.Text;
            Settings.CodeCol = TBoxCodeCol.Text.ToInt();
            Settings.FIOCol = TBoxFIOCol.Text.ToInt();
            Settings.AppearCol = TBoxAppearCol.Text.ToInt();
            Settings.NightCol = TBoxNightCol.Text.ToInt();
            Settings.FeastCol = TBoxFeastCol.Text.ToInt();
            Settings.FirstRow = TBoxFirstRow.Text.ToInt();
            Settings.LastRow = TBoxLastRow.Text.ToInt();
            Settings.FirstDate = DTimeFirstDate.Value;
            Settings.LastDate = DTimeLastDate.Value;
            Settings.Preload = CBoxPreload.Checked;
            Settings.ConnectionType = TCConnectionSettings.SelectedIndex.ToConnectionType();
            Settings.SaveChanges();
            Close();
        }
        private void BTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTCOMAddConnectionString_Click(object sender, EventArgs e)
        {
            if (!LBoxCOMConnectionStrings.Items.Contains(TBoxCOMConnectionString.Text))
                LBoxCOMConnectionStrings.Items.Add(TBoxCOMConnectionString.Text);
        }
        private void BTCOMRemoveConnectionString_Click(object sender, EventArgs e)
        {
            if (LBoxCOMConnectionStrings.SelectedItem != null)
                if (MessageBox.Show(this, "Уверены что хотите удалить строку подключения?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    LBoxCOMConnectionStrings.Items.Remove(LBoxCOMConnectionStrings.SelectedItem);
        }
        private void LBoxCOMConnectionStrings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LBoxCOMConnectionStrings.SelectedItem != null)
                TBoxCOMConnectionString.Text = LBoxCOMConnectionStrings.SelectedItem.ToString();
        }
        private void BTWEBAddLink_Click(object sender, EventArgs e)
        {
            if (!LBoxWEBLinks.Items.Contains(TBoxWEBLink.Text))
                LBoxWEBLinks.Items.Add(TBoxWEBLink.Text);
        }
        private void BTWEBRemoveLink_Click(object sender, EventArgs e)
        {
            if (LBoxWEBLinks.SelectedItem != null)
                if (MessageBox.Show(this, "Уверены что хотите удалить ссылку на конфигурацию?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    LBoxWEBLinks.Items.Remove(LBoxWEBLinks.SelectedItem);
        }
        private void LBoxWEBLinks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LBoxWEBLinks.SelectedItem != null)
                TBoxWEBLink.Text = LBoxWEBLinks.SelectedItem.ToString();
        }
    }
}
