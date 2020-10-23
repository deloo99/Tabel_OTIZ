using System;
using System.Drawing;
using System.Linq;
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
                ConnectString = ComConnectionString.Text,
                WEBLink = WebConnectionString.Text,
                UserName = UserName.Text,
                UserPassword = UserPassword.Text,
            };
        private IConnector1C NewConnector1C
            => SettingsTabControl.SelectedIndex.ToConnectionType() switch
            {
                ConnectionType.WEBService => new WEBConnector1C(),
                _ => new COMConnector1C(),
            };

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;

            ComConnectionStrings.Items.AddRange(settings.ComConnectionStrings.Cast<object>().ToArray());
            WebConnectionStrings.Items.AddRange(settings.WebConnectionStrings.Cast<object>().ToArray());
            ComConnectionString.Text = settings.COMConnectionString;
            WebConnectionString.Text = settings.WEBLink;
            UserName.Text = settings.UserName;
            UserPassword.Text = settings.UserPassword;
            CodeCol.Text = settings.CodeCol;
            FIOCol.Text = settings.FIOCol;
            AppearCol.Text = settings.AppearCol;
            NightCol.Text = settings.NightCol;
            FeastCol.Text = settings.FeastCol;
            FirstRow.Text = settings.FirstRow;
            LastRow.Text = settings.LastRow;
            FirstDate.Value = settings.FirstDate;
            LastDate.Value = settings.LastDate;
            Preload.Checked = settings.Preload;
            SettingsTabControl.SelectedTab = settings.ConnectionType = 0 ? WebSettingsTab : ComSettingsTab;
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

            var settings = settings;


            settings.ComConnectionStrings.Clear();
            foreach (var item in ComConnectionStrings.Items)
                settings.ComConnectionStrings.Add(item.ToString());
            settings.WebConnectionStrings.Clear();
            foreach (var item in WebConnectionStrings.Items)
                settings.WebConnectionStrings.Add(item.ToString());
            settings.COMConnectionString = ComConnectionString.Text;
            settings.WEBLink = WebConnectionString.Text;
            settings.UserName = UserName.Text;
            settings.UserPassword = UserPassword.Text;
            settings.CodeCol = CodeCol.Text;
            settings.FIOCol = FIOCol.Text;
            settings.AppearCol = AppearCol.Text;
            settings.NightCol = NightCol.Text;
            settings.FeastCol = FeastCol.Text;
            settings.FirstRow = FirstRow.Text;
            settings.LastRow = LastRow.Text;
            settings.FirstDate = FirstDate.Value;
            settings.LastDate = LastDate.Value;
            settings.Preload = Preload.Checked;
            settings.ConnectionType = (int)SettingsTabControl.SelectedIndex.ToConnectionType();
            settings.Save();
            Close();

        }
        private void BTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTCOMAddConnectionString_Click(object sender, EventArgs e)
        {
            if (!ComConnectionStrings.Items.Contains(ComConnectionString.Text))
                ComConnectionStrings.Items.Add(ComConnectionString.Text);
        }
        private void BTCOMRemoveConnectionString_Click(object sender, EventArgs e)
        {
            if (ComConnectionStrings.SelectedItem != null)
                if (MessageBox.Show(this, "Уверены что хотите удалить строку подключения?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    ComConnectionStrings.Items.Remove(ComConnectionStrings.SelectedItem);
        }
        private void LBoxCOMConnectionStrings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ComConnectionStrings.SelectedItem != null)
                ComConnectionString.Text = ComConnectionStrings.SelectedItem.ToString();
        }
        private void BTWEBAddLink_Click(object sender, EventArgs e)
        {
            if (!WebConnectionStrings.Items.Contains(WebConnectionString.Text))
                WebConnectionStrings.Items.Add(WebConnectionString.Text);
        }
        private void BTWEBRemoveLink_Click(object sender, EventArgs e)
        {
            if (WebConnectionStrings.SelectedItem != null)
                if (MessageBox.Show(this, "Уверены что хотите удалить ссылку на конфигурацию?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    WebConnectionStrings.Items.Remove(WebConnectionStrings.SelectedItem);
        }
        private void LBoxWEBLinks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WebConnectionStrings.SelectedItem != null)
                WebConnectionString.Text = WebConnectionStrings.SelectedItem.ToString();
        }
    }
}
