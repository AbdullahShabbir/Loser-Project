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
     /// Summary description for VideoHandler
     /// </summary>
     public class VideoHandler : IHttpHandler
     {
          SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DAconnectionstring"].ToString());

          public void ProcessRequest(HttpContext context)
          {
               try
               {
                    SqlCommand cmd = new SqlCommand("sp_GetCaseVideobyCaseID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CaseID", context.Request.QueryString["case_id"]);

                    con.Open();

                    SqlDataReader da = cmd.ExecuteReader(CommandBehavior.Default);
                    da.Read();
                    //if (da.HasRows)
                    //{
                         //while (da.Read())
                         //{
                              context.Response.Clear();
                              context.Response.Buffer = true;
                              context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + da["name"].ToString());
                              context.Response.ContentType = da["content_type"].ToString(); ;
                              context.Response.BinaryWrite((byte[])da["data"]);
                              context.Response.End();
                         //}
                    //}
                    
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