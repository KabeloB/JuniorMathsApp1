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

                    int count = 0;
                    for (int z = 0; z < phoneNumber.Length; z++)
                    {
                        count = count + 1;
                    }

                    





                    /*
                    //check if phone number is ten characters long(South Affrican phone number)
                    int count = 0;
                    for(int z = 0; z < phoneNumber.Length; z++)
                    {
                        count = count + 1;

                        char getCharacter = ' ';

                        try
                        {


                           getCharacter = (char)phoneNumber.ElementAt(z);
                           int convNum = Convert.ToInt32(getCharacter);


                           if(convNum == 0 || convNum == 1 ||
                              convNum == 2 || convNum == 3 ||
                              convNum == 4 || convNum == 5 ||
                              convNum == 6 || convNum == 7 ||
                              convNum == 8 || convNum == 9)
                           {
                               itsANumber = true;
                           }
                           else
                           {
                               itsANumber = false;
                           }
                           
                        }
                        catch (ArgumentNullException)
                        {

                        }
                        catch (ArgumentOutOfRangeException)
                        {

                        }
                        catch(Exception)
                        {

                        }

                        /*
                            if((getCharacter.Equals('0')) ||
                               (getCharacter.Equals('1')) ||
                               (getCharacter.Equals('2')) ||
                               (getCharacter.Equals('3')) ||
                               (getCharacter.Equals('4')) ||
                               (getCharacter.Equals('5')) ||
                               (getCharacter.Equals('6')) ||
                               (getCharacter.Equals('7')) ||
                               (getCharacter.Equals('8')) ||
                               (getCharacter.Equals('9')))
                            { 

                    }
                    */


                    
                    //Insert the supplied user inputs into database here!
                    //Verify that the information was successfully inserted!
                    //user inputs were saved then redirect user to Login page!


                    //Check whether email address is correct
                    string findTheAtSign = "@";
                    for (int x = 0; x < email.Length; x++)
                    {
                        isFound = email.Contains(findTheAtSign);
                    }

                
                    if(isFound == true)
                    {
                        if(count == 10)
                        {
                            try
                            {
                                int numberEntered = int.Parse(txtEnterPhoneNo.Text);
                                if (numberEntered < 1 || numberEntered > 10)
                                {
                                    messageBox("You must enter a number between 1 and 10");
                                }
                                else 
                                {
                                    itsANumber = true;
                                }
                            }
                            catch (FormatException)
                            {

                                messageBox("You need to enter an integer");
                            }



                            if(itsANumber == true)
                            {
                                //objParent.SaveCustomer(name, surname, email, phoneNumber, password);
                                //this.Frame.Navigate(typeof(MainPage));
                                messageToDisplay = "You have succesfully registered, Please user your credentials to login!";
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
                            messageToDisplay = "Phone number must be ten didgits long!" +
                                               "\nThe number entered is: (" + count + ") characters long!";
                            messageBox(messageToDisplay);
                        }
                        
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

        private bool checkNumber(string num)
        {
            bool itsANumber = false;

            for (int x = 0; x < num.Length; x++)
            {
                if((!num.Contains("0")) ||
                   (!num.Contains("1")) ||
                   (!num.Contains("2")) ||
                   (!num.Contains("3")) ||
                   (!num.Contains("4")) ||
                   (!num.Contains("5")) ||
                   (!num.Contains("6")) ||
                   (!num.Contains("7")) ||
                   (!num.Contains("8")) ||
                   (!num.Contains("9")))
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
            return itsANumber;
        }

        
    }
}
