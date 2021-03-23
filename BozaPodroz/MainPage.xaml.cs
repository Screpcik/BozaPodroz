using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BozaPodroz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("BozaPodroz.Assets.Images.logo.png", assembly);
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
           bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
           bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);
           
            if(isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
