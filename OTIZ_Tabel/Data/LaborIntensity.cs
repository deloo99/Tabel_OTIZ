namespace OTIZ_Tabel.Data
{
    public class LaborIntensity
    {
        public LaborIntensity() { }
        public LaborIntensity(string[] data)
        {
            string GetString(string source) => string.IsNullOrWhiteSpace(source) ? string.Empty : source.Trim();
            int GetInt(string source) => int.TryParse(GetString(source), out int value) ? value : 0;
            double GetDouble(string source) => double.TryParse(GetString(source).Replace('.', ','), out double value) ? value : 0.0;

            Inventory = GetString(data[0]);
            Order = GetString(data[1]);
            Name = GetString(data[2]);
            Mark = GetString(data[3]);
            CountT = GetInt(data[5]);
            CountN = GetInt(data[6]);
            WeightOne = GetDouble(data[7]);
            WeightAll = GetDouble(data[8]);
            HoursRate = GetDouble(data[9]);
            Assambly = GetDouble(data[10]);
            Welding = GetDouble(data[11]);
            Stripping = GetDouble(data[12]);
            HeatTreatment = GetDouble(data[13]);
            WTotal = GetDouble(data[14]);
            GO1 = GetDouble(data[15]);
            GO2 = GetDouble(data[16]);
            NO1 = GetDouble(data[17]);
            NO2 = GetDouble(data[18]);
            GO11 = GetDouble(data[19]);
            GO12 = GetDouble(data[20]);
            NO11 = GetDouble(data[21]);
            NO21 = GetDouble(data[22]);
            U = GetDouble(data[23]);
            Total = GetDouble(data[24]);
            HoursRateWithoutWelds = GetDouble(data[26]);
        }

        public string Inventory { get; set; }
        public string Order { get; set; }
        public string Name { get; set; }
        public string Mark { get; set; }
        public int CountT { get; set; }
        public int CountN { get; set; }
        public double WeightOne { get; set; }
        public double WeightAll { get; set; }
        public double HoursRate { get; set; }
        public double Assambly { get; set; }
        public double Welding { get; set; }
        public double Stripping { get; set; }
        public double HeatTreatment { get; set; }
        public double WTotal { get; set; }
        public double GO1 { get; set; }
        public double GO2 { get; set; }
        public double NO1 { get; set; }
        public double NO2 { get; set; }
        public double GO11 { get; set; }
        public double GO12 { get; set; }
        public double NO11 { get; set; }
        public double NO21 { get; set; }
        public double U { get; set; }
        public double Total { get; set; }
        public double HoursRateWithoutWelds { get; set; }
    }
}
