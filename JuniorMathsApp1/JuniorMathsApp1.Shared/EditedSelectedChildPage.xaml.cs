using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.Model;
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
    public sealed partial class EditedSelectedChildPage : Page
    {
        string getData = "";

        string idNum = "";
        string name = "";
        string surname = "";
        string age = "";
        string grade = "";
        string parentID = "";

        string msgs = "";

        RegisterChild regChild = null;
        ChildrenViewModel childrenViewModel = null;

        public EditedSelectedChildPage()
        {
            this.InitializeComponent();
        }


        //Display the ID of the parent currently logged in
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            regChild = new RegisterChild();
            try
            {
                base.OnNavigatedTo(e);
                regChild = (RegisterChild)e.Parameter;

                idNum = "" + regChild.Id;
                name = "" + regChild.Name;
                surname = "" + regChild.Surname;
                age = "" + regChild.Age;
                grade = "" + regChild.Grade;
                parentID = "" + regChild.ParentId;

                //displayChildsDetails(idNum, name, age, grade);
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


        public void displayChildsDetails(string id, string name, string age, string grade)
        {
            /*
            lblChildsID.Text = id;
            txtCurrentChildName.Text = name;
            txtCurrentChildAge.Text = age;

            cbCurrentChildGrade.Items.Add(grade);
            cbCurrentChildGrade.Items.Add("");
            cbCurrentChildGrade.Items.Add("grade1");
            cbCurrentChildGrade.Items.Add("grade2");
            */
        }

        private void btnProceed_Click(object sender, RoutedEventArgs e)
        {
            childrenViewModel = new ChildrenViewModel();
            string id = lblChildsID.Text;
            int convID = Convert.ToInt32(id);

            string newName = txtCurrentChildName.Text;
            string newSurname = txtCurrentChildSurname_.Text;
            string newAge = txtCurrentChildAge.Text;
            string getGrade = (string)cbCurrentChildGrade.SelectedItem;

            int result = 0;
            
                if((!newSurname.Equals("")) && (!newSurname.Equals("")) && (!newAge.Equals("")))
                {
                    try
                    {
                       result = childrenViewModel.updateChildInfo(convID, parentID, newName, newSurname,newAge, getGrade);

                    }
                    catch(Exception)
                    {

                    }


                    if (result > 0)
                    {
                        int ConvParentIden = Convert.ToInt32(parentID);
                        this.Frame.Navigate(typeof(MenuPage), ConvParentIden);
                        string msg = "Child details update was successful!";
                        messageBox(msg);
                    }
                    else
                    {
                        string msg = "Couldn't update child information!";
                        messageBox(msg);
                    }

                }
                else
                {
                    msgs = "Please ensure that all fields are filled in before proceeding to update!";
                    messageBox(msgs);
                }
                
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            lblChildsID.Text = idNum;
            txtCurrentChildName.Text = name;
            txtCurrentChildSurname_.Text = surname;
            txtCurrentChildAge.Text = age;

            cbCurrentChildGrade.Items.Add(grade);
            cbCurrentChildGrade.Items.Add("");
            cbCurrentChildGrade.Items.Add("Grade 1");
            cbCurrentChildGrade.Items.Add("Grade 2");

        }

        private void btnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            int convParentId = Convert.ToInt32(parentID);
            this.Frame.Navigate(typeof(SelectChildToViewPage), convParentId);
        }

    }
}
