using System;
using System.Data;
using System.Data.SqlClient;

namespace ReadPLC
{
    class MesClass
    {
        static SqlConnection sqlConnection1 = new SqlConnection(Properties.Settings.Default.sqlConnection);
        static SqlCommand cmd = new SqlCommand();
        static DataTable dt;

        public string Get_Part(string PalletSerial)
        {
            DataSet ds = new DataSet();
            string dblResult = "";

            //read through each record - if it is not transID=1 then update processed to 2
            try
            {
                //open database read to write to
                string strSearch = "SELECT Item_Nbr FROM ISS_cfg_Item_Option WHERE Option_Nbr=1 AND Value = '" + PalletSerial + "'";

                using (SqlConnection cnn = new SqlConnection(Properties.Settings.Default.sqlConnection))
                {
                    cnn.Open();

                    //the search string was selected
                    SqlCommand cmd = new SqlCommand(strSearch, cnn);

                    //populate the list
                    SqlDataAdapter adapt = new SqlDataAdapter(strSearch, cnn);
                    dt = new DataTable();

                    //get the data
                    adapt.Fill(dt);

                    //lop through - adding found SLOC to the string
                    foreach (DataRow dr in dt.Rows)
                    {
                        dblResult = Convert.ToString(dr["Item_Nbr"]);
                    }

                    //return value
                    return dblResult;
                }

            }
            catch (Exception e)
            {
                sqlConnection1.Close();
                return e.Message;
            }
        }
    }
}
