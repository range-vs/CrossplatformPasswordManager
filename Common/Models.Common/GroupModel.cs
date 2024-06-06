using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class GroupModel : ObservableObject
    {
        private long _id;
        private string _name;

        public long Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
