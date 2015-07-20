using JuniorMathsApp1.ChildrenClasses;
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

        int parentId = 0;

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

                foreach (var c in children)
                {
                    lsViewChildren.Items.Add(c.Name + " " + c.Surname);
                }

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

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ViewAllResultsPage));
        }
    }
}
