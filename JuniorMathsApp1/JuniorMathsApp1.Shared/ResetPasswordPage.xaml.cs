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
    public sealed partial class ResetPasswordPage : Page
    {

        Register objReg = null;
        ParentViewModel objParentViewModel = null;
        string msg = "";

        string newPassW = "";
        string confirmNewPassw = "";
        public ResetPasswordPage()
        {
            this.InitializeComponent();
        }

        //Get object containing user details
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                objReg = (Register)e.Parameter;

                lblGetId.Text = "" + objReg.Id;
                lblGetName_Surname.Text = "" + objReg.Name + " " + objReg.Surname; 

            }
            catch (Exception)
            {

            }

            


        }

        //Code for displaying MessageBox
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {
            
            objParentViewModel = new ParentViewModel();
            newPassW = txtNewPassword.Text;
            confirmNewPassw = pbConfirmPassword.Password;
            int resultPassword = 0;

            
            if((!newPassW.Equals("")) && (!confirmNewPassw.Equals("")))
            {
                if(newPassW.Equals(confirmNewPassw))
                {
                    try
                    {
                        int ParentId = (int)objReg.Id;
                        resultPassword = objParentViewModel.updatePassword(ParentId, newPassW);
                    }
                    catch(Exception)
                    {

                    }

                    if(resultPassword > 0)
                    {
                        msg = "Password successfully updated!" +
                              "\nPlease use the new password to login next time!";
                        messageBox(msg);
                        this.Frame.Navigate(typeof(MainPage));
                    }
                    else
                    {
                        msg = "Password updated was unsuccessful!" +
                              "\nPlease start the reset password process again!";
                        messageBox(msg);
                        this.Frame.Navigate(typeof(MainPage));
                    }

                }
                else
                {
                    msg = "Please ensure that the new password text field is identical to the confirmation password text field!";
                    messageBox(msg);
                }


            }
            else
            {
                msg = "Please ensure that all text fields are entered!";
                messageBox(msg);

            }



        }
    }
}
