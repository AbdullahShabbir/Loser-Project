using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Case
     {
          private int CaseId;
          private string Title;
          private string Description;
          private string Category;
          private string PostDate;
          private string PostTime;
          private int SoulId;
          private string Security;

          public int _CaseId
          {
               get { return CaseId; }        //I changed it from soulid to CaseId
          }

          public string _Title
          {
               get { return Title; }
               set { Title = value; }
          }

          public string _Description
          {
               get { return Description; }
               set { Description = value; }
          }

          public string _Category
          {
               get { return Category; }
               set { Category = value; }
          }

          public string _PostDate
          {
               get { return PostDate; }
               set { PostDate = value; }
          }

          public string _PostTime
          {
               get { return PostTime; }
               set { PostTime = value; }
          }
          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }

          public string _Security
          {
               get { return Security; }
               set { Security = value; }
          }
     }
}
