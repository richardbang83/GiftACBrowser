using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftACBrowser
{
    public interface CodeExtension
    {
        void Clear();
        void GotoLogin();
        void ExecuteCharge(params string[]codeText);

        string[] GetCodeStringList(string codeText);

    }
}
