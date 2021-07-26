using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace BehaviorsTest
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageVM()
        {
        }

        private void OnPropertyChanged(string propertyName)
        {
            Debug.WriteLine("Property changed: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Command _onPageAppearing;
        public Command OnPageAppearing
        {
            get {
                return _onPageAppearing
                    ?? (_onPageAppearing = new Command(
                () =>
                {
                    MessagingCenter.Send<MainPageVM, string>(this, "MESSAGE", "Sent on Appearing.");
                }));  
            }
        }

        private Command _onPageDisappearing;
        public Command OnPageDisappearing
        {
            get
            {
                return _onPageDisappearing
                    ?? (_onPageDisappearing = new Command(
                () =>
                {
                    MessagingCenter.Send<MainPageVM, string>(this, "MESSAGE", "Sent on Disappearing.");
                }));
            }
        }

        private Command _onNavigate;
        public Command OnNavigate
        {
            get
            {
                return _onNavigate
                    ?? (_onNavigate = new Command(
                () =>
                {
                    MessagingCenter.Send<MainPageVM>(this, "NAVIGATE");
                }));
            }
        }
    }
}
