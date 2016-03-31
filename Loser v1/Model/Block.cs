using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Block
     {
          private int SoulId;
          private int BlockedSoulId;

          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }

          public int _BlockedSoulId
          {
               get { return BlockedSoulId; }
               set { BlockedSoulId = value; }
          }
     }
}
