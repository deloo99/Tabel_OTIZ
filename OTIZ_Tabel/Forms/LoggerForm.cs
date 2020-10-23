using System;
using System.Drawing;
using System.Windows.Forms;

namespace OTIZ_Tabel
{
    internal partial class LoggerForm : Form
    {
        internal LoggerForm()
        {
            InitializeComponent();
            ShowInvisible();
        }

        internal bool IsClosed { get; private set; }
        internal void LogText(string text, Color color, FontStyle fontStyle)
        { try { Invoke(new Action(() => { RTBoxLog.AppendText(text, color, fontStyle); })); } catch { } }
        internal void Complete()
        { try { this?.Invoke(new Action(() => { TaskComplete(); })); } catch { } }

        private void TaskComplete()
        {
            BTReady.Enabled = true;
            BTReady.Text = "Готово";
            BTReady.Image = Properties.Resources.ok_16p;
            BTAbort.Visible = false;
            BTSaveLog.Visible = true;
        }
        private void ShowInvisible()
        {
            Opacity = 0;
            Show();
            Hide();
            Opacity = 1;
        }
        private void LoggerForm_FormClosing(object sender, FormClosingEventArgs e) => IsClosed = true;
        private void LoggerForm_Shown(object sender, EventArgs e) => IsClosed = false;
        private void BTReady_Click(object sender, EventArgs e) => Close();
        private void BTAbort_Click(object sender, EventArgs e) => Close();
        private void BTSaveLog_Click(object sender, EventArgs e)
        {
            try
            {
                using var saveDialog = new SaveFileDialog
                {
                    FileName = "ОТИЗ Табель (" + DateTime.Now.ToString("dd.MM.yyyy hh.mm.ss") + ")",
                    Filter = "Текст RTF(*.rtf)|*.rtf",
                    DefaultExt = "rtf"
                };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    RTBoxLog.SaveFile(saveDialog.FileName, RichTextBoxStreamType.RichText);
                    MessageBox.Show(this, $"Файл сохранен.", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Ошибка сохранения:\r\n{ex.Message}", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
