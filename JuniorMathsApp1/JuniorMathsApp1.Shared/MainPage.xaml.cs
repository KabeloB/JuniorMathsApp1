using JuniorMathsApp1.Model;
using JuniorMathsApp1.ParentClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        ParentViewModel objParent = new ParentViewModel();

        Register objReg = new Register();

        MessageDialog dialog = new MessageDialog("");

        private JuniorMathsApp1.App app = (Application.Current as App);
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Code for displaying MessageBox
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }

        //This buttons controls the Login fuctionalities
        private void btnLogin1_Click(object sender, RoutedEventArgs e)
        {
            //Ojbjects for ParentViewModel and Register classes
            objParent = new ParentViewModel();
            objReg = new Register();

            //this.Frame.Navigate(typeof(MenuPage));
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            //String ErrorMessage
            string messageToDisplay = "";
            

                    if ((!username.Equals("")) && (!password.Equals("")))
                    {
                        try
                        {
                            //Get all parent details matching user supplied information

                            var confirm = objParent.getParent(username, password);

                            if(confirm != null)
                            {
                                this.Frame.Navigate(typeof(MenuPage));
                                messageToDisplay = "Welcome " + confirm.Name + " " + confirm.Surname;
                                messageBox(messageToDisplay);
                                
                                
                            }
                             else
                            {
                                messageToDisplay = "Invalid user details enetered!";
                                messageBox(messageToDisplay);
                            }


                            
                            
                        }
                        catch(Exception ex)
                        {
                            dialog = new MessageDialog("Error: " + ex.Message);
                        }
                        
                    }
                    else
                    {
                        //Enter error message box here!
                        String ErrorMessage = "Input fields must not be empty!";
                        messageBox(ErrorMessage);
                        //this.Frame.Navigate(typeof(MainPage));
                        
                    }
                
           
            
            //Verify that user inputs are not empty first
        
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ShowPage));
        }
    }
}
