using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices
{
    public class CodeRepository : ICodeRepository
    {
      #region Member Variables
      private ChatlyEntities context = null;
      #endregion

      #region Constructor

      public CodeRepository()
      {
          context = new ChatlyEntities(); //Wrap and instantiate the ObjectContext
      }

      #endregion
      #region Messages

      public Codes GetCode(int codeId)
      {

         //Apply LINQ get the specific bookmark based in id
          var code = from b in context.Codes
                    where b.Id == codeId
                         select b;
          return code.FirstOrDefault();

      }

      public IEnumerable<Codes> GetCodeList()
      {
          return context.Codes.ToList();
      }

      public void AddCode(Codes code)
      {
          context.Codes.Add(code);
          context.SaveChanges(); //Persist changes to DB
      }

      public void UpdateCode(Codes code)
      {
          Codes existingCode = GetCode(code.Id);
          context.Entry(existingCode).CurrentValues.SetValues(code);
          context.SaveChanges(); //Persist changes to DB
      }

      public void DeleteCode(Codes code)
      {
          Codes existingCode = GetCode(code.Id);
          context.Codes.Remove(existingCode);
          context.SaveChanges(); //Persist changes to DB
      }

      #endregion
    }
}