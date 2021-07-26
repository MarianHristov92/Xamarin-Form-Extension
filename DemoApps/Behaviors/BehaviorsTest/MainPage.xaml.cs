using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BehaviorsTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<MainPageVM, string>(this, "MESSAGE", (sender, msg) =>
            {
                DisplayAlert("Message", msg, "OK");
            });

            MessagingCenter.Subscribe<MainPageVM>(this, "NAVIGATE", (sender) =>
            {
                Navigation.PushAsync(new SecondPage());
            });
        }
    }
}
