using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.Model;
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
                   lsViewChildren.Items.Add(c.Id + "-" + c.Name + "_" + c.Surname + "#"+ c.Age + "$" + c.Grade);

                   
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
        private void MySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                objItems = "" +e.AddedItems[0];
                idNum = objItems.Substring(0,1);
                name = objItems.Substring(2, objItems.IndexOf("_"));
                surname = objItems.Substring(objItems.IndexOf("_"), objItems.IndexOf("#"));
                age = objItems.Substring(objItems.IndexOf("#"), objItems.IndexOf("$"));
                grade = objItems.Substring(objItems.IndexOf("$"), objItems.Length);
            }
            catch(Exception)
            {

            }
            //Debug.WriteLine("Selected: {0}", e.AddedItems[0]);
            
        }

 
        private void btnView_Click(object sender, RoutedEventArgs e)
        {

            

            int convNum = Convert.ToInt32(idNum);

            string objToSend = "" + parentId + "#" + idNum;

            this.Frame.Navigate(typeof(ViewAllResultsPage), objToSend);

        }
        //Method for converting string to integer
        public int myParentId(string m)
        {
            int returnNumP = Convert.ToInt32(m);
            return returnNumP;
        }

        //Button for deleting a child from an account
        private void btnDeleteChild_Click(object sender, RoutedEventArgs e)
        {
            childrenViewModel = new ChildrenViewModel();
            string strMsg = "";
            int convNum = myParentId(idNum);
            int getResult = 0;

            try
            {
                childrenViewModel.deleteChildRecords(convNum);
                strMsg = "You have successfully deleted: " + name + " from the database!";
                messageBox(strMsg);
                this.Frame.Navigate(typeof(MenuPage), parentId);
            }
            catch(Exception)
            {

            }
        }

        //Button to update child details
        private void btnEditChildDetails_Click(object sender, RoutedEventArgs e)
        {
            regChild = new RegisterChild();
            childrenViewModel = new ChildrenViewModel();

            int convertChildId = Convert.ToInt32(idNum);
            int convertParentId = Convert.ToInt32(parentId);

            
            try
            {
                 regChild = childrenViewModel.getChildDetails(convertChildId,parentId);
            }
            catch(Exception)
            {

            }
                
                

                if(regChild != null)
                {
                    this.Frame.Navigate(typeof(EditedSelectedChildPage), regChild);
                    string msg = "Found the child in the database";
                    messageBox(msg);
                }
                else
                {
                    string msg = "Couldn't retrive child infomation from the database";
                    this.Frame.Navigate(typeof(SelectChildToViewPage));
                    messageBox(msg);
                }
            

            string chDetails = "" + idNum + "_" + name + "#" + age + "$" + grade + "%" + parentId;
            
        }

        private void btnZZZZZZZZ_Click(object sender, RoutedEventArgs e)
        {
            

        }

       

        
    }
}
