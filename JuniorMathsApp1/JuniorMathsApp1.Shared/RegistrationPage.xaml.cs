using JuniorMathsApp1.Model;
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




        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            objParent = new ParentViewModel();

            String name, surname, email, phoneNumber, password;

            name = txtEnterName.Text;
            surname = txtEnterSurname.Text;
            email = txtEnterEmail.Text;
            phoneNumber = txtEnterPhoneNo.Text;
            password = txtEnterPassword.Text;

            

            //Verify that user inputs are not empty first
            if ((!name.Equals("")) && (!surname.Equals("")) && (!email.Equals("")) && (!phoneNumber.Equals("")) && (!password.Equals("")))
            {
                //Insert the supplied user inputs into database here!
                //Verify that the information was successfully inserted!
                //user inputs were saved then redirect user to Login page!

                try
                { 
                    String status = objParent.SaveCustomer(name, surname, email, phoneNumber, password);
                    if(status.Equals("Success"))
                    {
                        this.Frame.Navigate(typeof(MainPage));
                    }
                    else if (status.Equals("This customer was not saved"))
                    {
                        string msg = "Data storage was unsuccessful!";
                        MessageDialog dialog = new MessageDialog(msg);
                        this.Frame.Navigate(typeof(RegistrationPage));
                    }
                }
                catch(Exception ex)
                {
                    MessageDialog dialog2 = new MessageDialog("Error:"  + ex.Message); 
                }

            }
            else
            {
                //Enter error message box here!
                //String ErrorMessage = "Invalid user inputs, Ensure that all fields are filled in!";
                this.Frame.Navigate(typeof(RegistrationPage));
            }


            this.Frame.Navigate(typeof(MenuPage));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
