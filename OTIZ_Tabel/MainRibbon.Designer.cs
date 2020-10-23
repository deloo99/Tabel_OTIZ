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
            CheckEntity1C();
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
            this.BTChangeConnection = this.Factory.CreateRibbonButton();
            this.BTSetWorkingHours = this.Factory.CreateRibbonButton();
            this.BTSettings = this.Factory.CreateRibbonButton();
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
            this.group1.Items.Add(this.BTChangeConnection);
            this.group1.Items.Add(this.BTSetWorkingHours);
            this.group1.Items.Add(this.BTSettings);
            this.group1.Label = "ОТИЗ АО \"Стальмост\"";
            this.group1.Name = "group1";
            // 
            // BTChangeConnection
            // 
            this.BTChangeConnection.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BTChangeConnection.Image = global::OTIZ_Tabel.Properties.Resources.disconnect;
            this.BTChangeConnection.Label = "Соединение с базой 1С";
            this.BTChangeConnection.Name = "BTChangeConnection";
            this.BTChangeConnection.ShowImage = true;
            this.BTChangeConnection.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BTChangeConnection_Click);
            // 
            // BTSetWorkingHours
            // 
            this.BTSetWorkingHours.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BTSetWorkingHours.Image = global::OTIZ_Tabel.Properties.Resources.time_list;
            this.BTSetWorkingHours.Label = "Проставить часы";
            this.BTSetWorkingHours.Name = "BTSetWorkingHours";
            this.BTSetWorkingHours.ShowImage = true;
            this.BTSetWorkingHours.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BTSetWorkingHours_Click);
            // 
            // BTSettings
            // 
            this.BTSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BTSettings.Image = global::OTIZ_Tabel.Properties.Resources.settings;
            this.BTSettings.Label = "Настроить приложение";
            this.BTSettings.Name = "BTSettings";
            this.BTSettings.ShowImage = true;
            this.BTSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BTSettings_Click);
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BTSetWorkingHours;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BTSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BTChangeConnection;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
