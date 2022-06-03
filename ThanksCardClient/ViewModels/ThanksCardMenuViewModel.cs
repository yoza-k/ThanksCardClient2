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
    internal class ThanksCardMenuViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public ThanksCardMenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region  MainMenuCommand //MainMenuへ画面遷移
        private DelegateCommand _MainMenuCommand;
        public DelegateCommand MainMenuCommand =>
            _MainMenuCommand ?? (_MainMenuCommand = new DelegateCommand(ExecuteMainMenuCommand));
        void ExecuteMainMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MainMenu));
        }
        #endregion

        #region  ReceiveCardListCommand //受信カード一覧へ画面遷移
        private DelegateCommand _ReceiveCardListCommand;
        public DelegateCommand ReceiveCardListCommand =>
            _ReceiveCardListCommand ?? (_ReceiveCardListCommand = new DelegateCommand(ExecuteReceiveCardListCommand));
        void ExecuteReceiveCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ReceiveCardList));
        }
        #endregion

        #region  SendCardListCommand //送信カード一覧へ画面遷移
        private DelegateCommand _SendCardListCommand;
        public DelegateCommand SendCardListCommand =>
            _SendCardListCommand ?? (_SendCardListCommand = new DelegateCommand(ExecuteSendCardListCommand));
        void ExecuteSendCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SendCardList));
        }
        #endregion
    }
}
