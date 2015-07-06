using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace JuniorMathsApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //This buttons controls the Login fuctionalities
        private void btnLogin1_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(MenuPage));

            String username = txtUsername.Text;
            String password = txtPassword.Text;
            //String ErrorMessage =

            //Verify that user inputs are not empty first
            if((!username.Equals("")) && (!password.Equals("")))
            {
                if ((username.Equals("DatabaseUsername")) && (password.Equals("DatabasePassword")))
                {
                    this.Frame.Navigate(typeof(MenuPage));
                }
                else
                {
                    //Enter error message box here!
                    //String ErrorMessage = "Invalid user inputs entered!";
                    this.Frame.Navigate(typeof(MainPage));
                }
                
            }
            else
            {
                //Enter error message box here!
                //String ErrorMessage = "Invalid user inputs entered!";
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        //This buttons controls the Registration fuctionalities
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistrationPage));
        }

        //This buttons controls the Password Reset fuctionalities
        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(VerifyUserPage));
        }
    }
}
