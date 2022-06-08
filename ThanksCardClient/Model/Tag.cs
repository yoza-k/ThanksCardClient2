#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Tag :BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion
        #region CdProperty
        private long _Cd;
        public long Cd
        {
            get { return _Cd; }
            set { SetProperty(ref _Cd, value); }
        }
        #endregion
        #region NameProperty;
        private string _Name;   
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion
    }
}
