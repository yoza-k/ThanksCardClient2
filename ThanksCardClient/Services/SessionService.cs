#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Model;

namespace ThanksCardClient.Services
{
    internal class SessionService
    {
        private static SessionService instance = new SessionService { IsAuthorized = false };

        public Boolean IsAuthorized { set; get; }
        public User AuthorizedUser { set; get; }

        public static SessionService Instance
        {
            get
            {
                return SessionService.instance;
            }
        }

        private SessionService()
        {
        }
    }
}
