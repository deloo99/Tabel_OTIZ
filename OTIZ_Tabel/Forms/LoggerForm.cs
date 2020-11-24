using System;
using System.Drawing;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    public partial class LoggerForm : Form
    {
        public LoggerForm()
        {
            InitializeComponent();
            InvisibleShowAndHide();
        }

        public bool IsClosed { get; private set; }

        public void DefaultText(string message) => СustomText(message, Color.Black, FontStyle.Regular);
        public void DefaultBoldText(string message) => СustomText(message, Color.Black, FontStyle.Bold);
        public void GrayText(string message) => СustomText(message, Color.Gray, FontStyle.Regular);
        public void WarningText(string message) => СustomText(message, Color.Yellow, FontStyle.Bold);
        public void SuccessText(string message) => СustomText(message, Color.Green, FontStyle.Bold);
        public void ErrorText(string message) => СustomText(message, Color.Red, FontStyle.Bold);
        public void ExceptionText(Exception exception)
        {
            ErrorText(" ❌ ОШИБКА\r\n\r\n");
            DefaultText($"Сообщение об ошибке:\r\n{exception.Message}\r\n\r\n");
            GrayText($"Трасировка:\r\n{exception.StackTrace}\r\n");
        }
        public void СustomText(string text, Color color, FontStyle fontStyle)
        {
            if (!IsClosed) Invoke(new Action(() => { RTBoxLog.AppendText(text, color, fontStyle); }));
        }
        public void Complete()
        {
            if (!IsClosed) this?.Invoke(new Action(() => { TaskComplete(); }));
        }

        private void TaskComplete()
        {
            BTReady.Enabled = true;
            BTReady.Text = "Готово";
            BTReady.Image = Properties.Resources.ok_16p;
            BTAbort.Visible = false;
            BTSaveLog.Visible = true;
        }
        private void InvisibleShowAndHide()
        {
            Opacity = 0;
            Show();
            Hide();
            Opacity = 1;
        }
        private void LoggerForm_FormClosing(object sender, FormClosingEventArgs e)
            => IsClosed = true;
        private void LoggerForm_Shown(object sender, EventArgs e)
            => IsClosed = false;
        private void BTReady_Click(object sender, EventArgs e)
            => Close();
        private void BTAbort_Click(object sender, EventArgs e)
            => Close();
        private void BTSaveLog_Click(object sender, EventArgs e)
        {
            try
            {
                using var saveDialog = new SaveFileDialog
                {
                    FileName = $"Табель ОТИЗ ({DateTime.Now:dd.MM.yyyy hh.mm.ss})",
                    Filter = "Текст RTF(*.rtf)|*.rtf",
                    DefaultExt = "rtf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    RTBoxLog.SaveFile(saveDialog.FileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show(this, "Файл сохранен.", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Ошибка сохранения:\r\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
