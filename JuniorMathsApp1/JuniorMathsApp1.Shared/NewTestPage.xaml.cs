using JuniorMathsApp1.TestClasses;
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

        int systemAnswer = 0;
        string childsAnswer = "";
        int convChildAnswer = 0;
        int countResult = 0;


        TestViewModel objTest = new TestViewModel();
        DateTime objDate = System.DateTime.Now;
        


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
           

            Random rnd = new Random();
            int numGen1 = (int)rnd.Next(1,13);

            return numGen1;
        }

        //Generate second random number
        public int getRandomNum2()
        {
            

            Random rnd2 = new Random();
            int numGen2 = (int)rnd2.Next(1,13);

            return numGen2;
        }

        //Choose operand
        public int getOperand()
        {
            Random rnd = new Random();
            int numGen3 = (int)rnd.Next(1,3);

            return numGen3;
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

        //Code for displaying MessageBox
        string msg = "";
        private async void messageBox(string msg)
        {
            var msgDisplay = new Windows.UI.Popups.MessageDialog(msg);
            await msgDisplay.ShowAsync();

        }

        private void btnCancelTest_Click(object sender, RoutedEventArgs e)
        {
            int getInsertResult = objTest.insertTestResults(childID, 0, 0, objDate.ToString());
            this.Frame.Navigate(typeof(MenuPage), parentID);
            msg = "You have cancelled the test!" +
                  "\nYour score for the test will be 0!";
            
            messageBox(msg);
        }

        private void btnStartTest_Click(object sender, RoutedEventArgs e)
        {
            btnSubmitAnswer.IsEnabled = true;
            btnCancelTest.IsEnabled = true;
            btnStartTest.IsEnabled = false;

            int cnt = doCalculation();
            lblCompletedQuestion.Text = "" + cnt;
        }


        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {

            
            countResult = doCalculation();

            lblCompletedQuestion.Text = "" + countResult;

            if(countResult > 10)
            {
                int getInsertResult = objTest.insertTestResults(childID, rightAnswer, wrongAnswers, objDate.ToString());


                this.Frame.Navigate(typeof(MenuPage), parentID);
                msg = "You have completed all questions for the test!" +
                      "\nGo to view results button to seee the score...";
                messageBox(msg);

            }

            
        }

        
        public int doCalculation()
        {
            try
            {
                    count = (count + 1);

                    getRandom1 = getRandomNum1();
                    getRandom2 = getRandomNum2();
                    
                    lblFirstNum.Text = "" + getRandom1;
                    lblSecondNum.Text = "" + getRandom2;

                    string strOperand = "";


                    int getTheOperand = getOperand();

                    if(getTheOperand == 1)
                    {
                        //Addition
                        strOperand = "+";
                        lblOperator.Text = strOperand;
                        systemAnswer = (getRandom1 + getRandom2);

                        //Code for checking whether the answer is correct
                        childsAnswer = txtEnterAnswer.Text;
                        convChildAnswer = Convert.ToInt32(childsAnswer);

                        if(systemAnswer == convChildAnswer)
                        {
                            rightAnswer = rightAnswer + 1;
                        }
                        else if(systemAnswer != convChildAnswer)
                        {
                            wrongAnswers = wrongAnswers + 1;
                        }

                    }
                    else if(getTheOperand == 2)
                    {
                        //Subtraction
                        strOperand = "-";
                        lblOperator.Text = strOperand;

                        if(getRandom1 > getRandom2)
                        {
                            systemAnswer = (getRandom1 - getRandom2);

                            //Code for checking whether the answer is correct
                            childsAnswer = txtEnterAnswer.Text;
                            convChildAnswer = Convert.ToInt32(childsAnswer);
                            if (systemAnswer == convChildAnswer)
                            {
                                rightAnswer = rightAnswer + 1;
                            }
                            else if (systemAnswer != convChildAnswer)
                            {
                                wrongAnswers = wrongAnswers + 1;
                            }
                        }
                        else if(getRandom1 < getRandom2)
                        {
                            systemAnswer = (getRandom2 - getRandom1);

                            //Code for checking whether the answer is correct
                            childsAnswer = txtEnterAnswer.Text;
                            convChildAnswer = Convert.ToInt32(childsAnswer);
                            if (systemAnswer == convChildAnswer)
                            {
                                rightAnswer = rightAnswer + 1;
                            }
                            else if(systemAnswer != convChildAnswer)
                            {
                                wrongAnswers = wrongAnswers + 1;
                            }
                        }
                        else if(getRandom1 == getRandom2)
                        {
                            systemAnswer = (getRandom1 - getRandom2);

                            //Code for checking whether the answer is correct
                            childsAnswer = txtEnterAnswer.Text;
                            convChildAnswer = Convert.ToInt32(childsAnswer);
                            if (systemAnswer == convChildAnswer)
                            {
                                rightAnswer = rightAnswer + 1;
                            }
                            else if (systemAnswer != convChildAnswer)
                            {
                                wrongAnswers = wrongAnswers + 1;
                            }
                        }

                    }
                    else if(getTheOperand == 3)
                    {

                        //Multiplication
                        strOperand = "x";
                        lblOperator.Text = strOperand;
                        systemAnswer = (getRandom1 * getRandom2);

                        //Code for checking whether the answer is correct
                        childsAnswer = txtEnterAnswer.Text;
                        convChildAnswer = Convert.ToInt32(childsAnswer);
                        if (systemAnswer == convChildAnswer)
                        {
                            rightAnswer=+1;
                        }
                        else if(systemAnswer != convChildAnswer)
                        {
                            wrongAnswers =+1;
                        }
                    }

                    txtRight.Text = "" + rightAnswer;
                    txtWrong.Text = "" + wrongAnswers;

                
            }
            catch (Exception)
            {

            }

            return count;
        }




    }
}
