using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class CaseVideo
     {
          private int CaseId;
          private int SoulId;
          private string Name;
          private string ContentType;
          private byte[] Data;

          public int _CaseId
          {
               get { return CaseId; }
               set { CaseId = value; }
          }

          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }

          public string _Name
          {
               get { return Name; }
               set { Name = value; }
          }

          public string _ContentType
          {
               get { return ContentType; }
               set { ContentType = value; }
          }
          public byte[] _Data
          {
               get { return Data; }
               set { Data = value; }
          }
     }
}
