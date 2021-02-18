using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kosis
{
    class Program
    {
        static string connectionString = "server = localhost; uid = sa; pwd = 1111; database = PrivateData;";
        //static string connectionString = "server = 10.200.5.73,1477; uid = savewind; pwd = savewind11!; database = CENTER_RAW;";
        static void Main(string[] args)
        {
            employment employment = new employment();
            employment.getEmployment();

            work work = new work();
            work.getWork();
        }

        public static void insert(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataSet selectDS(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter _SqlDataAdapter = new SqlDataAdapter();
                _SqlDataAdapter.SelectCommand = new SqlCommand(query, conn);
                _SqlDataAdapter.Fill(ds);

                return ds;
            }
        }
    }
}
