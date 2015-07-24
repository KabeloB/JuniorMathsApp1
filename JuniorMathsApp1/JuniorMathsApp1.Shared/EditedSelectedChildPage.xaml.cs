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
        string age = "";
        string grade = "";
        string parentID = "";

        public EditedSelectedChildPage()
        {
            this.InitializeComponent();
        }


        //Display the ID of the parent currently logged in
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                base.OnNavigatedTo(e);
                getData = (string)e.Parameter;

                idNum = getData.Substring(0, 1);
                name = getData.Substring(2, getData.IndexOf("_") - 2);
                age = getData.Substring(getData.IndexOf("#"), getData.IndexOf("$"));
                grade = getData.Substring(getData.IndexOf("$"), getData.IndexOf("%"));
                parentID = getData.Substring(getData.IndexOf("%"), getData.Length);

                //displayChildsDetails(idNum, name, age, grade);
            }
            catch (Exception)
            {

            }


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
            string id = lblChildsID.Text;
            string newName = txtCurrentChildName.Text;
            string newAge = txtCurrentChildName.Text;
            string getGrade = (string)cbCurrentChildGrade.SelectedItem;
            
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            lblChildsID.Text = idNum;
            txtCurrentChildName.Text = getData;
            txtCurrentChildAge.Text = age;

            cbCurrentChildGrade.Items.Add(grade);
            cbCurrentChildGrade.Items.Add("");
            cbCurrentChildGrade.Items.Add("grade1");
            cbCurrentChildGrade.Items.Add("grade2");
        }

    }
}
