using OTIZ_Tabel.Types;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OTIZ_Tabel.Forms
{
    public partial class FieldSettingWidget : Form
    {
        private class UnselectableButton : Button
        {
            public UnselectableButton() : base()
            {
                SetStyle(ControlStyles.Selectable, false);
                UpdateStyles();
            }
        }


        public FieldSettingWidget()
        {
            InitializeComponent();
            UpdateSettings();
        }


        private UnselectableButton _actionButton;
        private int _selectColumn = 1;
        private int _selectRow = 1;

        public void UpdateSettings()
        {
            var settings = Properties.Settings.Default;

            CodeColPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowCode) > 0;
            FioColPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowFIO) > 0;
            NormalColPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowNormal) > 0;
            HolidayColPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowHoliday) > 0;
            NightColPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowNight) > 0;
            FirstRowPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowFirst) > 0;
            LastRowPanel.Visible = (settings.WidgetParams & (int)WidgetParams.ShowLast) > 0;

            CodeColLabel.Text = GetExcelColName(settings.CodeCol);
            FioColLabel.Text = GetExcelColName(settings.FioCol);
            NormalColLabel.Text = GetExcelColName(settings.NormalCol);
            HolidayColLabel.Text = GetExcelColName(settings.HolidayCol);
            NightColLabel.Text = GetExcelColName(settings.NightCol);
            FirstRowLabel.Text = settings.FirstRow.ToString();
            LastRowLabel.Text = settings.LastRow.ToString();
        }


        private void Expand_Click(object sender, EventArgs e)
        {
            Expand.Image = (SettingsPanel.Visible = !SettingsPanel.Visible)
                ? Properties.Resources.minus16
                : Properties.Resources.plus16;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Exit_MouseEnter(object sender, EventArgs e)
        {
            Exit.BackColor = Color.Gold;
        }
        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            Exit.BackColor = BackColor;
        }
        private void FormMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Control control) control.Capture = false;
            Message m = Message.Create(Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }
        private void FieldSettingWidget_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0, Width - 1, Height - 1);
        }
        private void FieldSettingWidget_Load(object sender, EventArgs e)
        {
            timer1.Start();

            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            worksheet.SelectionChange += Worksheet_SelectionChange;
        }
        private void FieldSettingWidget_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
            worksheet.SelectionChange -= Worksheet_SelectionChange;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_actionButton != null || (RectangleToScreen(ClientRectangle).Contains(Cursor.Position) && Opacity < 1.0D))
            {
                Opacity += 0.1D;
            }
            else if (!RectangleToScreen(ClientRectangle).Contains(Cursor.Position) && Opacity > 0.8D)
            {
                Opacity -= 0.1D;
            }
        }
        private void ChangeParametr_Click(object sender, EventArgs e)
        {
            if (sender is UnselectableButton button)
            {
                if (_actionButton != null)
                {
                    _actionButton.BackColor = BackColor;
                }

                if (_actionButton != button)
                {
                    _actionButton = button;
                    _actionButton.BackColor = Color.YellowGreen;
                    SetSelectValue();
                }
                else
                {
                    _actionButton = null;
                    return;
                }
            }
        }
        private void Worksheet_SelectionChange(Microsoft.Office.Interop.Excel.Range Target)
        {
            _selectColumn = Target.Cells.Column;
            _selectRow = Target.Cells.Row;
            SetSelectValue();
        }

        private void SetSelectValue()
        {
            if (_actionButton != null)
            {
                var name = _actionButton.Name.Substring(6);
                var label = _actionButton.Parent.Controls.Find(name + "Label", false).First();

                if (_actionButton.Name.Contains("Col"))
                {
                    label.Text = GetExcelColName(_selectColumn);
                    Properties.Settings.Default.GetType().GetProperty(name).SetValue(Properties.Settings.Default, _selectColumn, null);
                }
                else if (_actionButton.Name.Contains("Row"))
                {
                    label.Text = _selectRow.ToString();
                    Properties.Settings.Default.GetType().GetProperty(name).SetValue(Properties.Settings.Default, _selectRow, null);
                }
            }
        }
        private string GetExcelColName(int num)
        {
            var val = num - 1;
            string rowName = null;
            while (val > 0)
            {
                rowName += (char)('A' + (val % 26));
                val /= 26;
            }

            return $"{num} ({rowName ?? "A"})";
        }
    }
}
