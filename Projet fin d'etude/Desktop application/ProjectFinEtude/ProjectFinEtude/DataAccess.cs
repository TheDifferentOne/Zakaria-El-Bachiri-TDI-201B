using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProjectFinEtude
{
    class DataAccess
    {
        public static string connectionString = @"Data Source =.\sqlexpress; DataBase=ProjetFinEtude; Integrated Security = True";
        

        public static DataTable getData(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                command.Connection = connection;
                table.Load(command.ExecuteReader());
            }
            catch (Exception error)
            {
                MessageBox.Show("The following error occured:" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { connection.Close(); }
            return table;
        }

        public static bool setData(SqlCommand command)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command.Connection = connection;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("The following error occured:" + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { connection.Close(); }
            return true;
        }
    }
}
