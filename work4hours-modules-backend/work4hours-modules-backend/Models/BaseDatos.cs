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
            connection = new MySqlConnection("datasource=b2xtib5hykquk9s3mvho-mysql.services.clever-cloud.com; port=3306; username=uuyojgefw1stqwjc;password=bBFiQh58tyncaik1K6CI;database=b2xtib5hykquk9s3mvho");

        }

        public bool ejecutarSQL(string sql)
        {
            bool result = false;
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int countResult = cmd.ExecuteNonQuery();

                if (countResult > -1)
                {
                    result = true;
                }
                connection.Close();

            }
            catch (Exception ex)
            {
                result = false;
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
                return null;
            }
            return dt;
        }
    }
}
