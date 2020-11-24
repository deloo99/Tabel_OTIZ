namespace OTIZ_Tabel
{
    partial class LoggerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RTBoxLog = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTAbort = new System.Windows.Forms.Button();
            this.BTSaveLog = new System.Windows.Forms.Button();
            this.BTReady = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RTBoxLog
            // 
            this.RTBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTBoxLog.BackColor = System.Drawing.Color.White;
            this.RTBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTBoxLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTBoxLog.Location = new System.Drawing.Point(3, 3);
            this.RTBoxLog.Name = "RTBoxLog";
            this.RTBoxLog.ReadOnly = true;
            this.RTBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RTBoxLog.Size = new System.Drawing.Size(638, 304);
            this.RTBoxLog.TabIndex = 0;
            this.RTBoxLog.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.BTAbort);
            this.panel1.Controls.Add(this.BTSaveLog);
            this.panel1.Controls.Add(this.BTReady);
            this.panel1.Location = new System.Drawing.Point(0, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 32);
            this.panel1.TabIndex = 3;
            // 
            // BTAbort
            // 
            this.BTAbort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTAbort.Image = global::OTIZ_Tabel.Properties.Resources.cancel_16p;
            this.BTAbort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTAbort.Location = new System.Drawing.Point(437, 4);
            this.BTAbort.Name = "BTAbort";
            this.BTAbort.Size = new System.Drawing.Size(100, 24);
            this.BTAbort.TabIndex = 3;
            this.BTAbort.Text = "Прервать";
            this.BTAbort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTAbort.UseVisualStyleBackColor = true;
            this.BTAbort.Click += new System.EventHandler(this.BTAbort_Click);
            // 
            // BTSaveLog
            // 
            this.BTSaveLog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BTSaveLog.Image = global::OTIZ_Tabel.Properties.Resources.save_16p;
            this.BTSaveLog.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTSaveLog.Location = new System.Drawing.Point(5, 4);
            this.BTSaveLog.Name = "BTSaveLog";
            this.BTSaveLog.Size = new System.Drawing.Size(160, 24);
            this.BTSaveLog.TabIndex = 2;
            this.BTSaveLog.Text = "Сохранить лог";
            this.BTSaveLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTSaveLog.UseVisualStyleBackColor = true;
            this.BTSaveLog.Visible = false;
            this.BTSaveLog.Click += new System.EventHandler(this.BTSaveLog_Click);
            // 
            // BTReady
            // 
            this.BTReady.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTReady.Enabled = false;
            this.BTReady.Image = global::OTIZ_Tabel.Properties.Resources.refresh_16p;
            this.BTReady.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTReady.Location = new System.Drawing.Point(539, 4);
            this.BTReady.Name = "BTReady";
            this.BTReady.Size = new System.Drawing.Size(100, 24);
            this.BTReady.TabIndex = 1;
            this.BTReady.Text = "Выполняется";
            this.BTReady.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTReady.UseVisualStyleBackColor = true;
            this.BTReady.Click += new System.EventHandler(this.BTReady_Click);
            // 
            // LoggerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(643, 341);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RTBoxLog);
            this.MaximizeBox = false;
            this.Name = "LoggerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Работа с базой 1С";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoggerForm_FormClosing);
            this.Shown += new System.EventHandler(this.LoggerForm_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTSaveLog;
        private System.Windows.Forms.Button BTReady;
        private System.Windows.Forms.Button BTAbort;
        internal System.Windows.Forms.RichTextBox RTBoxLog;
    }
}