using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Comment
     {
          private int CommentId;
          private string Description;
          private string Type;
          private string PostDate;
          private string PostTime;
          private int SoulId;
          private int CaseId;

          public int _CommentId
          {
               get { return CommentId; }
          }

          public string _Description
          {
               get { return Description; }
               set { Description = value; }
          }

          public string _Type
          {
               get { return Type; }
               set { Type = value; }
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

          public int _CaseId
          {
               get { return CaseId; }
               set { CaseId = value; }
          }
     }
}
