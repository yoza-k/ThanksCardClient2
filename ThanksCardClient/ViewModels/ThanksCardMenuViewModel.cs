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

        #region  ManualCommand //マニュアルへ画面遷移
        private DelegateCommand _ManualCommand;
        public DelegateCommand ManualCommand =>
            _ManualCommand ?? (_ManualCommand = new DelegateCommand(ExecuteManualCommand));
        void ExecuteManualCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Manual));
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

        #region  GoodCardListCommand //Goodカード一覧へ画面遷移
        private DelegateCommand _GoodCardListCommand;
        public DelegateCommand GoodCardListCommand =>
            _GoodCardListCommand ?? (_GoodCardListCommand = new DelegateCommand(ExecuteGoodCardListCommand));
        void ExecuteGoodCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.GoodCardList));
        }
        #endregion

        #region  ReceiveCommentListCommand //受け取ったコメント一覧へ画面遷移
        private DelegateCommand _ReceiveCommentListCommand;
        public DelegateCommand ReceiveCommentListCommand =>
            _ReceiveCommentListCommand ?? (_ReceiveCommentListCommand = new DelegateCommand(ExecuteReceiveCommentListCommand));
        void ExecuteReceiveCommentListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ReceiveCommentList));
        }
        #endregion

        #region  SendCommentListCommand //送ったコメント一覧へ画面遷移
        private DelegateCommand _SendCommentListCommand;
        public DelegateCommand SendCommentListCommand =>
            _SendCommentListCommand ?? (_SendCommentListCommand = new DelegateCommand(ExecuteSendCommentListCommand));
        void ExecuteSendCommentListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.SendCommentList));
        }
        #endregion
    }
}
