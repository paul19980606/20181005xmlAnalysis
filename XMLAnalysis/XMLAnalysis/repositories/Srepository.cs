using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using XML_Analysis.Models;

namespace XMLAnalysis.repositories
{
    class Srepository
    {
       

        public SqlConnection connect()
        {
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Source\Repos\paul19980606\20181005xmlAnalysis\XMLAnalysis\XMLAnalysis\App_Data\Database1.mdf;Integrated Security=True";

            SqlConnection conn = new SqlConnection(strConn);

            return conn;
        }

        public void Sql_Insert( SqlConnection conn ,OpenData item)
        {
            conn.Open();

            String strInsert = "INSERT INTO STable (年度,案名,縣市 )VALUES(N'" + item.年度 + "',N'"+ item.案名 +"',N'"+ item.縣市 +"')";

            SqlCommand mySqlCmd = new SqlCommand(strInsert, conn);

            mySqlCmd.ExecuteNonQuery();
            conn.Close();

        }


    }
}
