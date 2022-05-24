using GameTest.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GameTestAPI
{
    public class ParametersDH
    {

        MySqlConnection mysqlconnection;
        string ConnectionString;
        List<KeyValuePair<object, object>> parameters;

        public ParametersDH()
        {
            ConnectionString = "server=localhost;userid=root;password=pass;database=GameTestDB";
            mysqlconnection = new MySqlConnection(ConnectionString);
            parameters = new List<KeyValuePair<object, object>>();

        }
        public string GetDefaultParams()
        {
            string query = "SELECT Parameters FROM ConfigParams WHERE ProfileName=@ProfileName LIMIT 1";
            parameters.Clear();
            parameters.Add(new KeyValuePair<object, object>("@ProfileName", "Default"));
            var dt = ExecuteQuery(query, parameters);

            if ((dt != null) && (dt.Rows.Count > 0))
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        #region "SQL Functions"
        public DataTable ExecuteQuery(string query, List<KeyValuePair<object, object>> parameterList = null)
        {
            mysqlconnection.Open();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, mysqlconnection);

            if (parameterList != null)
            {
                foreach (KeyValuePair<object, object> kvp in parameterList)
                {
                    cmd.Parameters.AddWithValue(kvp.Key.ToString(), kvp.Value.ToString());
                }
            }

            dt.Load(cmd.ExecuteReader());
            mysqlconnection.Close();

            return dt;
        }

        public void ExecuteNonQuery(string query, List<KeyValuePair<object, object>> parameterList = null)
        {
            mysqlconnection.Open();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(query, mysqlconnection);

            if (parameterList != null)
            {
                foreach (KeyValuePair<object, object> kvp in parameterList)
                {
                    cmd.Parameters.AddWithValue(kvp.Key.ToString(), kvp.Value.ToString());
                }
            }

            cmd.ExecuteNonQuery();
            mysqlconnection.Close();
        }
        #endregion
    }
}
