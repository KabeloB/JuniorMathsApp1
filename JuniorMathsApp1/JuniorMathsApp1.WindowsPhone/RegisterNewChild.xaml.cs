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

        
        ChildrenViewModel objChild = new ChildrenViewModel();

        string grade1 = "Grade 1";
        string grade2 = "Grade 2";

       
        public RegisterNewChild()
        {
            this.InitializeComponent();

            cbSelectGrade.Items.Add("");
            cbSelectGrade.Items.Add(grade1);
            cbSelectGrade.Items.Add(grade2);
            
        }

        //Recieve the parent Id
        int parentId = 0;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                parentId = (int)e.Parameter;
                lblGetParentIdNum.Text = "" + parentId;
            }
            catch(Exception)
            {

            }
            

        }


        //Method for displaying message box
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }
        String messageToDisplay = "";

        //Button to save new child details into the database

        private void btnSaveInformation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                objChild = new ChildrenViewModel();

                string childName = txtChildName.Text;
                string childSurname = txtChildSurname.Text;
                string childAge = txtChildAge.Text;

                string getGrade = "" + cbSelectGrade.SelectedItem;


                //Verify that user inputs are not empty first
                if ((!childName.Equals("")) && (!childSurname.Equals("")) && (!childAge.Equals("")) && (!getGrade.Equals("")))
                {

                    //objChild.saveChild("" + parentId, childName, childSurname, childAge, getGrade);

                    int verifyNum;
                    bool isNumerical = int.TryParse(childAge, out verifyNum);

                    if (isNumerical == true)
                    {
                        try
                        {
                            //Insert the supplied user inputs into database here!
                            //Verify that the information was successfully inserted!
                            //user inputs were saved then redirect user to Login page!

                            int result = objChild.registerNewChild("" + parentId, childName, childSurname, childAge, getGrade);

                            string m = objChild.getMessage();


                            lblGetParentIdNum.Text = m;

                            if (result > 0)
                            {

                                this.Frame.Navigate(typeof(MenuPage), parentId);
                                messageToDisplay = "You have succesfully registered the following child to your account: " +
                                                    "\n" + childName + " " + childSurname;
                                messageBox(messageToDisplay);


                            }
                            else
                            {
                                this.Frame.Navigate(typeof(RegisterNewChild), parentId);
                                messageToDisplay = "Failed to register this child: " +
                                                    "\n" + childName + " " + childSurname;
                                messageBox(messageToDisplay);
                            }



                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                    {
                        messageToDisplay = "Please enter numeric characters only for the age!";
                        messageBox(messageToDisplay);
                    }

                }
                else
                {
                    //Enter error message box here!
                    //String ErrorMessage = "Invalid user inputs, Ensure that all fields are filled in!";
                    //this.Frame.Navigate(typeof(RegisterNewChild), parentId);
                    messageToDisplay = "Please ensure that all text fields are filled in before proceeding!";
                    messageBox(messageToDisplay);
                }
            }
            catch(Exception)
            {

            }
            



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage), parentId);
        }


    }
}
