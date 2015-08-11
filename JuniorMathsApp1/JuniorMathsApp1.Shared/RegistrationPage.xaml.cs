using JuniorMathsApp1.Model;
using JuniorMathsApp1.ParentClasses;
using SQLite;
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
    public sealed partial class RegistrationPage : Page
    {
        //public List<Register> users { get; set; }

        ParentViewModel objParent = new ParentViewModel();

        public RegistrationPage()
        {
            this.InitializeComponent();
        }


        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {


            // Get users
            var query = App.conn.Table<Register>();
            //users = await query.ToListAsync();       => uncomment here if errors are encountered

            // Show users
            //UserList.ItemsSource = users;
        }

        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }
        String messageToDisplay = "";


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            objParent = new ParentViewModel();

            String name, surname, email, phoneNumber, password;

            name = txtEnterName.Text;
            surname = txtEnterSurname.Text;
            email = txtEnterEmail.Text;
            phoneNumber = txtEnterPhoneNo.Text;
            password = txtEnterPassword.Text;
            bool isFoundAtSign = false;
            bool isFoundPeriod = false;
            bool itsANumber = false;
            char getChar = ' ';

           
            
                //Verify that user inputs are not empty first
                if ((!name.Equals("")) && (!surname.Equals("")) && (!email.Equals("")) && (!phoneNumber.Equals("")) && (!password.Equals("")))
                {
                    //Verify that the cell phone number is 10 characters long
                    int count = 0;
                    for (int z = 0; z < phoneNumber.Length; z++)
                    {
                        count = count + 1;
                    }
                    
                    //Insert the supplied user inputs into database here!
                    //Verify that the information was successfully inserted!
                    //user inputs were saved then redirect user to Login page!


                    //Check whether email address is correct
                    string findTheAtSign = "@";
                    string findThePeriod = ".";
                    for (int x = 0; x < email.Length; x++)
                    {
                        isFoundAtSign = email.Contains(findTheAtSign);
                        isFoundPeriod = email.Contains(findThePeriod);
                    }

                
                    if((isFoundAtSign == true) && (isFoundPeriod == true))
                    {
                        if(count == 10)
                        {

                            int verifyNum;
                            bool isNumerical = int.TryParse(phoneNumber, out verifyNum);

                            if(isNumerical == true)
                            {
                                objParent.SaveCustomer(name, surname, email, phoneNumber, password);
                                this.Frame.Navigate(typeof(MainPage));
                                messageToDisplay = "You have succesfully registered a new account..." +
                                                   "\nPlease use your new user credentials to login!";
                                messageBox(messageToDisplay);
                            }
                            else
                            {
                                messageToDisplay = "Please enter numeric characters only for the phone number! ";
                                messageBox(messageToDisplay);
                            }
                        }
                        else
                        {
                            messageToDisplay = "Phone number must be ten (10) characters long!" +
                                               "\nThe number you entered is: (" + count + ") characters long!";
                            messageBox(messageToDisplay);
                        }
                        
                    }
                    else
                    {
                        messageToDisplay = "Invalid email address entered!" +
                                           "\nPlease ensure that the email address contains an (@) character";
                        messageBox(messageToDisplay);
                    }
                   


                }
                else
                {
                    //Enter error message box here!
                    messageToDisplay = "Invalid user inputs..." + 
                        "\nPlease ensure that all text fields are filled in before proceeding!";
                    messageBox(messageToDisplay);
                }


            //this.Frame.Navigate(typeof(MenuPage));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtEnterName.Text = "";
            txtEnterSurname.Text = "";
            txtEnterEmail.Text = "";
            txtEnterPhoneNo.Text = "";
            txtEnterPassword.Text = "";
        }

    }
}
