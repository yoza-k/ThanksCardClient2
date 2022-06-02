﻿#nullable disable
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
    internal class Logon2ViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

        #region ErrorMessage
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public Logon2ViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            // 開発中のみアカウントを admin/admin でセットしておく。
            this.User = new User();
            this.User.Name = "admin";
            this.User.Password = "admin";

        }

        #region LogonCommand
        private DelegateCommand _LogonCommand;
        public DelegateCommand LogonCommand =>
            _LogonCommand ?? (_LogonCommand = new DelegateCommand(ExecuteLogonCommandAsync));

        async void ExecuteLogonCommandAsync()
        {
            User authorizedUser = await this.User.LogonAsync();

            // authorizedUser が null でなければログオンに成功している。
            if (authorizedUser != null)
            {
                SessionService.Instance.IsAuthorized = true;
                SessionService.Instance.AuthorizedUser = authorizedUser;
                this.ErrorMessage = "";
                //this.regionManager.RequestNavigate("HeaderRegion", nameof(Views.Header));
                this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MainMenu));
                //this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));
            }
            else
            {
                this.ErrorMessage = "ログオンに失敗しました。";
            }
        }
        #endregion
    }
}
