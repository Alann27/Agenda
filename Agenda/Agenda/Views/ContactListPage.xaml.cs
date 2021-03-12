using Agenda.ViewModels;
using Agenda.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {


        public ContactListPage()
        {
            InitializeComponent();

            BindingContext = new ContactListViewModel(new AlertServices(), new NavigationServices());
        }

    }
}
