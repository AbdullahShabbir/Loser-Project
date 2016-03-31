using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace BussinessLogic
{
     public class BlockLogic
     {
          public bool IsBlockedBL(Block myBlock)
          {
               try
               {
                    BlockDA blockDA = new BlockDA();
                    return blockDA.IsBlockDA(myBlock);
               }
               catch
               {
                    throw;
               }
          }

          public int BlockUserBL(Block myBlock)
          {
               try
               {
                    BlockDA blockDA = new BlockDA();
                    return blockDA.BlockUserDA(myBlock);
               }
               catch
               {
                    throw;
               }
          }

          public int UnBlockUserBL(Block myBlock)
          {
               try
               {
                    BlockDA blockDA = new BlockDA();
                    return blockDA.UnBlockUserDA(myBlock);
               }
               catch
               {
                    throw;
               }
          }
     }
}
