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

        #region  BulletinBoardCommand //掲示板へ移動
        private DelegateCommand _BulletinBoardCommand;
        public DelegateCommand BulletinBoardCommand =>
            _BulletinBoardCommand ?? (_BulletinBoardCommand = new DelegateCommand(ExecuteBulletinBoardCommand));

        void ExecuteBulletinBoardCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.BulletinBoard));
        }
        #endregion

        #region  ManualCommand //マニュアル画面へ移動
        private DelegateCommand _ManualCommand;
        public DelegateCommand ManualCommand =>
            _ManualCommand ?? (_ManualCommand = new DelegateCommand(ExecuteManualCommand));

        void ExecuteManualCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Manual));
        }
        #endregion

        #region  AggregateCommand //集計画面へ移動
        private DelegateCommand _AggregateCommand;
        public DelegateCommand AggregateCommand =>
            _AggregateCommand ?? (_AggregateCommand = new DelegateCommand(ExecuteAggregateCommand));

        void ExecuteAggregateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Aggregate));
        }
        #endregion

        #region  AffiliationCommand //所属管理画面へ移動
        private DelegateCommand _AffiliationCommand;
        public DelegateCommand AffiliationCommand =>
            _AffiliationCommand ?? (_AffiliationCommand = new DelegateCommand(ExecuteAffiliationCommand));

        void ExecuteAffiliationCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Affiliation));
        }
        #endregion

        #region  CategoryCommand //カテゴリ管理画面へ移動
        private DelegateCommand _CategoryCommand;
        public DelegateCommand CategoryCommand =>
            _CategoryCommand ?? (_CategoryCommand = new DelegateCommand(ExecuteCategoryCommand));

        void ExecuteCategoryCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Category));
        }
        #endregion

        #region  LogOutCommand　//ログアウトへ移動
        private DelegateCommand _LogOutCommand;
        public DelegateCommand LogOutCommand =>
            _LogOutCommand ?? (_LogOutCommand = new DelegateCommand(ExecuteLogOutCommand));

        void ExecuteLogOutCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.LogOut));
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