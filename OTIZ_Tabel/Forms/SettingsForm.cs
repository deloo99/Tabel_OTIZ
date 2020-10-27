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
                MainSettingTabs.TabPages.Remove(TConnectSetting);
                TestConnection.Visible = false;
            }
        }


        private Properties.Settings _settings = Properties.Settings.Default;
        private readonly Color _greenColor = Color.FromArgb(235, 241, 222);
        private readonly Color _pinkColor = Color.FromArgb(242, 220, 219);


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ComConnectionStrings.Items.AddRange(_settings.ComConnectionStrings.Cast<object>().ToArray());
            WebConnectionStrings.Items.AddRange(_settings.WebConnectionStrings.Cast<object>().ToArray());
            ComConnectionString.Text = _settings.ComConnectionString;
            WebConnectionString.Text = _settings.WebConnectionString;
            UserName.Text = _settings.UserName;
            UserPassword.Text = _settings.UserPassword;
            CodeCol.Text = _settings.CodeCol.ToString();
            FIOCol.Text = _settings.FIOCol.ToString();
            AppearCol.Text = _settings.AppearCol.ToString();
            NightCol.Text = _settings.NightCol.ToString();
            FeastCol.Text = _settings.FeastCol.ToString();
            FirstRow.Text = _settings.FirstRow.ToString();
            LastRow.Text = _settings.LastRow.ToString();
            FirstDate.Value = _settings.FirstDate;
            LastDate.Value = _settings.LastDate;
            Preload.Checked = _settings.Preload;
            ConnectionSettingsTabs.TabIndex = _settings.ConnectionType;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = textBox.Text.IsInt() ? _greenColor : _pinkColor;
        }

        //нижнее меню 
        private void BTTestConnection_Click(object sender, EventArgs e)
        {
            using var loggerForm = new LoggerForm();
            IConnector connector = ConnectionSettingsTabs.SelectedIndex switch
            {
                0 => new WEBConnector1C(),
                1 => new COMConnector1C(),
                _ => throw new NotImplementedException("Тип подключения не реализован."),
            };
            new Task(delegate () { connector.TestConnection(loggerForm); }).Start();
            loggerForm.ShowDialog();
        }
        private void BTSave_Click(object sender, EventArgs e)
        {
            foreach (var control in MainSettingTabs.TabPages[0].Controls)
                if (control is TextBox textBox && !textBox.Text.IsInt())
                {
                    MessageBox.Show(this, "Некоторые данные указаны не корректно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            _settings.ComConnectionStrings.Clear();
            _settings.ComConnectionStrings.AddRange(ComConnectionStrings.Items.Cast<string>().ToArray());
            _settings.WebConnectionStrings.Clear();
            _settings.ComConnectionStrings.AddRange(WebConnectionStrings.Items.Cast<string>().ToArray());
            _settings.ComConnectionString = ComConnectionString.Text;
            _settings.WebConnectionString = WebConnectionString.Text;
            _settings.UserName = UserName.Text;
            _settings.UserPassword = UserPassword.Text;
            _settings.CodeCol = CodeCol.Text.ToInt();
            _settings.FIOCol = FIOCol.Text.ToInt();
            _settings.AppearCol = AppearCol.Text.ToInt();
            _settings.NightCol = NightCol.Text.ToInt();
            _settings.FeastCol = FeastCol.Text.ToInt();
            _settings.FirstRow = FirstRow.Text.ToInt();
            _settings.LastRow = LastRow.Text.ToInt();
            _settings.FirstDate = FirstDate.Value;
            _settings.LastDate = LastDate.Value;
            _settings.Preload = Preload.Checked;
            _settings.ConnectionType = ConnectionSettingsTabs.SelectedIndex;
            _settings.Save();

            Close();
        }
        private void BTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //вкладка настроек COM подключения
        private void AddComConnectionString_Click(object sender, EventArgs e)
        {
            if (!ComConnectionStrings.Items.Contains(ComConnectionString.Text))
                ComConnectionStrings.Items.Add(ComConnectionString.Text);
        }
        private void RemoveComConnectionString_Click(object sender, EventArgs e)
        {
            if (ComConnectionStrings.SelectedItem != null)
                if (MessageBox.Show(this, "Уверены что хотите удалить строку подключения?", "Предупреждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ComConnectionStrings.Items.Remove(ComConnectionStrings.SelectedItem);
                }
        }
        private void ComConnectionStrings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ComConnectionStrings.SelectedItem != null)
                ComConnectionString.Text = ComConnectionStrings.SelectedItem.ToString();
        }

        //вкладка настроек WEB подключения
        private void AddWebConnectionString_Click(object sender, EventArgs e)
        {
            if (!WebConnectionStrings.Items.Contains(WebConnectionString.Text))
                WebConnectionStrings.Items.Add(WebConnectionString.Text);
        }
        private void RemoveWebConnectionString_Click(object sender, EventArgs e)
        {
            if (WebConnectionStrings.SelectedItem != null)
                if (MessageBox.Show(this, "Уверены что хотите удалить ссылку на конфигурацию?", "Предупреждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    WebConnectionStrings.Items.Remove(WebConnectionStrings.SelectedItem);
                }
        }
        private void WebConnectionStrings_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WebConnectionStrings.SelectedItem != null)
                WebConnectionString.Text = WebConnectionStrings.SelectedItem.ToString();
        }
    }
}
