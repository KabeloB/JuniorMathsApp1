using JuniorMathsApp1.ChildrenClasses;
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
    public sealed partial class RegisterNewChild : Page
    {

        ParentViewModel objParent = new ParentViewModel();
        ChildrenViewModel objChild = new ChildrenViewModel();
        RegisterChild regChild = new RegisterChild();
        string grade;

        string getParentIdNum;
        
        

        public RegisterNewChild()
        {
            this.InitializeComponent();
            
        }

        //Recieve the parent Id
        int parentId = 0;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            parentId = (Int32)e.Parameter;

        }


        //Method for displaying message box
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }
        String messageToDisplay = "";

        //Choose the childs grade
        private void rdGradeOne_Checked(object sender, RoutedEventArgs e)
        {
            grade = "Grade 1";
        }

        private void rdGradeTwo_Checked(object sender, RoutedEventArgs e)
        {
            grade = "Grade 2";
        }

        //Button to save new child details into the database

        private void btnSaveInformation_Click(object sender, RoutedEventArgs e)
        {
            objParent = new ParentViewModel();
            objChild = new ChildrenViewModel();
            regChild = new RegisterChild();

            string childName = txtChildName.Text;
            string childSurname = txtChildSurname.Text;
            string childAge = txtChildAge.Text;
            int convertAge = 0;

            convertAge = Convert.ToInt32(childAge);


            //Verify that user inputs are not empty first
            if ((!childName.Equals("")) && (!childSurname.Equals("")) && (!childAge.Equals("")))
            {
                try
                {
                    //Insert the supplied user inputs into database here!
                    //Verify that the information was successfully inserted!
                    //user inputs were saved then redirect user to Login page!

                    //objChild.SaveChild(int parentId, string name, string surname, int age, string grade);


                    objChild.saveChild(parentId, childName, childSurname, convertAge, grade);


                    this.Frame.Navigate(typeof(MenuPage));
                    messageToDisplay = "You have succesfully registered the following child to your account: " +
                                        "\n" + childName + " " + childSurname;
                    messageBox(messageToDisplay);
                }
                catch(Exception)
                {

                }
                
                


            }
            else
            {
                //Enter error message box here!
                //String ErrorMessage = "Invalid user inputs, Ensure that all fields are filled in!";
                this.Frame.Navigate(typeof(RegistrationPage));
            }
        }
    }
}
