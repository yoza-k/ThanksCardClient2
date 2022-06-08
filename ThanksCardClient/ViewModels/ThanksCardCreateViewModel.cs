﻿#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Model;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    internal class ThanksCardCreateViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region FromUsersProperty
        private List<User> _FromUsers;
        public List<User> FromUsers
        {
            get { return _FromUsers; }
            set { SetProperty(ref _FromUsers, value); }
        }
        #endregion

        #region ToUsersProperty
        private List<User> _ToUsers;
        public List<User> ToUsers
        {
            get { return _ToUsers; }
            set { SetProperty(ref _ToUsers, value); }
        }
        #endregion

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        #region TagsProperty
        private List<Tag> _Tags;
        public List<Tag> Tags
        {
            get { return _Tags; }
            set { SetProperty(ref _Tags, value); }
        }
        #endregion

        public ThanksCardCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        // この画面に遷移し終わったときに呼ばれる。
        // それを利用し、画面表示に必要なプロパティを初期化している。
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ThanksCard = new ThanksCard();

            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.FromUsers = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
                this.ToUsers = this.FromUsers;
            }

            var tag = new Tag();
            this.Tags = await tag.GetTagsAsync();

            var dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region FromDepartmentsChangedCommand
        private DelegateCommand<long?> _FromDepartmentsChangedCommand;
        public DelegateCommand<long?> FromDepartmentsChangedCommand =>
            _FromDepartmentsChangedCommand ?? (_FromDepartmentsChangedCommand = new DelegateCommand<long?>(ExecuteFromDepartmentsChangedCommand));

        async void ExecuteFromDepartmentsChangedCommand(long? FromDepartmentId)
        {
            this.FromUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(FromDepartmentId);
        }
        #endregion

        #region ToDepartmentsChangedCommand
        private DelegateCommand<long?> _ToDepartmentsChangedCommand;
        public DelegateCommand<long?> ToDepartmentsChangedCommand =>
            _ToDepartmentsChangedCommand ?? (_ToDepartmentsChangedCommand = new DelegateCommand<long?>(ExecuteToDepartmentsChangedCommand));

        async void ExecuteToDepartmentsChangedCommand(long? ToDepartmentId)
        {
            this.ToUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(ToDepartmentId);
        }
        #endregion

        #region ClearCommand
        private DelegateCommand _ClearCommand;
        public DelegateCommand ClearCommand =>
                  _ClearCommand ?? (_ClearCommand = new DelegateCommand(ExecutClearCommand));
        
        void ExecutClearCommand()
        {
            this.regionManager = regionManager;

            // テキストボックスをクリアする
            this.ThanksCard.Title = "";
            this.ThanksCard.Body = "";
        }
        #endregion


        #region  BackCommand //1つ前のページへ戻る
        private DelegateCommand _BackCommand;
        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));
        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MainMenu));
        }
        #endregion


    }
}