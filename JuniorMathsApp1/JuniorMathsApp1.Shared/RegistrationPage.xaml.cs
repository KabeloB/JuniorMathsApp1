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
            bool isFound = false;
            bool itsANumber = false;
            char getChar = ' ';
            
                //Verify that user inputs are not empty first
                if ((!name.Equals("")) && (!surname.Equals("")) && (!email.Equals("")) && (!phoneNumber.Equals("")) && (!password.Equals("")))
                {
                    //Insert the supplied user inputs into database here!
                    //Verify that the information was successfully inserted!
                    //user inputs were saved then redirect user to Login page!


                    
                    //Check whether phone number values are numeric
                    /*for (int i = 0; i < phoneNumber.Length; i++)
                    {
                        
                            getChar = phoneNumber.ElementAt(i);
                        
                            /*if ((getChar.Equals('0')) ||
                                (getChar.Equals('1')) ||
                                (getChar.Equals('2')) ||
                                (getChar.Equals('3')) ||
                                (getChar.Equals('4')) ||
                                (getChar.Equals('5')) ||
                                (getChar.Equals('6')) ||
                                (getChar.Equals('7')) ||
                                (getChar.Equals('8')) ||
                                (getChar.Equals('9')))
                                
                             if((!phoneNumber.Contains("0")) ||
                                (!phoneNumber.Contains("1")) ||
                                (!phoneNumber.Contains("2")) ||
                                (!phoneNumber.Contains("3")) ||
                                (!phoneNumber.Contains("4")) ||
                                (!phoneNumber.Contains("5")) ||
                                (!phoneNumber.Contains("6")) ||
                                (!phoneNumber.Contains("7")) ||
                                (!phoneNumber.Contains("8")) ||
                                (!phoneNumber.Contains("9")))  
                            {
                                messageToDisplay = "Please enter a numeric characters for the phone number!";
                                messageBox(messageToDisplay);
                                itsANumber = false;
                            }
                            else
                            {
                                itsANumber = true;
                            }


                       
                    }
                    */

                    //Check whether email address is correct
                    string findTheAtSign = "@";
                    for (int x = 0; x < email.Length; x++)
                    {
                        isFound = email.Contains(findTheAtSign);
                    }

                
                    if((isFound == true) && (itsANumber == true))
                    {
                        objParent.SaveCustomer(name, surname, email, phoneNumber, password);

                        this.Frame.Navigate(typeof(MainPage));
                        messageToDisplay = "You have succesfully registered, Please user your credentials to login!";
                        messageBox(messageToDisplay);
                        
                    }
                    else
                    {
                        messageToDisplay = "Invalid email address entered!";
                        messageBox(messageToDisplay);
                    }
                   


                }
                else
                {
                    //Enter error message box here!
                    messageToDisplay = "Invalid user inputs, Ensure that all fields are filled in!";
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
