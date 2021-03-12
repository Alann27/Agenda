using Agenda.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Agenda.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public IAlertServices AlertServices { get; }
        public INavigationServices NavigationServices { get; }
        protected BaseViewModel(IAlertServices alertServices, INavigationServices navigationServices)
        {
            AlertServices = alertServices;
            NavigationServices = navigationServices;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
