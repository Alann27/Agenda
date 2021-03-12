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
    public partial class EditContactPage : ContentPage
    {
        public EditContactPage(ObservableCollection<Contact> contacts, Contact contact)
        {
            InitializeComponent();

            BindingContext = new EditContactViewModel(ref contacts,contact, new AlertServices(), new NavigationServices());
        }
    }
}