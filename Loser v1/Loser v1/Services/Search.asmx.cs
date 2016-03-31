using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BussinessLogic;

namespace Loser_v1.Services
{
     /// <summary>
     /// Summary description for Search
     /// </summary>
     [WebService(Namespace = "http://tempuri.org/")]
     [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
     [System.ComponentModel.ToolboxItem(false)]
     [System.Web.Script.Services.ScriptService]
     // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     // [System.Web.Script.Services.ScriptService]
     public class Search : System.Web.Services.WebService
     {

          [WebMethod]
          public List<String> getName()
          {
               UserLogic myLogic = new UserLogic();

               List<String> UserName = myLogic.GetUserNameBL();

               return UserName;
          }
     }
}
