using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices
{
    public interface ICodeRepository
    {
        Codes GetCode(int codeId);
        IEnumerable<Codes> GetCodeList();
        void AddCode(Codes code);
        void UpdateCode(Codes code);
        void DeleteCode(Codes code);
    }
}