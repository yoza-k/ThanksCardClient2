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
namespace ThanksCardClient.ViewModels
{
    internal class MainMenuViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public MainMenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region  ThanksCardCreateCommand //カード作成画面へ移動
        private DelegateCommand _ThanksCardCreateCommand;
        public DelegateCommand ThanksCardCreateCommand =>
            _ThanksCardCreateCommand ?? (_ThanksCardCreateCommand = new DelegateCommand(ExecuteThanksCardCreateCommand));

        void ExecuteThanksCardCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  ThanksCardMenuCommand //カードメニューへ移動
        private DelegateCommand _ThanksCardMenuCommand;
        public DelegateCommand ThanksCardMenuCommand =>
            _ThanksCardMenuCommand ?? (_ThanksCardMenuCommand = new DelegateCommand(ExecuteThanksCardMenuCommand));

        void ExecuteThanksCardMenuCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardMenu));
        }
        #endregion

        #region  LogoutCommand　//ログアウトし、ログイン画面へ戻る
        private DelegateCommand _LogoutCommand;
        public DelegateCommand LogoutCommand =>
            _LogoutCommand ?? (_LogoutCommand = new DelegateCommand(ExecuteLogoutCommand));

        void ExecuteLogoutCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon2));
        }
        #endregion

        #region SearchWordProperty
        private string _SearchWord;
        public string SearchWord
        {
            get { return _SearchWord; }
            set
            {
                SetProperty(ref _SearchWord, value);
                System.Diagnostics.Debug.WriteLine("SearchWord: " + this.SearchWord); //動作確認用。本来はこの行は必要ありません。
            }
        }
        #endregion
        //#region SearchThanksCardProperty
        //private SearchThanksCard _SearchThanksCard;
        //public SearchThanksCard SearchThanksCard
        //{
        //    get { return _SearchThanksCard; }
        //    set { SetProperty(ref _SearchThanksCard, value); }
        //}
        //#endregion
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
        //#region SubmitSearchCommand
        //private DelegateCommand<string> _SubmitSearchCommand;
        //public DelegateCommand<string> SubmitSearchCommand =>
        //    _SubmitSearchCommand ?? (_SubmitSearchCommand = new DelegateCommand<string>(ExecuteSubmitSearchCommand));
        //async void ExecuteSubmitSearchCommand(string parameter)
        //{
        //    ThanksCard thanksCard = new ThanksCard();
        //    this.SearchThanksCard = new SearchThanksCard();
        //    this.SearchThanksCard.SearchWord = parameter;
        //    ThanksCards = await thanksCard.PostSearchThanksCardsAsync(SearchThanksCard);
        //}
        //#endregion
    }
}