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
    public sealed partial class UpdateParentsDetailsPage : Page
    {
        ParentViewModel objParentViewModel = null;
        Register objRegister = null;

        int parentId = 0;
        string msg = "";



        public UpdateParentsDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {
                base.OnNavigatedTo(e);
                parentId = (int)e.Parameter;

                objParentViewModel = new ParentViewModel();
                objRegister = new Register();

                objRegister = objParentViewModel.getParentDetails(parentId);

                lblParentID.Text = "" + objRegister.Id;
                txtEnterNewName.Text = "" + objRegister.Name;
                txtEnterNewSurname.Text = "" + objRegister.Surname;
                txtEnterNewEmail.Text = "" + objRegister.Email;
                txtEnterNewPhoneNo.Text = "" + objRegister.PhoneNo;
                txtEnterNewPassword.Text = "" + objRegister.Password;




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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string getId = lblParentID.Text;
            int convID = Convert.ToInt32(getId);
            string updateName = txtEnterNewName.Text;
            string updateSurname = txtEnterNewSurname.Text;
            string updateEmail = txtEnterNewEmail.Text;
            string updatePhone = txtEnterNewPhoneNo.Text;
            string updatePassword = txtEnterNewPassword.Text;

            if ((!updateName.Equals("")) && (!updateSurname.Equals("")) && (!updateEmail.Equals("")) && (!updatePhone.Equals("")) && (!updatePassword.Equals("")))
            {
                objRegister = new Register();
                int updateResult = 0;
                objParentViewModel = new ParentViewModel();

                try
                {
                    updateResult = objParentViewModel.updateParentDetails(convID, updateName, updateSurname, updateEmail, updatePhone, updatePassword);
                }
                catch (Exception)
                {

                }

                if (updateResult > 0)
                {
                    this.Frame.Navigate(typeof(MenuPage), parentId);
                    msg = "Update was successful!";
                    messageBox(msg);
                }
                else
                {
                    msg = "Update was unsuccessful!";
                    messageBox(msg);
                }
            }
            else
            {
                msg = "Please ensure that all text fields are filled in!";
                messageBox(msg);
            }
        }


    }  
}
