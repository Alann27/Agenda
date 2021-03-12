using Agenda.Models;
using Agenda.Services;
using Agenda.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Contact = Agenda.Models.Contact;

namespace Agenda.ViewModels
{
    public class ContactListViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public ICommand SelectedContactCommand { get; }

        public ICommand AddContactCommand { get; }
        public ICommand MoreCommand { get; }
        public ICommand DeleteContactCommand { get; }
        public string MenuIconImage { get; } = "menuIcon.png";
        public string MoreIconImage { get; } = "moreIcon.png";
        public string PersonIconImage { get; } = "personIcon.png";

        public ContactListViewModel(IAlertServices alertService, INavigationServices navigationServices) : base(alertService, navigationServices)
        {
            Contacts = new ObservableCollection<Contact>();
            SelectedContactCommand = new Command<Contact>(OnSelectedContact);
            MoreCommand = new Command<Contact>(OnMore);
            AddContactCommand = new Command(OnAddContact);
            DeleteContactCommand = new Command<Contact>(OnDeleteContact);
        }



        private async void OnMore(Contact contact)
        {
            var optionSelected = await App.Current.MainPage.DisplayActionSheet("Select an option", null,null, new string[] { $"Call {contact.PhoneNumber}", "Edit" });

            if (optionSelected.ToString() == $"Call {contact.PhoneNumber}")
            {
                PhoneDialer.Open(contact.PhoneNumber);
            }
            else
            {
                await NavigationServices.ModalPush(new EditContactPage(Contacts,contact));
            }

        }

        private async void OnDeleteContact(Contact selectedContact)
        {
            Contacts.Remove(selectedContact);

            await AlertServices.AlertAsync("Contacto borrado", "Contacto borrado exitosamente");
        }

        private async void OnAddContact()
        {
            await NavigationServices.NonModalPush( new AddContactPage(Contacts));
        }

        private async void OnSelectedContact(Contact contact)
        {
            if (contact != null)
            {
                await AlertServices.AlertAsync("Contact", $"Número de teléfono de {contact.Name} es {string.Format("(000)-000-0000", contact.PhoneNumber)}");
            }          
                
        }
    }
}
