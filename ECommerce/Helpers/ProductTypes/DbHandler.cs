using Dtos.ProductType;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace E_Comm.Helpers.ProductTypes
{
    public class DbHandler
    {
        public static string connectionString = string.Empty;
        public static List<KeyValPair> GetAllProducts()
        {
            try
            {
                List<KeyValPair> ProductTypes = new List<KeyValPair>();
                using (SqlConnection myCon = new SqlConnection(connectionString))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand("sp_fetchProductTypes", myCon))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(myCommand);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        ProductTypes = table.AsEnumerable().Select(r => new KeyValPair
                        {
                            Value = Convert.ToString(r.Field<int>("Id")),
                            Text = r.Field<string>("Name"),
                            UrlReferer = r.Field<string>("UrlReferer"),
                        }).ToList();

                        myCon.Close();
                    }
                }
                return ProductTypes;
            }
            catch(Exception)
            {
                return new List<KeyValPair>();
            }
        }

    }
}
