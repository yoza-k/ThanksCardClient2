#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Model;
using ThanksCardClient.Services;

namespace ThanksCardAPI.Models
{
    public class Comment : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion
        #region TitleProperty
        private long _Title;
        public long Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        #endregion
        #region BodyProperty
        private long _Body;
        public long Body
        {
            get { return _Body; }
            set { SetProperty(ref _Body, value); }
        }
        #endregion
        #region ThanksIdProperty
        private long _ThanksCardId;
        public long ThanksCardId
        {
            get { return _ThanksCardId; }
            set { SetProperty(ref _ThanksCardId, value); }
        }
        #endregion
        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion
    }
}