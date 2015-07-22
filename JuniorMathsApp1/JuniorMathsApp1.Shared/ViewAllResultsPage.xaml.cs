using JuniorMathsApp1.ChildrenClasses;
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

        ObservableCollection<TestViewModel> test = null;
        TestsViewModel testsViewModel = null;

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

                parentID = Convert.ToInt32(getIds.Substring(0, 1));
                childID = Convert.ToInt32(getIds.Substring(2));

                test = testsViewModel.GetTests(childID);

                lsViewTest.Items.Add("Test ID" + "\t" + "Child ID" + "\t" + "# Right Answers" + "\t" + "# Wrong Answers" + "\t" + "Date of Test");

                foreach (var c in test)
                {
                    lsViewTest.Items.Add(c.Id + "\t" + c.ChildId + "\t" + c.RightAnswers + "\t" + c.WrongAnswers + "\t" + c.Date);

                }
                base.OnNavigatedTo(e);

            }
            catch (Exception)
            {

            }


        }



        private void btnReturnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MenuPage), parentID);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectChildToViewPage), parentID);
        }

    }
}
