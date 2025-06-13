using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Helpers.UI
{
    public interface IToastControlContainer
    {
        void Show(TimeSpan sec, string text);
    }
}
