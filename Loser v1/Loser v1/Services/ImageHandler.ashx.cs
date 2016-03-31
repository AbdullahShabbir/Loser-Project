using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Loser_v1.Services
{
     /// <summary>
     /// Summary description for ImageHandler
     /// </summary>
     public class ImageHandler : IHttpHandler
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public void ProcessRequest(HttpContext context)
          {
               try
               {
                    int count = 0;

                    SqlCommand cmd = new SqlCommand("sp_GetCaseImagebyCaseID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", context.Request.QueryString["case_id"]);

                    con.Open();

                    SqlDataReader da = cmd.ExecuteReader();
                    
                    while (da.Read())
                    {
                         context.Response.ContentType = "image/jpg";
                         context.Response.BinaryWrite((byte[])da[count]);

                         count++;
                    }
                    if (da != null)
                         da.Close();
               }
               finally
               {
                    con.Close();
               }
          }

          public bool IsReusable
          {
               get
               {
                    return false;
               }
          }
     }
}