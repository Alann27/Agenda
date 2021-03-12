using Agenda.Models;
using Agenda.Services;
using Agenda.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage(ObservableCollection<Contact> contacts)
        {
            InitializeComponent();

            BindingContext = new AddContactViewModel(ref contacts, new AlertServices(), new NavigationServices());
        }
    }
}