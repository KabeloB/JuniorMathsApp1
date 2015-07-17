using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.ParentClasses;
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
    public sealed partial class ShowPage : Page
    {
        ObservableCollection<ParentViewModel> parents = null;
        ParentsViewModel parentsViewModel = null;

        ObservableCollection<ChildrenViewModel> children = null;
        ChildrensViewModel childrensViewModel = null;

        public ShowPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            parentsViewModel = new ParentsViewModel();
            parents = parentsViewModel.GetParents();

            childrensViewModel = new ChildrensViewModel();
            children = childrensViewModel.GetChildren();

            foreach(var p in parents)
            {
                listView.Items.Add(p.Name + " " + p.Surname + " " + p.Email);
            }
            


            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
