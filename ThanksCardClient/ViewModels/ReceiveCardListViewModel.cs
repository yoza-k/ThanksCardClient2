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
    internal class ReceiveCardListViewModel : BindableBase
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

        public ReceiveCardListViewModel(IRegionManager regionManager)
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

        #region  BackCommand //1つ前のページへ画面遷移
        private DelegateCommand _BackCommand;
        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));
        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardMenu));
        }
        #endregion
    }
}
