using Agenda.Models;
using Agenda.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Contact = Agenda.Models.Contact;

namespace Agenda.ViewModels
{
    public class AddContactViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact NewContact { get; set; } = new Contact("", "");
        public string CompanyIconImage { get; } = "companyIcon.png";
        public string CameraIconImage { get; set; } = "cameraIcon.png";
        public string MailIconImage { get; } = "mailIcon.png";
        public string PhoneIconImage { get; } = "phoneIcon.png";
        public string UserIconImage { get; } = "userIcon.png";
        public bool ContactHasPhoto { get; set; } = false;
        public bool ContactNoHasPhoto { get; set; } = true;
        public ICommand PickPhotoCommand { get; }


        public ICommand AddContactCommand { get; }
        public AddContactViewModel(ref ObservableCollection<Contact> contacts, IAlertServices alertService, INavigationServices navigationServices) : base(alertService, navigationServices)
        {
            Contacts = contacts;
            AddContactCommand = new Command(OnAddContact);
            PickPhotoCommand = new Command(OnPickPhoto);
        }

        private async void OnAddContact()
        {
            if (!string.IsNullOrEmpty(NewContact.Name) && NewContact.PhoneNumber.Length == 10)
            {
                NewContact.FirstLetterName =NewContact.Name.Substring(0, 1).ToUpper();
                Contacts.Add(NewContact);

                await AlertServices.AlertAsync("New contact added", $"{NewContact.Name} fue agregado como contacto");

                await NavigationServices.NonModalPop();

            }
            else
            {
                await AlertServices.AlertAsync("Error", "Faltan datos por llenar, favor revise e intente de nuevo");
            }
        }

        private async void OnPickPhoto(object sender)
        {
            var optionSelected = await App.Current.MainPage.DisplayActionSheet("Chnage photo", null, null, new string[] { "Take photo", "Choose photo" });

            if (optionSelected != null && optionSelected.ToString() == "Choose photo")
            {
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Choose a photo"
                });

                if (photo != null)
                {

                    //var photoStream = await photo.OpenReadAsync();

                    //Image image = (Image)sender;
                    //image.Source = ImageSource.FromFile(photo.FullPath);

                    CameraIconImage = photo.FileName;

                    NewContact.PhotoContact = ImageSource.FromFile(photo.FullPath);//ImageSource.FromStream(()=> photoStream).ToString();

                    ContactHasPhoto = true;
                    ContactNoHasPhoto = false;
                }
            }
            else if (optionSelected != null && optionSelected.ToString() == "Take photo")
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                    using (var stream = await photo.OpenReadAsync())
                    using (var newStream = File.OpenWrite(newFile))
                        await stream.CopyToAsync(newStream);

                    //var photoStream = await photo.OpenReadAsync();

                    NewContact.PhotoContact = photo.FullPath;//ImageSource.FromStream(()=> photoStream).ToString();

                    ContactHasPhoto = true;
                    ContactNoHasPhoto = false;
                }
            }

        }

    }
}
