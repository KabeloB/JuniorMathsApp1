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
        MenuPage objMenu = new MenuPage();

        MessageDialog msgBox = null;

        

        private JuniorMathsApp1.App app = (Application.Current as App);
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Code for displaying MessageBox
        public async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

            /*
            msgDisplay.Commands.Clear();
            msgDisplay.Commands.Add(new UICommand { Label = "Close", Id = 0});

            var res = await msgDisplay.ShowAsync();

            if((int)res.Id == 0)
            {
               await msgDisplay.ShowAsync();
            }
            */
        }



        //This buttons controls the Login fuctionalities
        private void btnLogin1_Click(object sender, RoutedEventArgs e)
        {
            //Ojbjects for ParentViewModel and Register classes
            objParent = new ParentViewModel();
            objReg = new Register();
            objMenu = new MenuPage();

            //this.Frame.Navigate(typeof(MenuPage));
            string username = txtUsername.Text;
            string password = pwbEnterPassword.Password;

            //String ErrorMessage
            string messageToDisplay = "";
            
           

                    if ((!username.Equals("")) && (!password.Equals("")))
                    {
                        try
                        {
                            string findTheAtSign = "@";
                            string findThePeriod = ".";
                            bool isFoundAtSign = false;
                            bool isFoundPeriod = false;
                            for (int x = 0; x < username.Length; x++)
                            {
                                isFoundAtSign = username.Contains(findTheAtSign);
                                isFoundPeriod = username.Contains(findThePeriod);
                                
                            }

                            if((isFoundAtSign == true) && (isFoundPeriod == true))
                            {
                                 //Get all parent details matching user supplied information
                                var confirm = objParent.getParent(username, password);
                                if(confirm != null)
                                {

                                    this.Frame.Navigate(typeof(MenuPage), confirm.Id);
                                    int iden = Convert.ToInt32(confirm.Id);//confirm.Id;
                                    objMenu.getID(iden);

                                    messageToDisplay = "Welcome " + confirm.Name + " " + confirm.Surname +
                                                       "\nYour user ID is: " + confirm.Id;
                                    messageBox(messageToDisplay);

                                
                                
                                }
                                 else
                                {
                                    messageToDisplay = "Invalid user details entered!" +
                                                       "\nPlease ensure that the username and password entered are correct...";
                                    messageBox(messageToDisplay);
                                }

                            }
                            else
                            {
                                messageToDisplay = "Invalid email address entered!";
                                messageBox(messageToDisplay);
                            }
                                

                            
                            
                        }
                        catch(Exception ex)
                        {
                            string ErrorMessage = "Error: " + ex.Message;
                            messageBox(ErrorMessage);
                        }
                        
                    }
                    else
                    {
                        //Enter error message box here!
                        string ErrorMessage = "Please ensure that all text fields are entered!";
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

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutAppPage));
        }
    }
}
