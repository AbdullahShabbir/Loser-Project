using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Follow
     {
          private int SoulId;
          private int FriendSoulId;

          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }

          public int _FriendSoulId
          {
               get { return FriendSoulId; }
               set { FriendSoulId = value; }
          }
     }
}
