using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossplatformPasswordManagerPL.Android.DI
{
    public class MainActivityProvider : IMainActivityProvider
    {
        public MainActivity Activity { get; set; }

        public MainActivityProvider(MainActivity activity)
        {
            Activity = activity;
        }

        public MainActivity GetMainActivity()
        {
            return Activity;
        }
    }
}
