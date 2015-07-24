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
    public sealed partial class MenuPage : Page
    {

        int getTheId = 0;
        public MenuPage()
        {
            this.InitializeComponent();
        }
        
        public void getID(int id)
        {
            
                getTheId = id;
            
        }

        //Display the ID of the parent currently logged in
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                getTheId = (int)e.Parameter;

                txtParentIden.Text = "" + getTheId;
            }
            catch(Exception)
            {

            }
           

        }


        private void btnStartTest_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectChildToTakeTestPage), getTheId);
        }

        private void btnEditChildDetails_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof());
        }

        //Button for logging out from user account 
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

       
        private void btnRegisterNewChild_Click(object sender, RoutedEventArgs e)
        {
            if(getTheId != 0)
            {
                this.Frame.Navigate(typeof(RegisterNewChild), getTheId);
            }
            else
            {
                this.Frame.Navigate(typeof(MenuPage));
            }
            
        }

        private void btnAboutApp_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutAppPage));
        }

        private void btnViewTestResults_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectChildToViewPage), getTheId);
        }

       

        

       
    }
}
