using Agenda.Models;
using Agenda.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Agenda.ViewModels
{
    public class EditContactViewModel : BaseViewModel
    {
        public EditContactViewModel(ref ObservableCollection<Contact> contacts, Contact contact, IAlertServices alertService, INavigationServices navigationServices) : base(alertService, navigationServices)
        {
            Contacts = contacts;
            OldContact = contact;
            ContactToEdit = contact;


            OldName = contact.Name;
            OldPhoneNumber = contact.PhoneNumber;
            FirstLetterOldName = contact.FirstLetterName.Substring(0, 1).ToUpper();

            EditContactCommand = new Command(OnEditContact);
            BackCommand = new Command(OnBackCommand);
        }



        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact ContactToEdit { get; set; }
        public string OldName { get; }
        public string OldPhoneNumber { get; }
        public string FirstLetterOldName { get; }
        public Contact OldContact { get; set; } = new Contact("", "");

        public ICommand EditContactCommand { get; }
        public ICommand BackCommand { get; }

        private async void OnEditContact()
        {
            if (!string.IsNullOrEmpty(ContactToEdit.Name) && ContactToEdit.PhoneNumber.Length == 10)
            {
                ContactToEdit.FirstLetterName = ContactToEdit.Name.Substring(0, 1).ToUpper();

                Contacts.Remove(OldContact);

                Contacts.Add(ContactToEdit);

                await AlertServices.AlertAsync($"Edit contact", $"{ContactToEdit.Name} was edited");

                await NavigationServices.ModalPop();

            }
            else
            {
                await AlertServices.AlertAsync("Error", "Faltan datos por llenar, favor revise e intente de nuevo");
            }
        }

        private async void OnBackCommand()
        {
            ContactToEdit.Name = OldName;
            ContactToEdit.PhoneNumber = OldPhoneNumber;
            ContactToEdit.FirstLetterName = FirstLetterOldName;
            await NavigationServices.ModalPop();
        }
    }
}
