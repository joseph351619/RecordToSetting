using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordToSetting
{
    public class RecordDataObject 
    {
        public RecordDataObject(string patientID, string doctorName, DateTime? date, Guid drugID, string drugName,
                                string frequency, int frequencyNumber, string route, int routeNumber, string unit, 
                                int unitNumber, string quantity, double quantityNumber, int days,
                                double dose, DateTime? submitedAt)
        {
            PatientID   = patientID;
            Doctorname  =doctorName ;
            Date        =date       ;
            DrugID      =drugID     ;
            DrugName    =drugName   ;
            Frequency   =frequency;
            FrequencyNumber = frequencyNumber;
            Route       =route      ;
            RouteNumber = routeNumber;
            Unit        =unit       ;
            UnitNumber = unitNumber;
            Quantity    =quantity   ;
            QuantityNumber    = quantityNumber;
            Days        =days       ;
            Dose        =dose       ;
            SubmitedAt  = submitedAt;
        }
        public string   PatientID       { get; set; }
        public string   Doctorname      { get; set; }
        public DateTime? Date            { get; set; }
        public Guid   DrugID          { get; set; }
        public string   DrugName        { get; set; }
        public string   Frequency       { get; set; }
        public int      FrequencyNumber       { get; set; }
        public string   Route           { get; set; }
        public int      RouteNumber           { get; set; }
        public string   Unit            { get; set; }
        public int      UnitNumber            { get; set; }
        public string   Quantity        { get; set; }
        public double   QuantityNumber        { get; set; }
        public int      Days            { get; set; }
        public double      Dose            { get; set; }
        public DateTime? SubmitedAt      { get; set; }
    }
}
