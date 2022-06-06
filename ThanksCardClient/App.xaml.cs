using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using ThanksCardClient.Views;
namespace ThanksCardClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<Logon2>();
            containerRegistry.RegisterForNavigation<MainMenu>();
            containerRegistry.RegisterForNavigation<BulletinBoard>();
            containerRegistry.RegisterForNavigation<ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<ThanksCardMenu>();
            containerRegistry.RegisterForNavigation<ThanksCardDisplay>();
            containerRegistry.RegisterForNavigation<CommentCardDisplay>();
            containerRegistry.RegisterForNavigation<CommentCreate>();
            containerRegistry.RegisterForNavigation<GoodCardList>();
            containerRegistry.RegisterForNavigation<ReceiveCardList>();
            containerRegistry.RegisterForNavigation<ReceiveCommentList>();
            containerRegistry.RegisterForNavigation<SendCardList>();
            containerRegistry.RegisterForNavigation<SendCommentList>();
        }
    }
}