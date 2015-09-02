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
using Windows.UI;
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
    public sealed partial class SelectChildToTakeTestPage : Page
    {
        ObservableCollection<ChildrenViewModel> children = null;
        ChildrensViewModel childrensViewModel = null;
        RegisterChild regChild = null;

        int parentId = 0;
        int selectedChildId = 0;

        public SelectChildToTakeTestPage()
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

                lsvChooseChild.Items.Add("ID" + "-" + "NAME_SURNAME");

                foreach(var c in children)
                {
                    lsvChooseChild.Items.Add(c.Id + "-" + c.Name + "_" + c.Surname);

                    selectedChildId = c.Id;
                    //Retrive selecte element from listView
                    //regChild = (RegisterChild)lsViewChildren.SelectedValue;
                }

                //var sel = lsViewChildren.SelectedItems.Cast<Object>.ToArray();
                regChild = (RegisterChild)lsvChooseChild.SelectedValue;


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
        
        private void lsvChooseChild_ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("Click!");
        }
        
        string objItems = "";
        string idNum = "";
        string name = "";
        string msg = "";
        private void MySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine("Selected: {0}", e.AddedItems[0]);
            objItems = "" + e.AddedItems[0];
            idNum = objItems.Substring(0, objItems.IndexOf("-"));
            name = objItems.Substring(2, objItems.IndexOf("_") - 2);

            //Change background color of selected item in listview
            Brush SelectedBrush = new SolidColorBrush((Color)App.Current.Resources["SystemColorControlAccentColor"]);
            Brush NormalBrush = new SolidColorBrush(Colors.Transparent);
            for (int i = 0; i < lsvChooseChild.Items.Count; i++)
            {
                ListViewItem Item = lsvChooseChild.ContainerFromIndex(i) as ListViewItem;
                Item.Background = Item.IsSelected ? SelectedBrush : NormalBrush;
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            int convNum = 0;
            try
            {
                int verifyNum;
                bool isNumerical = int.TryParse(idNum, out verifyNum);

                if (idNum.Equals("") || isNumerical == false)
                {
                    msg = "Please select a child first before proceeding with the test!";
                    messageBox(msg);
                }
                else
                {
                    convNum = Convert.ToInt32(idNum);

                    if (convNum <= 0)
                    {
                        msg = "Please select a child first before proceeding with the test!";
                        messageBox(msg);
                    }
                    else
                    {
                        string objToSend = "" + parentId + "#" + idNum;
                        this.Frame.Navigate(typeof(NewTestPage), objToSend);
                    }
           
                }
                
            }
            catch(Exception)
            {

            }

            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage), parentId);
        }

        
    }
}
