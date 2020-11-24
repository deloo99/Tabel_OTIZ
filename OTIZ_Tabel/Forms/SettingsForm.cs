using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OTIZ_Tabel.Types;

namespace OTIZ_Tabel
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(bool hideConnectSetting = false)
        {
            InitializeComponent();
            if (hideConnectSetting)
            {
                MainSettingTabs.TabPages.Remove(TConnectSetting);
                TestConnection.Visible = false;
            }
        }


        private readonly Properties.Settings Settings = Properties.Settings.Default;
        private readonly Color _greenColor = Color.FromArgb(235, 241, 222);
        private readonly Color _pinkColor = Color.FromArgb(242, 220, 219);


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            //methods
            static void SetValueForTextBox(string[] values, params TextBox[] textBoxes)
                => Enumerable.Range(0, Math.Min(textBoxes.Length, values.Length)).ToList()
                    .ForEach(x => textBoxes[x].Text = values[x] != "0" ? values[x] : "");

            //body
            ComConnectionStrings.Items.AddRange(Settings.ComConnectionStrings.Cast<object>().ToArray());
            WebConnectionStrings.Items.AddRange(Settings.WebConnectionStrings.Cast<object>().ToArray());
            ComConnectionString.Text = Settings.ComConnectionString;
            WebConnectionString.Text = Settings.WebConnectionString;
            UserName.Text = Settings.UserName;
            UserPassword.Text = Settings.UserPassword;
            CodeCol.Text = Settings.CodeCol.ToString();
            FIOCol.Text = Settings.FioCol.ToString();
            NormalCol.Text = Settings.NormalCol.ToString();
            NightCol.Text = Settings.NightCol.ToString();
            HolidayCol.Text = Settings.HolidayCol.ToString();
            FirstRow.Text = Settings.FirstRow.ToString();
            LastRow.Text = Settings.LastRow.ToString();
            FirstDate.Value = Settings.FirstDate;
            LastDate.Value = Settings.LastDate;
            Preload.Checked = Settings.Preload;
            ConnectionSettingsTabs.SelectedIndex = Settings.ConnectionType;

            ShowLast.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowLast) > 0;
            ShowFirst.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowFirst) > 0;
            ShowFIO.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowFIO) > 0;
            ShowCode.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowCode) > 0;
            ShowHoliday.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowHoliday) > 0;
            ShowNight.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowNight) > 0;
            ShowNormal.Checked = (Settings.WidgetParams & (int)WidgetParams.ShowNormal) > 0;

            WAMainDirectoryPath.Text = Settings.WAMainDirectoryPath;
            WAExcelFileName.Text = Settings.WAExcelFileName;
            SetValueForTextBox(Settings.WeldedAssembliesSetting.Split(' '), WAOrder1, WAMark1, WAGroup1, WANorma1,
                WAOrder2, WAMark2, WAGroup2, WANorma2, WAOrder3, WAMark3, WAGroup3, WANorma3);

            LIPMainDirectoryPath.Text = Settings.LIPMainDirectoryPath;
            LIPExcelFileName.Text = Settings.LIPExcelFileName;
            SetValueForTextBox(Settings.LaborIntensityOfProductsSetting.Split(' '), LIPOrder1, LIPMark1, LIPHoursRate1,
                LIPHoursRateWithoutWelds1, LIPOrder2, LIPMark2, LIPHoursRate2, LIPHoursRateWithoutWelds2);
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
                textBox.BackColor = textBox.Text.IsInt() ? _greenColor : _pinkColor;
        }

        //нижнее меню 
        private void TestConnection_Click(object sender, EventArgs e)
        {
            using var loggerForm = new LoggerForm();

            switch (ConnectionSettingsTabs.SelectedIndex)
            {
                case 0:
                    new Task(delegate () { new WebConnector().TestConnection(loggerForm, WebConnectionString.Text, UserName.Text, UserPassword.Text); }).Start();
                    break;
                case 1:
                    new Task(delegate () { new ComConnector().TestConnection(loggerForm, ComConnectionString.Text, UserName.Text, UserPassword.Text); }).Start();
                    break;
            }
            loggerForm.ShowDialog();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            foreach (var control in MainSettingTabs.TabPages[0].Controls)
                if (control is TextBox textBox && !textBox.Text.IsInt())
                {
                    MessageBox.Show(this, "Некоторые данные указаны не корректно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            Settings.ComConnectionStrings.Clear();
            Settings.ComConnectionStrings.AddRange(ComConnectionStrings.Items.Cast<string>().ToArray());
            Settings.WebConnectionStrings.Clear();
            Settings.WebConnectionStrings.AddRange(WebConnectionStrings.Items.Cast<string>().ToArray());
            Settings.ComConnectionString = ComConnectionString.Text;
            Settings.WebConnectionString = WebConnectionString.Text;
            Settings.UserName = UserName.Text;
            Settings.UserPassword = UserPassword.Text;
            Settings.CodeCol = CodeCol.Text.ToInt();
            Settings.FioCol = FIOCol.Text.ToInt();
            Settings.NormalCol = NormalCol.Text.ToInt();
            Settings.NightCol = NightCol.Text.ToInt();
            Settings.HolidayCol = HolidayCol.Text.ToInt();
            Settings.FirstRow = FirstRow.Text.ToInt();
            Settings.LastRow = LastRow.Text.ToInt();
            Settings.FirstDate = FirstDate.Value;
            Settings.LastDate = LastDate.Value;
            Settings.Preload = Preload.Checked;
            Settings.ConnectionType = ConnectionSettingsTabs.SelectedIndex;

            Settings.WidgetParams = (ShowLast.Checked ? (int)WidgetParams.ShowLast : 0)
                | (ShowFirst.Checked ? (int)WidgetParams.ShowFirst : 0)
                | (ShowFIO.Checked ? (int)WidgetParams.ShowFIO : 0)
                | (ShowCode.Checked ? (int)WidgetParams.ShowCode : 0)
                | (ShowHoliday.Checked ? (int)WidgetParams.ShowHoliday : 0)
                | (ShowNight.Checked ? (int)WidgetParams.ShowNight : 0)
                | (ShowNormal.Checked ? (int)WidgetParams.ShowNormal : 0);


            Settings.WAMainDirectoryPath = WAMainDirectoryPath.Text;
            Settings.WAExcelFileName = WAExcelFileName.Text;
            Settings.WeldedAssembliesSetting = string.Join(" ", new int[] {
               WAOrder1.Text.ToInt(), WAMark1.Text.ToInt(), WAGroup1.Text.ToInt(), WANorma1.Text.ToInt(),
               WAOrder2.Text.ToInt(), WAMark2.Text.ToInt(), WAGroup2.Text.ToInt(), WANorma2.Text.ToInt(),
               WAOrder3.Text.ToInt(), WAMark3.Text.ToInt(), WAGroup3.Text.ToInt(), WANorma3.Text.ToInt(),
            }.Select(x => Math.Abs(x)));

            Settings.LIPMainDirectoryPath = LIPMainDirectoryPath.Text;
            Settings.LIPExcelFileName = LIPExcelFileName.Text;
            Settings.LaborIntensityOfProductsSetting = string.Join(" ", new int[] {
               LIPOrder1.Text.ToInt(), LIPMark1.Text.ToInt(), LIPHoursRate1.Text.ToInt(), LIPHoursRateWithoutWelds1.Text.ToInt(),
               LIPOrder2.Text.ToInt(), LIPMark2.Text.ToInt(), LIPHoursRate2.Text.ToInt(), LIPHoursRateWithoutWelds2.Text.ToInt(),
            }.Select(x => Math.Abs(x)));

            Settings.Save();
            Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
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

        private void MainSettingTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestConnection.Visible = MainSettingTabs.SelectedIndex == 0 || MainSettingTabs.SelectedIndex == 1;
        }
    }
}
