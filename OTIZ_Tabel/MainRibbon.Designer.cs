namespace OTIZ_Tabel
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
            UpdateConnectionType();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.ChangeConnectionState = this.Factory.CreateRibbonButton();
            this.GetWorkedTime = this.Factory.CreateRibbonButton();
            this.Settings = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.ChangeConnectionState);
            this.group1.Items.Add(this.GetWorkedTime);
            this.group1.Items.Add(this.Settings);
            this.group1.Label = "ОТИЗ АО \"Стальмост\"";
            this.group1.Name = "group1";
            // 
            // ChangeConnectionState
            // 
            this.ChangeConnectionState.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ChangeConnectionState.Image = global::OTIZ_Tabel.Properties.Resources.disconnect;
            this.ChangeConnectionState.Label = "Соединение с базой 1С";
            this.ChangeConnectionState.Name = "ChangeConnectionState";
            this.ChangeConnectionState.ShowImage = true;
            this.ChangeConnectionState.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ChangeConnectionState_Click);
            // 
            // GetWorkedTime
            // 
            this.GetWorkedTime.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.GetWorkedTime.Image = global::OTIZ_Tabel.Properties.Resources.time_list;
            this.GetWorkedTime.Label = "Проставить часы";
            this.GetWorkedTime.Name = "GetWorkedTime";
            this.GetWorkedTime.ShowImage = true;
            this.GetWorkedTime.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GetWorkedTime_Click);
            // 
            // Settings
            // 
            this.Settings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Settings.Image = global::OTIZ_Tabel.Properties.Resources.settings;
            this.Settings.Label = "Настроить приложение";
            this.Settings.Name = "Settings";
            this.Settings.ShowImage = true;
            this.Settings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Settings_Click);
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton GetWorkedTime;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton Settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ChangeConnectionState;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
