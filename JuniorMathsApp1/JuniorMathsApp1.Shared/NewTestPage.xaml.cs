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
    public sealed partial class NewTestPage : Page
    {

        string getIds = "";
        int parentID = 0;
        int childID = 0;


        int getRandom1 = 0;
        int getRandom2 = 0;

        
        int count = 0;
        int rightAnswer = 0;
        int wrongAnswers = 0;

      
        //int number = rnd.Next(1, 13);
        


        public NewTestPage()
        {
            this.InitializeComponent();

            btnSubmitAnswer.IsEnabled = false;
            btnCancelTest.IsEnabled = false; 
            Random rnd = new Random();
            int num = (int) rnd.Next(1,13);
        }

        //Generate first random number
        public int getRandomNum1()
        {
            this.InitializeComponent();

            Random rnd = new Random();
            int numGen = (int)rnd.Next(1, 13);

            return numGen;
        }

        //Generate second random number
        public int getRandomNum2()
        {
            this.InitializeComponent();

            Random rnd = new Random();
            int numGen = (int)rnd.Next(1, 13);

            return numGen;
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            try
            {
                base.OnNavigatedTo(e);
                getIds = (string)e.Parameter;

                parentID = Convert.ToInt32(getIds.Substring(0, 1));
                childID = Convert.ToInt32(getIds.Substring(2));

                base.OnNavigatedTo(e);

            }
            catch (Exception)
            {

            }


        }

        public int testDetails(int count)
        {
            int getCount = count;


            btnCancelTest.IsEnabled = true;
            return getCount;
        }



        private void btnCancelTest_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnStartTest_Click(object sender, RoutedEventArgs e)
        {
            btnSubmitAnswer.IsEnabled = true;
            btnCancelTest.IsEnabled = true;
            btnStartTest.IsEnabled = false;

            getRandom1 = getRandomNum1();
            getRandom2 = getRandomNum2();

            lblFirstNum.Text = "" + getRandom1;
            lblSecondNum.Text = "" + getRandom2;

            lblCompletedQuestion.Text = "" + (count + 1);
        }


        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            
            while(count < 11)
            {
                lblFirstNum.Text = "" + getRandom1;
                lblSecondNum.Text = "" + getRandom2;

                int systemAnswer = (getRandom1 + getRandom2);
                string childsAnswer = txtEnterAnswer.Text;
                int convChildAnswer = Convert.ToInt32(childsAnswer);



                if (systemAnswer == convChildAnswer)
                {
                    rightAnswer = rightAnswer + 1;
                }
                else
                {
                    wrongAnswers = wrongAnswers + 1;
                }

                getRandom1 = getRandomNum1();
                getRandom2 = getRandomNum2();


            }
            
        }
    }
}
