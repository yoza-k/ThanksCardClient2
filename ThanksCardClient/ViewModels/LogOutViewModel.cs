#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Model;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    internal class LogOutViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public LogOutViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region  Logon2Command //Logon2へ画面遷移
        private DelegateCommand _Logon2Command;
        public DelegateCommand Logon2Command =>
            _Logon2Command ?? (_Logon2Command = new DelegateCommand(ExecuteLogon2Command));
        void ExecuteLogon2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon2 ));
        }
        #endregion

        

    }

}
