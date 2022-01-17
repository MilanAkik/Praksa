using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.DataAccess
{
    public static class SQLDataAccess
    {

        public static string GetConnectionString(string name= "Ugovori_Orion")
        {
            ConnectionStringSettingsCollection cssc = ConfigurationManager.ConnectionStrings;
            String s = cssc[name].ConnectionString;
            return s;
            //return @"Data Source = MILAN-PC\SQLEXPRESS01; Initial Catalog = Ugovori_Orion; Integrated Security = True";
            //return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ugovori_Orion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static int LoadInt(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return (int)(cnn.Query<int>(sql).First());
            }
        }

        public static T LoadLast<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).Last();
            }
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static int DaleteData(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql);
            }
        }

        public static int UpdateData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

    }
}
//<connectionStrings>
//  <add name = "Ugovori_Orion" connectionString="Data Source=MILAN-PC\SQLEXPRESS01;Initial Catalog=Ugovori_Orion;Integrated Security=True"/>
//</connectionStrings>