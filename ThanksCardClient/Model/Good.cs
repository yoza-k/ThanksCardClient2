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
    public class Good :BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion
        #region CardIdProperty
        private long _CardId;
        public long CardId
        {
            get { return _CardId; }
            set { SetProperty(ref _CardId, value); }
        }
        #endregion
        #region SeachProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion
        #region UserIdProperty
        private long _UserId;
        public long UserId
        {
            get { return _UserId; }
            set { SetProperty(ref _UserId, value); }
        }
        #endregion
        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
        }
        #endregion

    }
}