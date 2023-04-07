using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TrippingApp.Model;

namespace TrippingApp.Runtime
{
    public class HistoryLogger
    {
        public static string ConnectionString = "Server=localhost;Database=hoya_server;Uid=root;Pwd=123456789;";
        public static readonly string TableName = "rack_object";

        public static bool Checktable() 
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = @database AND table_name = @tableName";
                    command.Parameters.AddWithValue("@database", connection.Database);
                    command.Parameters.AddWithValue("@tableName", TableName);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        Console.WriteLine("Table exists.");
                        return true;
                       
                    }
                    else
                    {
                        Console.WriteLine("Table does not exist.");
                        return false;
                    }
                }
            }
        }

        public static void CreateTable_History()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string createTableQuery = "CREATE TABLE "+TableName+ " ( id INT AUTO_INCREMENT PRIMARY KEY, " +
                                          "rack_barcode VARCHAR(255), " +
                                          "ng_type VARCHAR(255), " +
                                          "rack_details JSON, " +
                                          "bath1_temper FLOAT, " +
                                          "bath1_envir_temp1 FLOAT, " +
                                          "bath1_envir_humi1 FLOAT, " +
                                          "bath1_envir_temp2 FLOAT, " +
                                          "bath1_envir_humi2 FLOAT, " +
                                          "bath1_time_in DATETIME, " +
                                          "bath1_time_out DATETIME, " +
                                          "bath2_temper FLOAT, " +
                                          "bath2_envir_temp1 FLOAT, " +
                                          "bath2_envir_humi1 FLOAT, " +
                                          "bath2_envir_temp2 FLOAT, " +
                                          "bath2_envir_humi2 FLOAT, " +
                                          "bath2_time_in DATETIME, " +
                                          "bath2_time_out DATETIME, " +
                                          "bath3_temper FLOAT, " +
                                          "bath3_envir_temp1 FLOAT, " +
                                          "bath3_envir_humi1 FLOAT, " +
                                          "bath3_envir_temp2 FLOAT, " +
                                          "bath3_envir_humi2 FLOAT, " +
                                          "bath3_time_in DATETIME, " +
                                          "bath3_time_out DATETIME, " +
                                          "bath4_temper FLOAT, " +
                                          "bath4_envir_temp1 FLOAT, " +
                                          "bath4_envir_humi1 FLOAT, " +
                                          "bath4_envir_temp2 FLOAT, " +
                                          "bath4_envir_humi2 FLOAT, " +
                                          "bath4_time_in DATETIME, " +
                                          "bath4_time_out DATETIME, " +
                                          "bath5_temper FLOAT, " +
                                          "bath5_envir_temp1 FLOAT, " +
                                          "bath5_envir_humi1 FLOAT, " +
                                          "bath5_envir_temp2 FLOAT, " +
                                          "bath5_envir_humi2 FLOAT, " +
                                          "bath5_time_in DATETIME, " +
                                          "bath5_time_out DATETIME, " +
                                          "bath6_temper FLOAT, " +
                                          "bath6_envir_temp1 FLOAT, " +
                                          "bath6_envir_humi1 FLOAT, " +
                                          "bath6_envir_temp2 FLOAT, " +
                                          "bath6_envir_humi2 FLOAT, " +
                                          "bath6_time_in DATETIME, " +
                                          "bath6_time_out DATETIME, " +
                                          "bath7_temper FLOAT, " +
                                          "bath7_envir_temp1 FLOAT, " +
                                          "bath7_envir_humi1 FLOAT, " +
                                          "bath7_envir_temp2 FLOAT, " +
                                          "bath7_envir_humi2 FLOAT, " +
                                          "bath7_time_in DATETIME, " +
                                          "bath7_time_out DATETIME, " +
                                          "bath8_temper FLOAT, " +
                                          "bath7_envir_temp1 FLOAT, " +
                                          "bath7_envir_humi1 FLOAT, " +
                                          "bath7_envir_temp2 FLOAT, " +
                                          "bath7_envir_humi2 FLOAT, " +
                                          "bath8_time_in DATETIME, " +
                                          "bath8_time_out DATETIME, " +
                                          "bath9_temper FLOAT, " +
                                          "bath9_envir_temp1 FLOAT, " +
                                          "bath9_envir_humi1 FLOAT, " +
                                          "bath9_envir_temp2 FLOAT, " +
                                          "bath9_envir_humi2 FLOAT, " +
                                          "bath9_time_in DATETIME, " +
                                          "bath9_time_out DATETIME, " +
                                          "bath10_temper FLOAT, " +
                                          "bath10_envir_temp1 FLOAT, " +
                                          "bath10_envir_humi1 FLOAT, " +
                                          "bath10_envir_temp2 FLOAT, " +
                                          "bath10_envir_humi2 FLOAT, " +
                                          "bath10_time_in DATETIME, " +
                                          "bath10_time_out DATETIME, " +
                                          "rack_status ENUM('Done', 'Inprocess') " +
                                          ");";

                using (var command = new MySqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table created successfully.");
                }
            }
        }
        public static void AddRackObject(RackObject rackObject)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO "+ TableName +" (rack_barcode, ng_type, rack_details, bath1_temper, " + "bath1_envir_temp1, "+ "bath1_envir_humi1, " + "bath1_envir_temp2, " + "bath1_envir_humi2, " +
                                   "bath1_time_in, bath1_time_out, " +
                                   "bath2_temper, " + "bath2_envir_temp1, " + "bath2_envir_humi1, " + "bath2_envir_temp2, " + "bath2_envir_humi2, " +
                                   "bath2_time_in, bath2_time_out, " +
                                   "bath3_temper, " + "bath3_envir_temp1, " + "bath3_envir_humi1, " + "bath3_envir_temp2, " + "bath3_envir_humi2, " +
                                   "bath3_time_in, bath3_time_out, " +
                                   "bath4_temper, " + "bath4_envir_temp1, " + "bath4_envir_humi1, " + "bath4_envir_temp2, " + "bath4_envir_humi2, " +
                                   "bath4_time_in, bath4_time_out, " +
                                   "bath5_temper, " + "bath5_envir_temp1, " + "bath5_envir_humi1, " + "bath5_envir_temp2, " + "bath5_envir_humi2, " +
                                   "bath5_time_in, bath5_time_out, " +
                                   "bath6_temper, " + "bath6_envir_temp1, " + "bath6_envir_humi1, " + "bath6_envir_temp2, " + "bath6_envir_humi2, " +
                                   "bath6_time_in, bath6_time_out, " +
                                   "bath7_temper, " + "bath7_envir_temp1, " + "bath7_envir_humi1, " + "bath7_envir_temp2, " + "bath7_envir_humi2, " +
                                   "bath7_time_in, bath7_time_out, " +
                                   "bath8_temper, " + "bath8_envir_temp1, " + "bath8_envir_humi1, " + "bath8_envir_temp2, " + "bath8_envir_humi2, " +
                                   "bath8_time_in, bath8_time_out, " +
                                   "bath9_temper, " + "bath9_envir_temp1, " + "bath9_envir_humi1, " + "bath9_envir_temp2, " + "bath9_envir_humi2, " +
                                   "bath9_time_in, bath9_time_out, " +
                                   "bath10_temper, " + "bath10_envir_temp1, " + "bath10_envir_humi1, " + "bath10_envir_temp2, " + "bath10_envir_humi2, " +
                                   "bath10_time_in, bath10_time_out, rack_status) " +
                                   "VALUES (@RackBarcode, @NGType, @RackDetails, @Bath1Temper, " + "@Bath1ET1, "+ "@Bath1EH1, " + "@Bath1ET2, " + "@Bath1EH2, " +
                                   "@Bath1In, @Bath1Out, " +
                                   "@Bath2Temper, " + "@Bath2ET1, " + "@Bath2EH1, " + "@Bath2ET2, " + "@Bath2EH2, " +
                                   "@Bath2In, @Bath2Out, " +
                                   "@Bath3Temper, " + "@Bath3ET1, " + "@Bath3EH1, " + "@Bath3ET2, " + "@Bath3EH2, " +
                                   "@Bath3In, @Bath3Out, " +
                                   "@Bath4Temper, " + "@Bath4ET1, " + "@Bath4EH1, " + "@Bath4ET2, " + "@Bath4EH2, " +
                                   "@Bath4In, @Bath4Out, " +
                                   "@Bath5Temper, " + "@Bath5ET1, " + "@Bath5EH1, " + "@Bath5ET2, " + "@Bath5EH2, " +
                                   "@Bath5In, @Bath5Out, " +
                                   "@Bath6Temper, " + "@Bath6ET1, " + "@Bath6EH1, " + "@Bath6ET2, " + "@Bath6EH2, " +
                                   "@Bath6In, @Bath6Out, " +
                                   "@Bath7Temper, " + "@Bath7ET1, " + "@Bath7EH1, " + "@Bath7ET2, " + "@Bath7EH2, " +
                                   "@Bath7In, @Bath7Out, " +
                                   "@Bath8Temper, " + "@Bath8ET1, " + "@Bath8EH1, " + "@Bath8ET2, " + "@Bath8EH2, " +
                                   "@Bath8In, @Bath8Out, " +
                                   "@Bath9Temper, " + "@Bath9ET1, " + "@Bath9EH1, " + "@Bath9ET2, " + "@Bath9EH2, " +
                                   "@Bath9In, @Bath9Out, " +
                                   "@Bath10Temper, " + "@Bath10ET1, " + "@Bath10EH1, " + "@Bath10ET2, " + "@Bath10EH2, " +
                                   "@Bath10In, @Bath10Out, @RackStatus)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RackBarcode", rackObject.RackBarcode);
                        command.Parameters.AddWithValue("@NGType", rackObject.NGType);
                        command.Parameters.AddWithValue("@RackDetails", rackObject.RackDetails);
                        command.Parameters.AddWithValue("@Bath1Temper", rackObject.Bath1_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath1ET1", rackObject.Bath1_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath1EH1", rackObject.Bath1_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath1ET2", rackObject.Bath1_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath1EH2", rackObject.Bath1_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath1In", rackObject.Bath1_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath1Out", rackObject.Bath1_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath2Temper", rackObject.Bath2_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath2ET1", rackObject.Bath2_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath2EH1", rackObject.Bath2_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath2ET2", rackObject.Bath2_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath2EH2", rackObject.Bath2_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath2In", rackObject.Bath2_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath2Out", rackObject.Bath2_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath3Temper", rackObject.Bath3_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath3ET1", rackObject.Bath3_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath3EH1", rackObject.Bath3_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath3ET2", rackObject.Bath3_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath3EH2", rackObject.Bath3_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath3In", rackObject.Bath3_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath3Out", rackObject.Bath3_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath4Temper", rackObject.Bath4_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath4ET1", rackObject.Bath4_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath4EH1", rackObject.Bath4_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath4ET2", rackObject.Bath4_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath4EH2", rackObject.Bath4_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath4In", rackObject.Bath4_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath4Out", rackObject.Bath4_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath5Temper", rackObject.Bath5_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath5ET1", rackObject.Bath5_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath5EH1", rackObject.Bath5_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath5ET2", rackObject.Bath5_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath5EH2", rackObject.Bath5_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath5In", rackObject.Bath5_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath5Out", rackObject.Bath5_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath6Temper", rackObject.Bath6_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath6ET1", rackObject.Bath6_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath6EH1", rackObject.Bath6_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath6ET2", rackObject.Bath6_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath6EH2", rackObject.Bath6_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath6In", rackObject.Bath6_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath6Out", rackObject.Bath6_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath7Temper", rackObject.Bath7_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath7ET1", rackObject.Bath7_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath7EH1", rackObject.Bath7_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath7ET2", rackObject.Bath7_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath7EH2", rackObject.Bath7_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath7In", rackObject.Bath7_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath7Out", rackObject.Bath7_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath8Temper", rackObject.Bath8_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath8ET1", rackObject.Bath8_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath8EH1", rackObject.Bath8_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath8ET2", rackObject.Bath8_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath8EH2", rackObject.Bath8_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath8In", rackObject.Bath8_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath8Out", rackObject.Bath8_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath9Temper", rackObject.Bath9_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath9ET1", rackObject.Bath9_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath9EH1", rackObject.Bath9_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath9ET2", rackObject.Bath9_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath9EH2", rackObject.Bath9_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath9In", rackObject.Bath9_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath9Out", rackObject.Bath9_Infor.TimeOut);
                        command.Parameters.AddWithValue("@Bath10Temper", rackObject.Bath10_Infor.BathTemper);
                        command.Parameters.AddWithValue("@Bath10ET1", rackObject.Bath10_Infor.Envir_T1);
                        command.Parameters.AddWithValue("@Bath10EH1", rackObject.Bath10_Infor.Envir_H1);
                        command.Parameters.AddWithValue("@Bath10ET2", rackObject.Bath10_Infor.Envir_T2);
                        command.Parameters.AddWithValue("@Bath10EH2", rackObject.Bath10_Infor.Envir_H2);
                        command.Parameters.AddWithValue("@Bath10In", rackObject.Bath10_Infor.TimeIn);
                        command.Parameters.AddWithValue("@Bath10Out", rackObject.Bath10_Infor.TimeOut);
                        command.Parameters.AddWithValue("@RackStatus", rackObject.RackStatus.ToString());
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex )
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }

        public static void EditRackObject(RackObject rackObject)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand())
                {
                    var condition = rackObject.Bath1_Infor.TimeIn.Year.ToString() + "-" + rackObject.Bath1_Infor.TimeIn.Month.ToString("D2") + "-" + rackObject.Bath1_Infor.TimeIn.Day.ToString("D2") + " " + rackObject.Bath1_Infor.TimeIn.Hour.ToString("D2") + ":" + rackObject.Bath1_Infor.TimeIn.Minute.ToString("D2");

                    command.Connection = connection;
                    command.CommandText = @"SET SQL_SAFE_UPDATES = 0; UPDATE " + TableName + " SET " +
                        "ng_type = @NGType, " +
                        "bath1_temper = @Bath1Temper, " +
                        "bath1_envir_temp1 = @Bath1ET1, " +
                        "bath1_envir_humi1 = @Bath1EH1, " +
                        "bath1_envir_temp2 = @Bath1ET2, " +
                        "bath1_envir_humi2 = @Bath1EH2, " +
                        "bath1_time_in = @Bath1In, " +
                        "bath1_time_out = @Bath1Out, "+
                        "bath2_temper = @Bath2Temper, "+
                        "bath2_envir_temp1 = @Bath2ET1, " +
                        "bath2_envir_humi1 = @Bath2EH1, " +
                        "bath2_envir_temp2 = @Bath2ET2, " +
                        "bath2_envir_humi2 = @Bath2EH2, " +
                        "bath2_time_in = @Bath2In, " +
                        "bath2_time_out = @Bath2Out, "+
                        "bath3_temper = @Bath3Temper, "+
                        "bath3_envir_temp1 = @Bath3ET1, " +
                        "bath3_envir_humi1 = @Bath3EH1, " +
                        "bath3_envir_temp2 = @Bath3ET2, " +
                        "bath3_envir_humi2 = @Bath3EH2, " +
                        "bath3_time_in = @Bath3In, " +
                        "bath3_time_out = @Bath3Out, "+
                        "bath4_temper = @Bath4Temper, "+
                        "bath4_envir_temp1 = @Bath4ET1, " +
                        "bath4_envir_humi1 = @Bath4EH1, " +
                        "bath4_envir_temp2 = @Bath4ET2, " +
                        "bath4_envir_humi2 = @Bath4EH2, " +
                        "bath4_time_in = @Bath4In, " +
                        "bath4_time_out = @Bath4Out, "+
                        "bath5_temper = @Bath5Temper, "+
                        "bath5_envir_temp1 = @Bath5ET1, " +
                        "bath5_envir_humi1 = @Bath5EH1, " +
                        "bath5_envir_temp2 = @Bath5ET2, " +
                        "bath5_envir_humi2 = @Bath5EH2, " +
                        "bath5_time_in = @Bath5In, " +
                        "bath5_time_out = @Bath5Out, "+
                        "bath6_temper = @Bath6Temper, "+
                        "bath6_envir_temp1 = @Bath6ET1, " +
                        "bath6_envir_humi1 = @Bath6EH1, " +
                        "bath6_envir_temp2 = @Bath6ET2, " +
                        "bath6_envir_humi2 = @Bath6EH2, " +
                        "bath6_time_in = @Bath6In, " +
                        "bath6_time_out = @Bath6Out, "+
                        "bath7_temper = @Bath7Temper, "+
                        "bath7_envir_temp1 = @Bath7ET1, " +
                        "bath7_envir_humi1 = @Bath7EH1, " +
                        "bath7_envir_temp2 = @Bath7ET2, " +
                        "bath7_envir_humi2 = @Bath7EH2, " +
                        "bath7_time_in = @Bath7In, " +
                        "bath7_time_out = @Bath7Out, "+
                        "bath8_temper = @Bath8Temper, "+
                        "bath8_envir_temp1 = @Bath8ET1, " +
                        "bath8_envir_humi1 = @Bath8EH1, " +
                        "bath8_envir_temp2 = @Bath8ET2, " +
                        "bath8_envir_humi2 = @Bath8EH2, " +
                        "bath8_time_in = @Bath8In, " +
                        "bath8_time_out = @Bath8Out, "+
                        "bath9_temper = @Bath9Temper, "+
                        "bath9_envir_temp1 = @Bath9ET1, " +
                        "bath9_envir_humi1 = @Bath9EH1, " +
                        "bath9_envir_temp2 = @Bath9ET2, " +
                        "bath9_envir_humi2 = @Bath9EH2, " +
                        "bath9_time_in = @Bath9In, " +
                        "bath9_time_out = @Bath9Out, "+
                        "bath10_temper = @Bath10Temper, "+
                        "bath10_envir_temp1 = @Bath10ET1, " +
                        "bath10_envir_humi1 = @Bath10EH1, " +
                        "bath10_envir_temp2 = @Bath10ET2, " +
                        "bath10_envir_humi2 = @Bath10EH2, " +
                        "bath10_time_in = @Bath10In, " +
                        "bath10_time_out = @Bath10Out, "+
                        "rack_status = @RackStatus "+
                        "WHERE (rack_barcode = @RackBarcode AND DATE_FORMAT(bath1_time_in, '%Y-%m-%d %H:%i') = '"+condition+"')";
                    command.Parameters.AddWithValue("@RackBarcode", rackObject.RackBarcode);
                    command.Parameters.AddWithValue("@NGType", rackObject.NGType);
                    command.Parameters.AddWithValue("@Bath1Temper", rackObject.Bath1_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath1ET1", rackObject.Bath1_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath1EH1", rackObject.Bath1_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath1ET2", rackObject.Bath1_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath1EH2", rackObject.Bath1_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath1In", rackObject.Bath1_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath1Out", rackObject.Bath1_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath2Temper", rackObject.Bath2_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath2ET1", rackObject.Bath2_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath2EH1", rackObject.Bath2_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath2ET2", rackObject.Bath2_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath2EH2", rackObject.Bath2_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath2In", rackObject.Bath2_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath2Out", rackObject.Bath2_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath3Temper", rackObject.Bath3_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath3ET1", rackObject.Bath3_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath3EH1", rackObject.Bath3_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath3ET2", rackObject.Bath3_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath3EH2", rackObject.Bath3_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath3In", rackObject.Bath3_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath3Out", rackObject.Bath3_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath4Temper", rackObject.Bath4_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath4ET1", rackObject.Bath4_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath4EH1", rackObject.Bath4_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath4ET2", rackObject.Bath4_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath4EH2", rackObject.Bath4_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath4In", rackObject.Bath4_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath4Out", rackObject.Bath4_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath5Temper", rackObject.Bath5_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath5ET1", rackObject.Bath5_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath5EH1", rackObject.Bath5_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath5ET2", rackObject.Bath5_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath5EH2", rackObject.Bath5_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath5In", rackObject.Bath5_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath5Out", rackObject.Bath5_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath6Temper", rackObject.Bath6_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath6ET1", rackObject.Bath6_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath6EH1", rackObject.Bath6_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath6ET2", rackObject.Bath6_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath6EH2", rackObject.Bath6_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath6In", rackObject.Bath6_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath6Out", rackObject.Bath6_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath7Temper", rackObject.Bath7_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath7ET1", rackObject.Bath7_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath7EH1", rackObject.Bath7_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath7ET2", rackObject.Bath7_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath7EH2", rackObject.Bath7_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath7In", rackObject.Bath7_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath7Out", rackObject.Bath7_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath8Temper", rackObject.Bath8_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath8ET1", rackObject.Bath8_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath8EH1", rackObject.Bath8_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath8ET2", rackObject.Bath8_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath8EH2", rackObject.Bath8_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath8In", rackObject.Bath8_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath8Out", rackObject.Bath8_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath9Temper", rackObject.Bath9_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath9ET1", rackObject.Bath9_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath9EH1", rackObject.Bath9_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath9ET2", rackObject.Bath9_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath9EH2", rackObject.Bath9_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath9In", rackObject.Bath9_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath9Out", rackObject.Bath9_Infor.TimeOut);
                    command.Parameters.AddWithValue("@Bath10Temper", rackObject.Bath10_Infor.BathTemper);
                    command.Parameters.AddWithValue("@Bath10ET1", rackObject.Bath10_Infor.Envir_T1);
                    command.Parameters.AddWithValue("@Bath10EH1", rackObject.Bath10_Infor.Envir_H1);
                    command.Parameters.AddWithValue("@Bath10ET2", rackObject.Bath10_Infor.Envir_T2);
                    command.Parameters.AddWithValue("@Bath10EH2", rackObject.Bath10_Infor.Envir_H2);
                    command.Parameters.AddWithValue("@Bath10In", rackObject.Bath10_Infor.TimeIn);
                    command.Parameters.AddWithValue("@Bath10Out", rackObject.Bath10_Infor.TimeOut);
                    command.Parameters.AddWithValue("@RackStatus", rackObject.RackStatus.ToString());
                    int r = command.ExecuteNonQuery();
                    Console.WriteLine($"rows effects = {r}");
                }
            }
        }

        public static void DeleteRackObject(RackObject rackObject)
        {

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM rack_table WHERE RackBarcode = @RackBarcode AND bath1_time_in = @Bath1In AND ng_type = @NGType";
                    command.Parameters.AddWithValue("@RackBarcode", rackObject.RackBarcode);
                    command.Parameters.AddWithValue("@NGType", rackObject.NGType);
                    command.Parameters.AddWithValue("@Bath1In", rackObject.Bath1_Infor.TimeIn);
                }
            }
        }

        public static DataTable Upload_Rows(bool init = false)
        {
            string query = "SELECT * FROM "+TableName+" ORDER BY bath1_time_in DESC LIMIT 1000";
            var dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            {
                dataTable = new DataTable();
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rack_barcode"></param>
        /// <param name="dateTime"></param>
        /// <param name="Type"></param>
        /// <param name="mode">Lọc dữ liệu cần tìm kiếm</param>
        /// <returns></returns>
        public static DataTable GetFilterTable(string rack_barcode = "", DateTime dateTime = new DateTime(), string Type = "",ModeFilter mode = ModeFilter.None)
        {
            var dataTable = new DataTable();
            string query = "SELECT * FROM "+TableName+" WHERE";
            try
            {
                if(mode != ModeFilter.None)
                {
                    if(mode == ModeFilter.ByBarcode) 
                    {
                        query += " rack_barcode = @RackBarcode";

                        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Set the parameter values
                            command.Parameters.AddWithValue("@RackBarcode", rack_barcode);
                           
                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                        }
                    }
                    else if (mode == ModeFilter.ByDate) 
                    {
                        query += " DATE(bath1_time_in) = @Bath1In";
                        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Set the parameter values
                            //command.Parameters.AddWithValue("@RackBarcode", rack_barcode);
                            command.Parameters.AddWithValue("@Bath1In", dateTime);
                            //command.Parameters.AddWithValue("@ng_type", "value3");

                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                        }
                    }
                    else if(mode == ModeFilter.ByType)
                    {
                        query += " ng_type = @NG_Type";
                        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Set the parameter values
                            //command.Parameters.AddWithValue("@RackBarcode", rack_barcode);
                            //command.Parameters.AddWithValue("@Bath1In", "value2");
                            command.Parameters.AddWithValue("@NG_Type", Type);

                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                        }
                    }
                    else if(mode == ModeFilter.All) 
                    {
                        query += " rack_barcode = @RackBarcode AND ng_type = @NG_Type";
                        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Set the parameter values
                            command.Parameters.AddWithValue("@RackBarcode", rack_barcode);
                            //command.Parameters.AddWithValue("@Bath1In", "value2");
                            command.Parameters.AddWithValue("@NG_Type", Type);

                            dataTable = new DataTable();
                            adapter.Fill(dataTable);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return dataTable;
        }
    }
    public enum ModeFilter
    {
        ByBarcode,
        ByDate,
        ByType,
        All,
        None
         
    }
}
