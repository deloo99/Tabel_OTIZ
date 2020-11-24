namespace OTIZ_Tabel.Forms
{
    partial class FieldSettingWidget
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
            this.components = new System.ComponentModel.Container();
            this.HolidayColPanel = new System.Windows.Forms.Panel();
            this.ChangeHolidayCol = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.label10 = new System.Windows.Forms.Label();
            this.HolidayColLabel = new System.Windows.Forms.Label();
            this.NightColPanel = new System.Windows.Forms.Panel();
            this.ChangeNightCol = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.NightColLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NormalColPanel = new System.Windows.Forms.Panel();
            this.ChangeNormalCol = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.label6 = new System.Windows.Forms.Label();
            this.NormalColLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CodeColLabel = new System.Windows.Forms.Label();
            this.FioColLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LastRowLabel = new System.Windows.Forms.Label();
            this.FirstRowLabel = new System.Windows.Forms.Label();
            this.CodeColPanel = new System.Windows.Forms.Panel();
            this.ChangeCodeCol = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.FioColPanel = new System.Windows.Forms.Panel();
            this.ChangeFioCol = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.FirstRowPanel = new System.Windows.Forms.Panel();
            this.ChangeFirstRow = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.LastRowPanel = new System.Windows.Forms.Panel();
            this.ChangeLastRow = new OTIZ_Tabel.Forms.FieldSettingWidget.UnselectableButton();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Expand = new System.Windows.Forms.PictureBox();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.HolidayColPanel.SuspendLayout();
            this.NightColPanel.SuspendLayout();
            this.NormalColPanel.SuspendLayout();
            this.CodeColPanel.SuspendLayout();
            this.FioColPanel.SuspendLayout();
            this.FirstRowPanel.SuspendLayout();
            this.LastRowPanel.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // HolidayColPanel
            // 
            this.HolidayColPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(220)))), ((int)(((byte)(219)))));
            this.HolidayColPanel.Controls.Add(this.ChangeHolidayCol);
            this.HolidayColPanel.Controls.Add(this.label10);
            this.HolidayColPanel.Controls.Add(this.HolidayColLabel);
            this.HolidayColPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HolidayColPanel.Location = new System.Drawing.Point(0, 66);
            this.HolidayColPanel.Name = "HolidayColPanel";
            this.HolidayColPanel.Size = new System.Drawing.Size(198, 22);
            this.HolidayColPanel.TabIndex = 29;
            // 
            // ChangeHolidayCol
            // 
            this.ChangeHolidayCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeHolidayCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeHolidayCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeHolidayCol.Location = new System.Drawing.Point(78, 0);
            this.ChangeHolidayCol.Name = "ChangeHolidayCol";
            this.ChangeHolidayCol.Size = new System.Drawing.Size(63, 22);
            this.ChangeHolidayCol.TabIndex = 37;
            this.ChangeHolidayCol.Text = "Сменить";
            this.ChangeHolidayCol.UseVisualStyleBackColor = true;
            this.ChangeHolidayCol.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Праздники:";
            // 
            // HolidayColLabel
            // 
            this.HolidayColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HolidayColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HolidayColLabel.Location = new System.Drawing.Point(143, 3);
            this.HolidayColLabel.Name = "HolidayColLabel";
            this.HolidayColLabel.Size = new System.Drawing.Size(51, 15);
            this.HolidayColLabel.TabIndex = 36;
            this.HolidayColLabel.Text = "-";
            this.HolidayColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NightColPanel
            // 
            this.NightColPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(241)))));
            this.NightColPanel.Controls.Add(this.ChangeNightCol);
            this.NightColPanel.Controls.Add(this.NightColLabel);
            this.NightColPanel.Controls.Add(this.label7);
            this.NightColPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NightColPanel.Location = new System.Drawing.Point(0, 88);
            this.NightColPanel.Name = "NightColPanel";
            this.NightColPanel.Size = new System.Drawing.Size(198, 22);
            this.NightColPanel.TabIndex = 30;
            // 
            // ChangeNightCol
            // 
            this.ChangeNightCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeNightCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeNightCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeNightCol.Location = new System.Drawing.Point(78, 0);
            this.ChangeNightCol.Name = "ChangeNightCol";
            this.ChangeNightCol.Size = new System.Drawing.Size(63, 22);
            this.ChangeNightCol.TabIndex = 38;
            this.ChangeNightCol.Text = "Сменить";
            this.ChangeNightCol.UseVisualStyleBackColor = true;
            this.ChangeNightCol.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // NightColLabel
            // 
            this.NightColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NightColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NightColLabel.Location = new System.Drawing.Point(143, 3);
            this.NightColLabel.Name = "NightColLabel";
            this.NightColLabel.Size = new System.Drawing.Size(51, 15);
            this.NightColLabel.TabIndex = 37;
            this.NightColLabel.Text = "-";
            this.NightColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ночные:";
            // 
            // NormalColPanel
            // 
            this.NormalColPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.NormalColPanel.Controls.Add(this.ChangeNormalCol);
            this.NormalColPanel.Controls.Add(this.label6);
            this.NormalColPanel.Controls.Add(this.NormalColLabel);
            this.NormalColPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NormalColPanel.Location = new System.Drawing.Point(0, 44);
            this.NormalColPanel.Name = "NormalColPanel";
            this.NormalColPanel.Size = new System.Drawing.Size(198, 22);
            this.NormalColPanel.TabIndex = 28;
            // 
            // ChangeNormalCol
            // 
            this.ChangeNormalCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeNormalCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeNormalCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeNormalCol.Location = new System.Drawing.Point(78, 0);
            this.ChangeNormalCol.Name = "ChangeNormalCol";
            this.ChangeNormalCol.Size = new System.Drawing.Size(63, 22);
            this.ChangeNormalCol.TabIndex = 36;
            this.ChangeNormalCol.Text = "Сменить";
            this.ChangeNormalCol.UseVisualStyleBackColor = true;
            this.ChangeNormalCol.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Явки:";
            // 
            // NormalColLabel
            // 
            this.NormalColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NormalColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NormalColLabel.Location = new System.Drawing.Point(143, 3);
            this.NormalColLabel.Name = "NormalColLabel";
            this.NormalColLabel.Size = new System.Drawing.Size(51, 15);
            this.NormalColLabel.TabIndex = 35;
            this.NormalColLabel.Text = "-";
            this.NormalColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "ФИО:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Таб. номер:";
            // 
            // CodeColLabel
            // 
            this.CodeColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeColLabel.Location = new System.Drawing.Point(144, 2);
            this.CodeColLabel.Name = "CodeColLabel";
            this.CodeColLabel.Size = new System.Drawing.Size(51, 15);
            this.CodeColLabel.TabIndex = 31;
            this.CodeColLabel.Text = "-";
            this.CodeColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FioColLabel
            // 
            this.FioColLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FioColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FioColLabel.Location = new System.Drawing.Point(144, 2);
            this.FioColLabel.Name = "FioColLabel";
            this.FioColLabel.Size = new System.Drawing.Size(51, 15);
            this.FioColLabel.TabIndex = 32;
            this.FioColLabel.Text = "-";
            this.FioColLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Нач. строка:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Кон. строка:";
            // 
            // LastRowLabel
            // 
            this.LastRowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LastRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastRowLabel.Location = new System.Drawing.Point(144, 2);
            this.LastRowLabel.Name = "LastRowLabel";
            this.LastRowLabel.Size = new System.Drawing.Size(51, 15);
            this.LastRowLabel.TabIndex = 34;
            this.LastRowLabel.Text = "-";
            this.LastRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FirstRowLabel
            // 
            this.FirstRowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstRowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstRowLabel.Location = new System.Drawing.Point(144, 2);
            this.FirstRowLabel.Name = "FirstRowLabel";
            this.FirstRowLabel.Size = new System.Drawing.Size(51, 15);
            this.FirstRowLabel.TabIndex = 33;
            this.FirstRowLabel.Text = "-";
            this.FirstRowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CodeColPanel
            // 
            this.CodeColPanel.Controls.Add(this.ChangeCodeCol);
            this.CodeColPanel.Controls.Add(this.label4);
            this.CodeColPanel.Controls.Add(this.CodeColLabel);
            this.CodeColPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CodeColPanel.Location = new System.Drawing.Point(0, 0);
            this.CodeColPanel.Name = "CodeColPanel";
            this.CodeColPanel.Size = new System.Drawing.Size(198, 22);
            this.CodeColPanel.TabIndex = 35;
            // 
            // ChangeCodeCol
            // 
            this.ChangeCodeCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeCodeCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeCodeCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeCodeCol.Location = new System.Drawing.Point(78, 0);
            this.ChangeCodeCol.Name = "ChangeCodeCol";
            this.ChangeCodeCol.Size = new System.Drawing.Size(63, 22);
            this.ChangeCodeCol.TabIndex = 32;
            this.ChangeCodeCol.Text = "Сменить";
            this.ChangeCodeCol.UseVisualStyleBackColor = true;
            this.ChangeCodeCol.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // FioColPanel
            // 
            this.FioColPanel.Controls.Add(this.ChangeFioCol);
            this.FioColPanel.Controls.Add(this.label5);
            this.FioColPanel.Controls.Add(this.FioColLabel);
            this.FioColPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FioColPanel.Location = new System.Drawing.Point(0, 22);
            this.FioColPanel.Name = "FioColPanel";
            this.FioColPanel.Size = new System.Drawing.Size(198, 22);
            this.FioColPanel.TabIndex = 36;
            // 
            // ChangeFioCol
            // 
            this.ChangeFioCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeFioCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeFioCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeFioCol.Location = new System.Drawing.Point(78, 0);
            this.ChangeFioCol.Name = "ChangeFioCol";
            this.ChangeFioCol.Size = new System.Drawing.Size(63, 22);
            this.ChangeFioCol.TabIndex = 33;
            this.ChangeFioCol.Text = "Сменить";
            this.ChangeFioCol.UseVisualStyleBackColor = true;
            this.ChangeFioCol.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // FirstRowPanel
            // 
            this.FirstRowPanel.Controls.Add(this.ChangeFirstRow);
            this.FirstRowPanel.Controls.Add(this.label8);
            this.FirstRowPanel.Controls.Add(this.FirstRowLabel);
            this.FirstRowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FirstRowPanel.Location = new System.Drawing.Point(0, 110);
            this.FirstRowPanel.Name = "FirstRowPanel";
            this.FirstRowPanel.Size = new System.Drawing.Size(198, 22);
            this.FirstRowPanel.TabIndex = 37;
            // 
            // ChangeFirstRow
            // 
            this.ChangeFirstRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeFirstRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeFirstRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeFirstRow.Location = new System.Drawing.Point(78, 0);
            this.ChangeFirstRow.Name = "ChangeFirstRow";
            this.ChangeFirstRow.Size = new System.Drawing.Size(63, 22);
            this.ChangeFirstRow.TabIndex = 34;
            this.ChangeFirstRow.Text = "Сменить";
            this.ChangeFirstRow.UseVisualStyleBackColor = true;
            this.ChangeFirstRow.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // LastRowPanel
            // 
            this.LastRowPanel.Controls.Add(this.ChangeLastRow);
            this.LastRowPanel.Controls.Add(this.label9);
            this.LastRowPanel.Controls.Add(this.LastRowLabel);
            this.LastRowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LastRowPanel.Location = new System.Drawing.Point(0, 132);
            this.LastRowPanel.Name = "LastRowPanel";
            this.LastRowPanel.Size = new System.Drawing.Size(198, 23);
            this.LastRowPanel.TabIndex = 37;
            // 
            // ChangeLastRow
            // 
            this.ChangeLastRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeLastRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeLastRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangeLastRow.Location = new System.Drawing.Point(78, 0);
            this.ChangeLastRow.Name = "ChangeLastRow";
            this.ChangeLastRow.Size = new System.Drawing.Size(63, 22);
            this.ChangeLastRow.TabIndex = 35;
            this.ChangeLastRow.Text = "Сменить";
            this.ChangeLastRow.UseVisualStyleBackColor = true;
            this.ChangeLastRow.Click += new System.EventHandler(this.ChangeParametr_Click);
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.AutoSize = true;
            this.SettingsPanel.Controls.Add(this.LastRowPanel);
            this.SettingsPanel.Controls.Add(this.FirstRowPanel);
            this.SettingsPanel.Controls.Add(this.NightColPanel);
            this.SettingsPanel.Controls.Add(this.HolidayColPanel);
            this.SettingsPanel.Controls.Add(this.NormalColPanel);
            this.SettingsPanel.Controls.Add(this.FioColPanel);
            this.SettingsPanel.Controls.Add(this.CodeColPanel);
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsPanel.Location = new System.Drawing.Point(1, 23);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(198, 155);
            this.SettingsPanel.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Expand);
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 22);
            this.panel2.TabIndex = 39;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            // 
            // Expand
            // 
            this.Expand.Image = global::OTIZ_Tabel.Properties.Resources.minus16;
            this.Expand.Location = new System.Drawing.Point(1, 1);
            this.Expand.Name = "Expand";
            this.Expand.Size = new System.Drawing.Size(20, 20);
            this.Expand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Expand.TabIndex = 3;
            this.Expand.TabStop = false;
            this.Expand.Click += new System.EventHandler(this.Expand_Click);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Exit.Image = global::OTIZ_Tabel.Properties.Resources.icons8_умножение_18;
            this.Exit.Location = new System.Drawing.Point(166, 1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(31, 20);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Exit.TabIndex = 2;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseEnter += new System.EventHandler(this.Exit_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Табель УРВ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // FieldSettingWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(200, 200);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 0);
            this.Name = "FieldSettingWidget";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FieldSettingWidget";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FieldSettingWidget_FormClosed);
            this.Load += new System.EventHandler(this.FieldSettingWidget_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FieldSettingWidget_Paint);
            this.HolidayColPanel.ResumeLayout(false);
            this.HolidayColPanel.PerformLayout();
            this.NightColPanel.ResumeLayout(false);
            this.NightColPanel.PerformLayout();
            this.NormalColPanel.ResumeLayout(false);
            this.NormalColPanel.PerformLayout();
            this.CodeColPanel.ResumeLayout(false);
            this.CodeColPanel.PerformLayout();
            this.FioColPanel.ResumeLayout(false);
            this.FioColPanel.PerformLayout();
            this.FirstRowPanel.ResumeLayout(false);
            this.FirstRowPanel.PerformLayout();
            this.LastRowPanel.ResumeLayout(false);
            this.LastRowPanel.PerformLayout();
            this.SettingsPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Expand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HolidayColPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel NightColPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel NormalColPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label HolidayColLabel;
        private System.Windows.Forms.Label NightColLabel;
        private System.Windows.Forms.Label NormalColLabel;
        private System.Windows.Forms.Label CodeColLabel;
        private System.Windows.Forms.Label FioColLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LastRowLabel;
        private System.Windows.Forms.Label FirstRowLabel;
        private System.Windows.Forms.Panel CodeColPanel;
        private System.Windows.Forms.Panel FioColPanel;
        private System.Windows.Forms.Panel FirstRowPanel;
        private System.Windows.Forms.Panel LastRowPanel;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.PictureBox Expand;
        private System.Windows.Forms.Timer timer1;
        private UnselectableButton ChangeCodeCol;
        private UnselectableButton ChangeFioCol;
        private UnselectableButton ChangeHolidayCol;
        private UnselectableButton ChangeNightCol;
        private UnselectableButton ChangeNormalCol;
        private UnselectableButton ChangeFirstRow;
        private UnselectableButton ChangeLastRow;
    }
}