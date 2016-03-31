using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using System.Data.SqlClient;
using BussinessLogic;

namespace Loser_v1.Webpages
{
     public partial class Your_Stats : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (!IsPostBack)
               {
                    if (Session["SoulName"] == null && Session["SoulId"] == null)
                    {
                         Response.Redirect("../Webpages/My_Home.aspx");
                    }
                    else
                    {
                         StatsLogic statsLogic = new StatsLogic();
                         SqlDataAdapter myAdapter;
                         DataSet dataSet = new DataSet();

                         myAdapter = new SqlDataAdapter();

                         myAdapter = statsLogic.GetCategoryStatsbyIDBL(int.Parse(Session["SoulId"].ToString()));

                         cht_PieCategory.Series[0].XValueMember = "category";
                         cht_PieCategory.Series[0].YValueMembers = "total";
                         cht_PieCategory.Series[0].Label = "#PERCENT{P2}";
                         cht_PieCategory.Series[0].LegendText = "#VALX";

                         myAdapter.Fill(dataSet, "Category Stats");

                         cht_PieCategory.DataSource = dataSet.Tables["Category Stats"];
                         cht_PieCategory.DataBind();

                         //////////////////////////////////////////////////////////

                         myAdapter = new SqlDataAdapter();

                         myAdapter = statsLogic.GetTotalCategoryStatsbyIDBL(int.Parse(Session["SoulId"].ToString()));

                         cht_BarCategory.Series[0].XValueMember = "category";
                         cht_BarCategory.Series[0].YValueMembers = "total";

                         myAdapter.Fill(dataSet, "Total Category Stats");
                         cht_BarCategory.DataSource = dataSet.Tables["Total Category Stats"];
                         cht_BarCategory.DataBind();

                         //////////////////////////////////////////////////////////

                         myAdapter = new SqlDataAdapter();

                         myAdapter = statsLogic.GetSecurityStatsbyIDBL(int.Parse(Session["SoulId"].ToString()));

                         cht_PieSecurity.Series[0].XValueMember = "security";
                         cht_PieSecurity.Series[0].YValueMembers = "total";
                         cht_PieSecurity.Series[0].Label = "#PERCENT{P2}";
                         cht_PieSecurity.Series[0].LegendText = "#VALX";

                         myAdapter.Fill(dataSet, "Security Stats");

                         cht_PieSecurity.DataSource = dataSet.Tables["Security Stats"];
                         cht_PieSecurity.DataBind();

                         //////////////////////////////////////////////////////////

                         myAdapter = new SqlDataAdapter();

                         myAdapter = statsLogic.GetRatingStatsbyIDBL(int.Parse(Session["SoulId"].ToString()));

                         cht_PieRating.Series[0].XValueMember = "category_name";
                         cht_PieRating.Series[0].YValueMembers = "points";
                         cht_PieRating.Series[0].Label = "#PERCENT{P2}";
                         cht_PieRating.Series[0].LegendText = "#VALX";

                         myAdapter.Fill(dataSet, "Rating Stats");

                         cht_PieRating.DataSource = dataSet.Tables["Rating Stats"];
                         cht_PieRating.DataBind();

                         //////////////////////////////////////////////////////////

                         myAdapter = new SqlDataAdapter();

                         myAdapter = statsLogic.GetTotalRatingStatsbyIDBL(int.Parse(Session["SoulId"].ToString()));

                         cht_BarRating.Series[0].XValueMember = "category_name";
                         cht_BarRating.Series[0].YValueMembers = "points";

                         myAdapter.Fill(dataSet, "Total Rating Stats");

                         cht_BarRating.DataSource = dataSet.Tables["Total Rating Stats"];
                         cht_BarRating.DataBind();
                    }
               }
          }
     }
}