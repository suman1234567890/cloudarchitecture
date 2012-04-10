using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

class insertIntoDatabase
{
    private string szData;

    public insertIntoDatabase(String result)
    {
        // TODO: Complete member initialization
            

        try
        {

            string connStr = "server=172.16.52.59;port=3306;user=root;database=oas;password='s';";

            MySqlCommand cmd;
            MySqlDataReader rdr;
            string sql = "";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            sql = "insert into result values(@results)";

            cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@results", result);
                
            //richTextBox2.Text = coun;
            rdr = cmd.ExecuteReader();

            rdr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}