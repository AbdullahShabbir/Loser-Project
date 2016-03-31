using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class User
     {
          private string SoulId;
          private string SoulName;
          private string Email;
          private string Password;

          public string _SoulId 
          {
               get { return SoulId; }
          }

          public string _SoulName
          {
               get  { return SoulName; }
               set  { SoulName = value; }
          }

          public string _Email
          {
               get  { return Email; }
               set  { Email = value; }
          }

          public string _Password
          {
               get  { return Password; }
               set  { Password = value; }
          }
     }
}
