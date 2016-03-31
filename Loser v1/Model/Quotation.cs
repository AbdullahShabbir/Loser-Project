using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Quotation
     {
          private int QuoteId;
          private string Description;
          private int SoulId;

          public int _QuoteId
          {
               get { return QuoteId; }
          }

          public string _Description
          {
               get { return Description; }
               set { Description = value; }
          }

          public int _SoulId
          {
               get { return SoulId; }
               set { SoulId = value; }
          }
     }
}
