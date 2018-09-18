using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordToSetting
{
    public partial class Form1 : Form
    {
        private static string ConnectionString = "Server=.;Database=MobileHis_Majuro;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dgvRecordList.DataSource = GetRecordList();
                dgvSettingList.DataSource = GetSettingList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private List<RecordDataObject> GetRecordList()
        {
            List<RecordDataObject> recordList = new List<RecordDataObject>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(RecordCommand(), conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    recordList.Add(new RecordDataObject(patientID : reader["PatinetID"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("PatinetID")),
                                                        doctorName: reader["doctorname"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("doctorname")),
                                                        date       : reader.GetNullableDateTime("date"),
                                                        drugID     : reader["DrugID"] == System.DBNull.Value ? default(Guid) : reader.GetGuid(reader.GetOrdinal("DrugID")),
                                                        drugName   : reader["drugname"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("drugname")),
                                                        frequency  : reader["Frequency"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("Frequency")),
                                                        frequencyNumber: reader["Frequency"] == System.DBNull.Value ? default(int) : reader.GetInt32(reader.GetOrdinal("FrequencyNumber")),
                                                        route      : reader["route"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("route")),
                                                        routeNumber: reader["route"] == System.DBNull.Value ? default(int) : reader.GetInt32(reader.GetOrdinal("routeNumber")),
                                                        unit       : reader["Unit"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("Unit")),
                                                        unitNumber: reader["Unit"] == System.DBNull.Value ? default(int) : reader.GetInt32(reader.GetOrdinal("UnitNumber")),
                                                        quantity   : reader["Quantity"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("Quantity")),
                                                        quantityNumber: reader["Quantity"] == System.DBNull.Value ? default(double) : reader.GetDouble(reader.GetOrdinal("QuantityNumber")),
                                                        days       : reader["Days"] == System.DBNull.Value ? default(int) : reader.GetInt32(reader.GetOrdinal("Days")),
                                                        dose       :reader.GetDouble(reader.GetOrdinal("Dose")),
                                                        submitedAt: reader.GetNullableDateTime("SubmitedAt")
                                                       ));
                }
                reader.Close();
            }
            return recordList;
        }

        private string RecordCommand()
        {
            StringBuilder commandString = new StringBuilder();
            commandString.Clear();
            commandString.Append(" select a.PatinetID, ");
            commandString.Append(" (select g.Name from account g where g.id=a.DoctorID) as doctorname, ");
            commandString.Append(" a.date,b.DrugID, ");
            commandString.Append(" (select g.Title from drug g where g.GID=b.DrugID) as drugname, ");
            commandString.Append(" (select g.ItemDescription from CodeFile g where g.id=b.Frequency) as Frequency, ");
            commandString.Append(" b.Frequency as FrequencyNumber, ");
            commandString.Append(" (select g.ItemDescription from CodeFile g where g.id=b.Route) as [route], ");
            commandString.Append(" b.Route as RouteNumber, ");
            commandString.Append(" (select g.ItemDescription from CodeFile g where g.id=b.Unit) as Unit, ");
            commandString.Append("  b.Unit as UnitNumber, ");
            commandString.Append(" (select g.ItemDescription from CodeFile g where g.id=b.Quantity) as Quantity, ");
            commandString.Append("  b.Quantity as QuantityNumber, ");
            commandString.Append(" b.Days,b.Dose, ");
            commandString.Append(" a.SubmitedAt ");
            commandString.Append(" from OpdRecord a left join orderdrug b  ");
            commandString.Append(" on a.id=b.RecordID  ");
            commandString.Append(" where b.recordid is not null ");
            commandString.Append(" order by a.CreatedAt desc ");
            return commandString.ToString();
        }
        

        private List<SettingDataObject> GetSettingList()
        {
            List<SettingDataObject> settingList = new List<SettingDataObject>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string commandString = "Select * From DrugSetting";
                SqlCommand cmd = new SqlCommand(commandString, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    settingList.Add(new SettingDataObject(drugID: reader["DrugID"] == System.DBNull.Value ? default(Guid) : reader.GetGuid(reader.GetOrdinal("DrugID")),
                                                          dose: reader["Dose"] == System.DBNull.Value ? default(double) : reader.GetDouble(reader.GetOrdinal("Dose")),
                                                          unit: reader["Unit"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("Unit")),
                                                          frequency: reader["Frequency"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("Frequency")),
                                                          route: reader["Route"] == System.DBNull.Value ? default(string) : reader.GetString(reader.GetOrdinal("Route")),
                                                          days: reader["Days"] == System.DBNull.Value ? default(int?) : reader.GetInt32(reader.GetOrdinal("Days")),
                                                          quantity: reader["Quantity"] == System.DBNull.Value ? default(double) : reader.GetDouble(reader.GetOrdinal("Quantity"))
                                                       ));
                }
                reader.Close();
            }
            return settingList;
        }

        private void InsertSettingFromRecord(RecordDataObject record)
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(InsertSettingCommand(), conn);
                cmd.Parameters.AddWithValue("@drugID", record.DrugID);
                cmd.Parameters.AddWithValue("@dose", record.Dose);
                cmd.Parameters.AddWithValue("@unit", record.UnitNumber);
                cmd.Parameters.AddWithValue("@frequency", record.FrequencyNumber);
                cmd.Parameters.AddWithValue("@route", record.RouteNumber);
                cmd.Parameters.AddWithValue("@days", record.Days);
                cmd.Parameters.AddWithValue("@quantity", record.QuantityNumber);
                cmd.ExecuteNonQuery();
            }
        }

        private string InsertSettingCommand()
        {
            StringBuilder command = new StringBuilder();
            command.Clear();
            command.Append("   INSERT INTO DrugSetting    ");
            command.Append("               (DrugID,       ");
            command.Append("                Dose,         ");
            command.Append("                Unit,         ");
            command.Append("                Frequency,    ");
            command.Append("                Route,        ");
            command.Append("                Days,         ");
            command.Append("                Quantity)     ");
            command.Append("         Values( @drugID,     ");
            command.Append("                 @dose,       ");
            command.Append("                 @unit,       ");
            command.Append("                 @frequency,  ");
            command.Append("                 @route,      ");
            command.Append("                 @days,       ");
            command.Append("                 @quantity)   ");
            return command.ToString();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            RecordDataObject currentObject = (RecordDataObject)dgvRecordList.CurrentRow.DataBoundItem;
            try
            {
                InsertSettingFromRecord(currentObject);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }





    public static class ReaderExtensions
    {
        public static DateTime? GetNullableDateTime(this SqlDataReader reader, string name)
        {
            var col = reader.GetOrdinal(name);
            return reader.IsDBNull(col) ?
                        (DateTime?)null :
                        (DateTime?)reader.GetDateTime(col);
        }
    }
}
