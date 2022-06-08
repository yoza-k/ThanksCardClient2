#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Model;
using ThanksCardClient.Services;

namespace ThanksClientAPI.Models
{
    public class SearchThanksCard :BindableBase
    {
        #region SeachProperty
        private string _SeachWord;
        public string SeachWord
        {
            get { return _SeachWord; }
            set { SetProperty(ref _SeachWord, value); }
        }
        #endregion
    }
}