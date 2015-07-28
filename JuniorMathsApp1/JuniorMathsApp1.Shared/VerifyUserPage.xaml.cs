using JuniorMathsApp1.Model;
using JuniorMathsApp1.ParentClasses;
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
    public sealed partial class VerifyUserPage : Page
    {

        string getEmail = "";
        string getPhoneNum = "";
        string msg = "";
        Register objReg = null;
        ParentViewModel objParentViewModel = null;


        public VerifyUserPage()
        {
            this.InitializeComponent();
        }

        //Code for displaying MessageBox
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }

        private void btnVerifyUserDetails_Click(object sender, RoutedEventArgs e)
        {
            objReg = new Register();
            objParentViewModel = new ParentViewModel();
            
            getEmail = txtConfirmEmail.Text;
            getPhoneNum = txtConfirmPhoneNo.Text;

            
            if((!getEmail.Equals("")) && (!getPhoneNum.Equals("")))
            {
                try
                {
                        objReg = objParentViewModel.checkUserExistence(getEmail, getPhoneNum);
                }
                catch (Exception)
                {

                }

                if (objReg != null)
                {
                    this.Frame.Navigate(typeof(ResetPasswordPage), objReg);
                    msg = "User account details found in the database!" +
                          "\nProceed to reset your password.";
                    messageBox(msg);
                }
                else
                {
                    this.Frame.Navigate(typeof(VerifyUserPage));
                    msg = "Information enetered did not match anything in the database!" +
                          "\nEnsure that the information is correct!";
                    messageBox(msg);
                }

            }
            else
            {
                msg = "Please ensure that all text fields are filled in before proceeding!";
                messageBox(msg);
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
