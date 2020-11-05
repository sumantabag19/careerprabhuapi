using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerPrahuWebAPI.AppData
{

    //DataLayer activity start
    public class DataLayer
    {

        public DataSet GetData(string SpName, ref MySqlParameter[] param, string Connectionstring, ref string MessageOut)
        {
            //DataSet ds = SqlHelper1.ExecuteDataset(Connectionstring, SpName, param);
            DataSet ds = new DataSet();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Connectionstring;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SpName;
            cmd.CommandTimeout = 120000;
            cmd.Parameters.Clear();
            foreach (MySqlParameter p in param)
                cmd.Parameters.Add(p);
            MySqlDataAdapter Adp = new MySqlDataAdapter();
            Adp.SelectCommand = cmd;
            Adp.Fill(ds);
            cmd.Dispose();
            Adp.Dispose();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            MessageOut = param[0].Value.ToString();
            return ds;
        }
        public string SaveData(string SpName, ref MySqlParameter[] parameter, string Connectionstring)
        {
            MySqlHelper.ExecuteNonQuery(Connectionstring, SpName, parameter);
            return parameter[0].Value.ToString();
        }
        public string SaveDataret(string SpName, ref MySqlParameter[] parameter, string Connectionstring)
        {
            // OpenConnection()
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = Connectionstring;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SpName;
            cmd.CommandTimeout = 120000;
            cmd.Parameters.Clear();
            foreach (MySqlParameter p in parameter)
                cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            // CloseConnection()
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return parameter[0].Value.ToString();
        }
    }
    //End of data layer activity

    public class StateData : DataLayer
    {
        public DataSet GetState(string connectionname, ref string OutMessage)
        {
            DataSet ds = new DataSet();
            return ds;
        }
    }

}
