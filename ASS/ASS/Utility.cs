using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ASS
{
    class Utility
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        public static SqlConnection OpenDB()
        {
            con= new SqlConnection (@"Data Source=DESKTOP-TUG480A;Initial Catalog=QLSViennn;User ID=sa;Password=haiquang789");
            return con;
        }
        public static void OpenConnection ()
            {
            string sql = @"Data Source=DESKTOP-TUG480A;Initial Catalog=QLSViennn;User ID=sa;Password=haiquang789" ;
            try 
            {
                con = new SqlConnection (sql);
                con.Open();

            } catch(SqlException ex)
                {}
            }
        public static void Close()
        {
            con.Close();
            con.Dispose();
            con=null;
        }
        public static DataTable GetDataTable(string sql)
             {
                cmd = new SqlCommand(sql,con);
                da= new SqlDataAdapter();
                da.SelectCommand= cmd;
                DataTable table = new DataTable();
                da.Fill(table);
            return table;               
             }
        public static void Excute (String sql)
            { cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

            }
    }
}
