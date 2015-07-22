using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.Model;
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
    public sealed partial class SelectChildToViewPage : Page
    {
        ObservableCollection<ChildrenViewModel> children = null;
        ChildrensViewModel childrensViewModel = null;
        RegisterChild regChild = null;

        int parentId = 0;
        int selectedChildId = 0;


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


                
                /*
                for (int p = 0; p < children.Count; p++)
                {
                    
                    lsViewChildren.ItemsSource = children;
                    
                    var getItem = children.ElementAt<ChildrenViewModel>(p);
                    selectedChildId = getItem.Id;
                }
                */
                lsViewChildren.Items.Add("ID" + "\t" + "NAME & SURNAME");
                foreach (var c in children)
                {
                   lsViewChildren.Items.Add(c.Id + "\t" + c.Name + " " + c.Surname);


                   //Retrive selecte element from listView
                   regChild = (RegisterChild)lsViewChildren.SelectedValue;
                }

                regChild = (RegisterChild) lsViewChildren.SelectedValue;
                
               
                base.OnNavigatedTo(e);

            }
            catch (Exception)
            {

            }
            
            
        }



        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage), parentId);
        }

        //Get the select item from the user
        private void lsViewChildren_ItemClick(object sender, ItemClickEventArgs e)
        {
           getSelectedItem = (int) e.ClickedItem;

           //regChild = (RegisterChild) getSelectedItem;

        }


        private void btnView_Click(object sender, RoutedEventArgs e)
        {

            txtDisplayName.Text = "" + getSelectedItem + " ID: " + regChild.Id;

            //this.Frame.Navigate(typeof(ViewAllResultsPage));

        }

       

        
    }
}
