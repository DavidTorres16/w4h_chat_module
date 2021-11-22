using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace work4hours_modules_backend.Models
{
    public class BaseDatos
    {
        MySqlConnection connection;

        public BaseDatos()
        {
            connection = new MySqlConnection("datasource= bajo6jvfjmaaa56nkxnz-mysql.services.clever-cloud.com;port=3306;username=umpc4kxiu8b4wjbn;password=mY26rlcKvrE9V12Uq4bI;database=bajo6jvfjmaaa56nkxnz");

        }

        public string ejecutarSQL(string sql)
        {
            string result = "";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int countResult = cmd.ExecuteNonQuery();

                if (countResult > -1)
                {
                    result = "Correcto";
                }
                else
                {
                    result = "Incorrecto";
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
                connection.Close();
                adapter.Dispose();
            }
            catch
            {
                dt = null;
            }
            return dt;
        }
    }
}
