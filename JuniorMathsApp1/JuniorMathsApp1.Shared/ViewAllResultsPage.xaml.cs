using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.Model;
using JuniorMathsApp1.TestClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ViewAllResultsPage : Page
    {
        string getIds = "";
        int parentID = 0;
        int childID = 0;
        string getParentID = "";
        string getChildID = "";

        ObservableCollection<TestViewModel> test = null;
        TestsViewModel testsViewModel = null;
        TestViewModel objTestViewModel = null;

        ChildrenViewModel objChildrenViewModel = null;
        RegisterChild objRegChild = null;

        public ViewAllResultsPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {
                base.OnNavigatedTo(e);
                getIds = (string)e.Parameter;

                getParentID = getIds.Substring(0,1);
                getChildID = getIds.Substring(2);

                objChildrenViewModel = new ChildrenViewModel();
                objRegChild = new RegisterChild();

                objRegChild = objChildrenViewModel.getChildDetails(Convert.ToInt32(getChildID), Convert.ToInt32(getParentID));
                

                testsViewModel = new TestsViewModel();
                test = testsViewModel.GetTests(Convert.ToInt32(getIds.Substring(2)));

                lsViewTest.Items.Add("Test ID" + "\t" + "Child ID" + "\t" + "#Right Answers" + "\t" + "#Wrong Answers " + "\t" + "Date of Test");

                foreach (var c in test)
                {
                    lsViewTest.Items.Add(c.Id + "\t" + c.ChildId + "           \t" + c.RightAnswers + "                           \t" + c.WrongAnswers + "             \t" + c.Date);

                }
                base.OnNavigatedTo(e);

                lblChId.Text = "" + objRegChild.Id + " - " + objRegChild.Name + " " + objRegChild.Surname; 

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



        private void btnReturnMainMenu_Click(object sender, RoutedEventArgs e)
        {
           int getNum = myParentId(getParentID); 
           this.Frame.Navigate(typeof(MenuPage), getNum);
        }

        public int myParentId(string m)
        {
            int returnNumP = Convert.ToInt32(m);
            return returnNumP;
        }

        public int myChildId(string m)
        {
            int returnNumP = Convert.ToInt32(m);
            return returnNumP;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            int getNum = myParentId(getParentID);
            this.Frame.Navigate(typeof(SelectChildToViewPage), getNum);
        }

        //Button to delete all child test results
        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            if(!getChildID.Equals(""))
            {
                int convChildId = myChildId(getChildID);
                int convParentId = myParentId(getParentID);
                objChildrenViewModel = new ChildrenViewModel();
                objRegChild = new RegisterChild();
                objTestViewModel = new TestViewModel();

                objRegChild = objChildrenViewModel.getChildDetails(convChildId, convParentId);
                objTestViewModel.deleteChildTestRecords(convChildId);


                this.Frame.Navigate(typeof(SelectChildToViewPage), convParentId);
                string msg = "All child test records for " + objRegChild.Name + " " + objRegChild.Surname + " were successfully deleted";
                messageBox(msg);



            }
            else
            {
                messageBox("Child id can't be empty!");
            }
        }

    }
}
