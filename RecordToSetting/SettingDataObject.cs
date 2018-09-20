using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordToSetting
{
    public class SettingDataObject : CsvableBase
    {
        public SettingDataObject(Guid drugID, double dose, string unit, string frequency, string route, 
                                int? days, string quantity, string drugName)
        {
            DrugID    = drugID     ;
            DrugName  = drugName   ;
            Dose      = dose       ;
            Unit      = unit       ;
            Frequency = frequency  ;
            Route     = route      ;
            Days      = days       ;
            Quantity  = quantity   ;
        }
        public Guid   DrugID      { get; set; }
        public string DrugName { get; set; }
        public double      Dose        { get; set; }
        public string Unit        { get; set; }
        public string Frequency   { get; set; }
        public string     Route       { get; set; }
        public int?     Days        { get; set; }
        public string Quantity    { get; set; }
    }
}
