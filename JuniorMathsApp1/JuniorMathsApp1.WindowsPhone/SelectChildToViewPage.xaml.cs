using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.Model;
using JuniorMathsApp1.TestClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public sealed partial class SelectChildToViewPage : Page
    {
        ObservableCollection<ChildrenViewModel> children = null;
        ChildrenViewModel childrenViewModel = null;
        ChildrensViewModel childrensViewModel = null;
        TestViewModel objTestViewModel = null;
        RegisterChild regChild = null;

        int parentId = 0;
        int selectedChildId = 0;

        string getTheID = "";
        string allChildDetails = "";

        int getSelectedItem;


        public SelectChildToViewPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {
                base.OnNavigatedTo(e);
                parentId = (int)e.Parameter;

                childrensViewModel = new ChildrensViewModel();
                children = childrensViewModel.GetChildren(parentId);
                regChild = new RegisterChild();

                lsViewChildren.Items.Add("ID" + "\t" + "NAME & SURNAME");

                foreach (var c in children)
                {
                   lsViewChildren.Items.Add(c.Id + "-" + c.Name + "_" + c.Surname);

                   
                   //Retrive selecte element from listView
                   //regChild = (RegisterChild)lsViewChildren.SelectedValue;
                }

                //var sel = lsViewChildren.SelectedItems.Cast<Object>.ToArray();
                regChild = (RegisterChild) lsViewChildren.SelectedValue;
                
               
                base.OnNavigatedTo(e);

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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage), parentId);
        }

        string ele = "";
        //Get the select item from the user
        private void lsViewChildren_ItemClick(object sender, ItemClickEventArgs e)
        {
           //var getElement = e.ClickedItem;
           //ele = "" +getElement;
           //regChild = (RegisterChild) getSelectedItem;

            Debug.WriteLine("Click!");
        }

        string objItems = "";
        string idNum = "";
        string name = "";
        string surname =  "";
        string age = "";
        string grade = "";
        //private void MySelectionChanged(object sender, SelectionChangedEventArgs e)
        private void MySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                objItems = "" + e.AddedItems[0];
                idNum = objItems.Substring(0, objItems.IndexOf("-"));
                name = objItems.Substring(2, objItems.IndexOf("_") - 2);
                /*
                objItems = "" +e.AddedItems[0];
                idNum = objItems.Substring(0, objItems.IndexOf("_"));
                name = objItems.Substring(2, objItems.IndexOf("_"));
                surname = objItems.Substring(objItems.IndexOf("_"), objItems.IndexOf("#"));
                age = objItems.Substring(objItems.IndexOf("#"), objItems.IndexOf("$"));
                grade = objItems.Substring(objItems.IndexOf("$"), objItems.Length);
                 * */
            }
            catch(Exception)
            {

            }
            //Debug.WriteLine("Selected: {0}", e.AddedItems[0]);
            
        }

 
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            string msg = "";
            int convNum = 0;
            try
            {
                if(idNum.Equals(""))
                {
                    string msgErr = "Please select a child before proceeding!";
                    messageBox(msgErr);
                }
                else
                {
                   convNum = Convert.ToInt32(idNum);
                }
               
            }
            catch (Exception)
            {

            }

            if(convNum <= 0)
            {
                msg = "Please select a child first before proceeding with viewing test results!";
                messageBox(msg);
            }
            else
            {
                string objToSend = "" + parentId + "#" + idNum;
                this.Frame.Navigate(typeof(ViewAllResultsPage), objToSend);
            }
           

        }
        //Method for converting string to integer for parent id
        public int myParentId(string m)
        {
            int returnNumP = 0;
            try
            {
               returnNumP = Convert.ToInt32(m);
            }
            catch(Exception)
            {

            }
            return returnNumP;
        }

        //Method for converting string to integer for child id
        public int myChildId(string m)
        {
            int returnNumP = 0;
            try
            {
                if(m.Equals(""))
                {
                    string msg = "Please select a child before proceeding with the deleting process!";
                }
                else
                {
                   returnNumP = Convert.ToInt32(m);
                }
               
            }
            catch (Exception)
            {

            }
            return returnNumP;
        }

        //Button for deleting a child from an account
        private void btnDeleteChild_Click(object sender, RoutedEventArgs e)
        {
            childrenViewModel = new ChildrenViewModel();
            objTestViewModel = new TestViewModel();
            string strMsg = "";
            int convNum = myParentId(idNum);
            int getResult = 0;

            if (convNum <= 0)
            {
                strMsg = "Please select a child first before proceeding with the delete process!";
                messageBox(strMsg);
            }
            else
            {
                try
                {
                    childrenViewModel.deleteChildRecords(convNum);
                    objTestViewModel.deleteChildTestRecords(convNum);
                    strMsg = "You have successfully deleted: " + name + " from the database!";
                    messageBox(strMsg);
                    this.Frame.Navigate(typeof(MenuPage), parentId);
                }
                catch (Exception)
                {

                }
            }
        }

        //Button to update child details
        private void btnEditChildDetails_Click(object sender, RoutedEventArgs e)
        {
            regChild = new RegisterChild();
            childrenViewModel = new ChildrenViewModel();

            int convertChildId = 0;
            int convertParentId = 0;
            string strMsg = "";

            try
            {
                convertChildId = Convert.ToInt32(idNum);
                convertParentId = Convert.ToInt32(parentId);
                regChild = childrenViewModel.getChildDetails(convertChildId,parentId);
            }
            catch(Exception)
            {

            }


            if ((convertChildId <= 0) && (convertParentId <= 0))
            {
                strMsg = "Please select a child first before proceeding with the editing process!";
                messageBox(strMsg);
            }
            else
            {
                if(regChild != null)
                {
                    this.Frame.Navigate(typeof(EditedSelectedChildPage), regChild);
                    string msg = "Found child details in the database!";
                    messageBox(msg);
                }
                else
                {
                    string msg = "Couldn't retrive child infomation from the database";
                    messageBox(msg);
                }
            }
        }
         


        
    }
}
