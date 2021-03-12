using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Agenda.Services
{
    class NavigationServices : INavigationServices
    {
        public Task ModalPush(Page page)
        {
            return App.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public Task NonModalPush(Page page)
        {
            return App.Current.MainPage.Navigation.PushAsync(page);
        }

        public Task NonModalPop()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public Task ModalPop()
        {
            return App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
