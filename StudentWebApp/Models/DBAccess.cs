using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace StudentWebApp.Models
{
    public class DBAccess
    {
        //contains the information of server and data(connection information)
        static string constr = @"Data Source=DESKTOP-H5AAPPB; initial catalog=StudentDB;integrated security=true";//connection string
        static string constcourse = @"Data Source=DESKTOP-H5AAPPB; initial catalog=StudentDB;integrated security=true";//connection string
        public SqlConnection con = new SqlConnection(constr);
        public SqlConnection concourse = new SqlConnection(constcourse);
        public SqlCommand cmd = null;
        public SqlCommand cmdcourse = null;
        public void openConnection() {
            if (con.State == ConnectionState.Closed) {
                con.Open(); 
            }
        }

        public void closeConnection()
        {
            if(con.State == ConnectionState.Open) {
                con.Close();
            }
        }

        public void InsertUpdateDelete(string query)
        {
            cmd=new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

        }

        //for course

        public void openConnectionc()
        {
            if (concourse.State == ConnectionState.Closed)
            {
                concourse.Open();
            }
        }

        public void closeConnectionc()
        {
            if (concourse.State == ConnectionState.Open)
            {
                concourse.Close();
            }
        }

        public void InsertUpdateDeletec(string query)
        {
            cmdcourse = new SqlCommand(query, concourse);
            cmdcourse.ExecuteNonQuery();

        }
    }
}