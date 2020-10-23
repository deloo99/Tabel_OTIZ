namespace OTIZ_Tabel
{
    partial class SettingsForm
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
            this.TCSettings = new System.Windows.Forms.TabControl();
            this.TWorkSetting = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.FeastCol = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.NightCol = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.AppearCol = new System.Windows.Forms.TextBox();
            this.LastDate = new System.Windows.Forms.DateTimePicker();
            this.FirstDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LastRow = new System.Windows.Forms.TextBox();
            this.FirstRow = new System.Windows.Forms.TextBox();
            this.FIOCol = new System.Windows.Forms.TextBox();
            this.CodeCol = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TConnectSetting = new System.Windows.Forms.TabPage();
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.ComSettingsTab = new System.Windows.Forms.TabPage();
            this.BTCOMRemoveConnectionString = new System.Windows.Forms.Button();
            this.ComConnectionStrings = new System.Windows.Forms.ListBox();
            this.Preload = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComConnectionString = new System.Windows.Forms.TextBox();
            this.BTCOMAddConnectionString = new System.Windows.Forms.Button();
            this.WebSettingsTab = new System.Windows.Forms.TabPage();
            this.BTWEBRemoveLink = new System.Windows.Forms.Button();
            this.WebConnectionStrings = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.WebConnectionString = new System.Windows.Forms.TextBox();
            this.BTWEBAddLink = new System.Windows.Forms.Button();
            this.UserPassword = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTSave = new System.Windows.Forms.Button();
            this.BTCancel = new System.Windows.Forms.Button();
            this.BTTestConnection = new System.Windows.Forms.Button();
            this.TCSettings.SuspendLayout();
            this.TWorkSetting.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TConnectSetting.SuspendLayout();
            this.SettingsTabControl.SuspendLayout();
            this.ComSettingsTab.SuspendLayout();
            this.WebSettingsTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCSettings
            // 
            this.TCSettings.Controls.Add(this.TWorkSetting);
            this.TCSettings.Controls.Add(this.TConnectSetting);
            this.TCSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCSettings.Location = new System.Drawing.Point(0, 0);
            this.TCSettings.Name = "TCSettings";
            this.TCSettings.SelectedIndex = 0;
            this.TCSettings.Size = new System.Drawing.Size(404, 309);
            this.TCSettings.TabIndex = 1;
            // 
            // TWorkSetting
            // 
            this.TWorkSetting.Controls.Add(this.panel3);
            this.TWorkSetting.Controls.Add(this.panel4);
            this.TWorkSetting.Controls.Add(this.panel2);
            this.TWorkSetting.Controls.Add(this.LastDate);
            this.TWorkSetting.Controls.Add(this.FirstDate);
            this.TWorkSetting.Controls.Add(this.label12);
            this.TWorkSetting.Controls.Add(this.label11);
            this.TWorkSetting.Controls.Add(this.LastRow);
            this.TWorkSetting.Controls.Add(this.FirstRow);
            this.TWorkSetting.Controls.Add(this.FIOCol);
            this.TWorkSetting.Controls.Add(this.CodeCol);
            this.TWorkSetting.Controls.Add(this.label9);
            this.TWorkSetting.Controls.Add(this.label8);
            this.TWorkSetting.Controls.Add(this.label5);
            this.TWorkSetting.Controls.Add(this.label4);
            this.TWorkSetting.Location = new System.Drawing.Point(4, 22);
            this.TWorkSetting.Name = "TWorkSetting";
            this.TWorkSetting.Padding = new System.Windows.Forms.Padding(3);
            this.TWorkSetting.Size = new System.Drawing.Size(396, 283);
            this.TWorkSetting.TabIndex = 0;
            this.TWorkSetting.Text = "Настройки заполнения данных";
            this.TWorkSetting.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(220)))), ((int)(((byte)(219)))));
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.FeastCol);
            this.panel3.Location = new System.Drawing.Point(8, 92);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 26);
            this.panel3.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Колонка праздничных:";
            // 
            // TBoxFeastCol
            // 
            this.FeastCol.Location = new System.Drawing.Point(267, 3);
            this.FeastCol.Name = "TBoxFeastCol";
            this.FeastCol.Size = new System.Drawing.Size(100, 20);
            this.FeastCol.TabIndex = 13;
            this.FeastCol.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(241)))));
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.NightCol);
            this.panel4.Location = new System.Drawing.Point(8, 118);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(380, 26);
            this.panel4.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Колонка ночных часов:";
            // 
            // TBoxNightCol
            // 
            this.NightCol.Location = new System.Drawing.Point(267, 3);
            this.NightCol.Name = "TBoxNightCol";
            this.NightCol.Size = new System.Drawing.Size(100, 20);
            this.NightCol.TabIndex = 10;
            this.NightCol.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.AppearCol);
            this.panel2.Location = new System.Drawing.Point(8, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 26);
            this.panel2.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Колонка явок:";
            // 
            // TBoxAppearCol
            // 
            this.AppearCol.Location = new System.Drawing.Point(267, 3);
            this.AppearCol.Name = "TBoxAppearCol";
            this.AppearCol.Size = new System.Drawing.Size(100, 20);
            this.AppearCol.TabIndex = 9;
            this.AppearCol.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // DTimeLastDate
            // 
            this.LastDate.Location = new System.Drawing.Point(249, 199);
            this.LastDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.LastDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.LastDate.Name = "DTimeLastDate";
            this.LastDate.Size = new System.Drawing.Size(126, 20);
            this.LastDate.TabIndex = 17;
            this.LastDate.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // DTimeFirstDate
            // 
            this.FirstDate.Location = new System.Drawing.Point(83, 199);
            this.FirstDate.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.FirstDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.FirstDate.Name = "DTimeFirstDate";
            this.FirstDate.Size = new System.Drawing.Size(126, 20);
            this.FirstDate.TabIndex = 16;
            this.FirstDate.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(217, 203);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "по:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Период с:";
            // 
            // TBoxLastRow
            // 
            this.LastRow.Location = new System.Drawing.Point(275, 173);
            this.LastRow.Name = "TBoxLastRow";
            this.LastRow.Size = new System.Drawing.Size(100, 20);
            this.LastRow.TabIndex = 12;
            this.LastRow.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TBoxFirstRow
            // 
            this.FirstRow.Location = new System.Drawing.Point(275, 147);
            this.FirstRow.Name = "TBoxFirstRow";
            this.FirstRow.Size = new System.Drawing.Size(100, 20);
            this.FirstRow.TabIndex = 11;
            this.FirstRow.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TBoxFIOCol
            // 
            this.FIOCol.Location = new System.Drawing.Point(275, 43);
            this.FIOCol.Name = "TBoxFIOCol";
            this.FIOCol.Size = new System.Drawing.Size(100, 20);
            this.FIOCol.TabIndex = 8;
            this.FIOCol.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // TBoxCodeCol
            // 
            this.CodeCol.Location = new System.Drawing.Point(275, 17);
            this.CodeCol.Name = "TBoxCodeCol";
            this.CodeCol.Size = new System.Drawing.Size(100, 20);
            this.CodeCol.TabIndex = 7;
            this.CodeCol.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Конечная строка:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Начальная строка:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Колонка ФИО:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Колонка табельного номера:";
            // 
            // TConnectSetting
            // 
            this.TConnectSetting.Controls.Add(this.SettingsTabControl);
            this.TConnectSetting.Controls.Add(this.UserPassword);
            this.TConnectSetting.Controls.Add(this.UserName);
            this.TConnectSetting.Controls.Add(this.label3);
            this.TConnectSetting.Controls.Add(this.label2);
            this.TConnectSetting.Location = new System.Drawing.Point(4, 22);
            this.TConnectSetting.Name = "TConnectSetting";
            this.TConnectSetting.Padding = new System.Windows.Forms.Padding(3);
            this.TConnectSetting.Size = new System.Drawing.Size(396, 283);
            this.TConnectSetting.TabIndex = 1;
            this.TConnectSetting.Text = "Настройки доступа 1С";
            this.TConnectSetting.UseVisualStyleBackColor = true;
            // 
            // ConnectionSettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.WebSettingsTab);
            this.SettingsTabControl.Controls.Add(this.ComSettingsTab);
            this.SettingsTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsTabControl.Location = new System.Drawing.Point(3, 3);
            this.SettingsTabControl.Name = "ConnectionSettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(390, 197);
            this.SettingsTabControl.TabIndex = 15;
            // 
            // TPCOMSetting
            // 
            this.ComSettingsTab.Controls.Add(this.BTCOMRemoveConnectionString);
            this.ComSettingsTab.Controls.Add(this.ComConnectionStrings);
            this.ComSettingsTab.Controls.Add(this.Preload);
            this.ComSettingsTab.Controls.Add(this.label1);
            this.ComSettingsTab.Controls.Add(this.ComConnectionString);
            this.ComSettingsTab.Controls.Add(this.BTCOMAddConnectionString);
            this.ComSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.ComSettingsTab.Name = "TPCOMSetting";
            this.ComSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ComSettingsTab.Size = new System.Drawing.Size(382, 171);
            this.ComSettingsTab.TabIndex = 0;
            this.ComSettingsTab.Text = "COM порт";
            this.ComSettingsTab.UseVisualStyleBackColor = true;
            // 
            // BTCOMRemoveConnectionString
            // 
            this.BTCOMRemoveConnectionString.Image = global::OTIZ_Tabel.Properties.Resources.delete_16p;
            this.BTCOMRemoveConnectionString.Location = new System.Drawing.Point(329, 25);
            this.BTCOMRemoveConnectionString.Name = "BTCOMRemoveConnectionString";
            this.BTCOMRemoveConnectionString.Size = new System.Drawing.Size(36, 24);
            this.BTCOMRemoveConnectionString.TabIndex = 9;
            this.BTCOMRemoveConnectionString.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTCOMRemoveConnectionString.UseVisualStyleBackColor = true;
            this.BTCOMRemoveConnectionString.Click += new System.EventHandler(this.BTCOMRemoveConnectionString_Click);
            // 
            // LBoxCOMConnectionStrings
            // 
            this.ComConnectionStrings.FormattingEnabled = true;
            this.ComConnectionStrings.Location = new System.Drawing.Point(15, 24);
            this.ComConnectionStrings.Name = "LBoxCOMConnectionStrings";
            this.ComConnectionStrings.Size = new System.Drawing.Size(351, 95);
            this.ComConnectionStrings.TabIndex = 6;
            this.ComConnectionStrings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LBoxCOMConnectionStrings_MouseDoubleClick);
            // 
            // CBoxPreload
            // 
            this.Preload.AutoSize = true;
            this.Preload.Location = new System.Drawing.Point(15, 150);
            this.Preload.Name = "CBoxPreload";
            this.Preload.Size = new System.Drawing.Size(283, 17);
            this.Preload.TabIndex = 10;
            this.Preload.Text = "Использовать пред. загрузку списка сотрудников";
            this.Preload.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите или введите строку подключения к 1С:";
            // 
            // TBoxCOMConnectionString
            // 
            this.ComConnectionString.Location = new System.Drawing.Point(15, 124);
            this.ComConnectionString.Name = "TBoxCOMConnectionString";
            this.ComConnectionString.Size = new System.Drawing.Size(309, 20);
            this.ComConnectionString.TabIndex = 7;
            // 
            // BTCOMAddConnectionString
            // 
            this.BTCOMAddConnectionString.Image = global::OTIZ_Tabel.Properties.Resources.left2top_p16;
            this.BTCOMAddConnectionString.Location = new System.Drawing.Point(329, 123);
            this.BTCOMAddConnectionString.Name = "BTCOMAddConnectionString";
            this.BTCOMAddConnectionString.Size = new System.Drawing.Size(38, 22);
            this.BTCOMAddConnectionString.TabIndex = 8;
            this.BTCOMAddConnectionString.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTCOMAddConnectionString.UseVisualStyleBackColor = true;
            this.BTCOMAddConnectionString.Click += new System.EventHandler(this.BTCOMAddConnectionString_Click);
            // 
            // TPWEBSetting
            // 
            this.WebSettingsTab.Controls.Add(this.BTWEBRemoveLink);
            this.WebSettingsTab.Controls.Add(this.WebConnectionStrings);
            this.WebSettingsTab.Controls.Add(this.label13);
            this.WebSettingsTab.Controls.Add(this.WebConnectionString);
            this.WebSettingsTab.Controls.Add(this.BTWEBAddLink);
            this.WebSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.WebSettingsTab.Name = "TPWEBSetting";
            this.WebSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.WebSettingsTab.Size = new System.Drawing.Size(382, 171);
            this.WebSettingsTab.TabIndex = 1;
            this.WebSettingsTab.Text = "WEB сервис";
            this.WebSettingsTab.UseVisualStyleBackColor = true;
            // 
            // BTWEBRemoveLink
            // 
            this.BTWEBRemoveLink.Image = global::OTIZ_Tabel.Properties.Resources.delete_16p;
            this.BTWEBRemoveLink.Location = new System.Drawing.Point(329, 25);
            this.BTWEBRemoveLink.Name = "BTWEBRemoveLink";
            this.BTWEBRemoveLink.Size = new System.Drawing.Size(36, 24);
            this.BTWEBRemoveLink.TabIndex = 14;
            this.BTWEBRemoveLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTWEBRemoveLink.UseVisualStyleBackColor = true;
            this.BTWEBRemoveLink.Click += new System.EventHandler(this.BTWEBRemoveLink_Click);
            // 
            // LBoxWEBLinks
            // 
            this.WebConnectionStrings.FormattingEnabled = true;
            this.WebConnectionStrings.Location = new System.Drawing.Point(15, 24);
            this.WebConnectionStrings.Name = "LBoxWEBLinks";
            this.WebConnectionStrings.Size = new System.Drawing.Size(351, 95);
            this.WebConnectionStrings.TabIndex = 11;
            this.WebConnectionStrings.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LBoxWEBLinks_MouseDoubleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(284, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Выберите или введите ссылку на файл конфигурации:";
            // 
            // TBoxWEBLink
            // 
            this.WebConnectionString.Location = new System.Drawing.Point(15, 124);
            this.WebConnectionString.Name = "TBoxWEBLink";
            this.WebConnectionString.Size = new System.Drawing.Size(309, 20);
            this.WebConnectionString.TabIndex = 12;
            // 
            // BTWEBAddLink
            // 
            this.BTWEBAddLink.Image = global::OTIZ_Tabel.Properties.Resources.left2top_p16;
            this.BTWEBAddLink.Location = new System.Drawing.Point(329, 123);
            this.BTWEBAddLink.Name = "BTWEBAddLink";
            this.BTWEBAddLink.Size = new System.Drawing.Size(38, 22);
            this.BTWEBAddLink.TabIndex = 13;
            this.BTWEBAddLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTWEBAddLink.UseVisualStyleBackColor = true;
            this.BTWEBAddLink.Click += new System.EventHandler(this.BTWEBAddLink_Click);
            // 
            // TBoxUserPassword
            // 
            this.UserPassword.Location = new System.Drawing.Point(131, 241);
            this.UserPassword.Name = "TBoxUserPassword";
            this.UserPassword.PasswordChar = '#';
            this.UserPassword.Size = new System.Drawing.Size(242, 20);
            this.UserPassword.TabIndex = 5;
            this.UserPassword.WordWrap = false;
            // 
            // TBoxUserName
            // 
            this.UserName.Location = new System.Drawing.Point(131, 215);
            this.UserName.Name = "TBoxUserName";
            this.UserName.Size = new System.Drawing.Size(242, 20);
            this.UserName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя пользователя:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTSave);
            this.panel1.Controls.Add(this.BTCancel);
            this.panel1.Controls.Add(this.BTTestConnection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 32);
            this.panel1.TabIndex = 2;
            // 
            // BTSave
            // 
            this.BTSave.Image = global::OTIZ_Tabel.Properties.Resources.save_16p;
            this.BTSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTSave.Location = new System.Drawing.Point(198, 4);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(100, 24);
            this.BTSave.TabIndex = 2;
            this.BTSave.Text = "Сохранить";
            this.BTSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTSave.UseVisualStyleBackColor = true;
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // BTCancel
            // 
            this.BTCancel.Image = global::OTIZ_Tabel.Properties.Resources.cancel_16p;
            this.BTCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTCancel.Location = new System.Drawing.Point(300, 4);
            this.BTCancel.Name = "BTCancel";
            this.BTCancel.Size = new System.Drawing.Size(100, 24);
            this.BTCancel.TabIndex = 1;
            this.BTCancel.Text = "Отменить";
            this.BTCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTCancel.UseVisualStyleBackColor = true;
            this.BTCancel.Click += new System.EventHandler(this.BTCancel_Click);
            // 
            // BTTestConnection
            // 
            this.BTTestConnection.Image = global::OTIZ_Tabel.Properties.Resources.refresh_16p;
            this.BTTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTTestConnection.Location = new System.Drawing.Point(4, 4);
            this.BTTestConnection.Name = "BTTestConnection";
            this.BTTestConnection.Size = new System.Drawing.Size(160, 24);
            this.BTTestConnection.TabIndex = 0;
            this.BTTestConnection.Text = "Тест соединения";
            this.BTTestConnection.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BTTestConnection.UseVisualStyleBackColor = true;
            this.BTTestConnection.Click += new System.EventHandler(this.BTTestConnection_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(404, 341);
            this.Controls.Add(this.TCSettings);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки приложения";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.TCSettings.ResumeLayout(false);
            this.TWorkSetting.ResumeLayout(false);
            this.TWorkSetting.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TConnectSetting.ResumeLayout(false);
            this.TConnectSetting.PerformLayout();
            this.SettingsTabControl.ResumeLayout(false);
            this.ComSettingsTab.ResumeLayout(false);
            this.ComSettingsTab.PerformLayout();
            this.WebSettingsTab.ResumeLayout(false);
            this.WebSettingsTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCSettings;
        private System.Windows.Forms.TabPage TWorkSetting;
        private System.Windows.Forms.DateTimePicker LastDate;
        private System.Windows.Forms.DateTimePicker FirstDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox FeastCol;
        private System.Windows.Forms.TextBox LastRow;
        private System.Windows.Forms.TextBox FirstRow;
        private System.Windows.Forms.TextBox NightCol;
        private System.Windows.Forms.TextBox AppearCol;
        private System.Windows.Forms.TextBox FIOCol;
        private System.Windows.Forms.TextBox CodeCol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage TConnectSetting;
        private System.Windows.Forms.TextBox UserPassword;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTSave;
        private System.Windows.Forms.Button BTCancel;
        private System.Windows.Forms.Button BTTestConnection;
        private System.Windows.Forms.TextBox ComConnectionString;
        private System.Windows.Forms.ListBox ComConnectionStrings;
        private System.Windows.Forms.Button BTCOMRemoveConnectionString;
        private System.Windows.Forms.Button BTCOMAddConnectionString;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox Preload;
        private System.Windows.Forms.TabControl SettingsTabControl;
        private System.Windows.Forms.TabPage ComSettingsTab;
        private System.Windows.Forms.TabPage WebSettingsTab;
        private System.Windows.Forms.ListBox WebConnectionStrings;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BTWEBRemoveLink;
        private System.Windows.Forms.TextBox WebConnectionString;
        private System.Windows.Forms.Button BTWEBAddLink;
    }
}