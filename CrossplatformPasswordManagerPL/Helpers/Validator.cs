using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Helpers
{
    public static class Validator
    {
        static public bool ValidateText(string Text)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return true;
            }
            return false;
        }
    }
}
