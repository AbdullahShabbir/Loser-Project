using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class CaseImage
     {
          private int CaseId;
          private int SoulId;
          private byte[] Image;

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

          public byte[] _Image
          {
               get { return Image; }
               set { Image = value; }
          }
     }
}
