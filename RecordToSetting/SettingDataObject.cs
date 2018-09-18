using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordToSetting
{
    public class SettingDataObject
    {
        public SettingDataObject(Guid drugID, double dose, string unit, string frequency, string route, int? days, double quantity)
        {
            DrugID    = drugID     ;
            Dose      = dose       ;
            Unit      = unit       ;
            Frequency = frequency  ;
            Route     = route      ;
            Days      = days       ;
            Quantity  = quantity    ;
        }
        public Guid   DrugID      { get; set; }
        public double      Dose        { get; set; }
        public string Unit        { get; set; }
        public string Frequency   { get; set; }
        public string     Route       { get; set; }
        public int?     Days        { get; set; }
        public double Quantity    { get; set; }
    }
}
