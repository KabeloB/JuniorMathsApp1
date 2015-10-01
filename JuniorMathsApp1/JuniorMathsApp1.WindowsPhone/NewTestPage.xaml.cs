
using JuniorMathsApp1.ChildrenClasses;
using JuniorMathsApp1.Model;
using JuniorMathsApp1.TestClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
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


        int convChildAnswer = 0;

        int countResult = 0;
        int completedQuestions = 0;
        string storeAnswer = "";

        bool outOfTime = false;

        string[] equation = new string[10];
        string[] answerArray = new string[10];

        List<string> listEquations = new List<string>();
        List<string> listAnswer = new List<string>();
        

        int h, m, s;
        private DispatcherTimer timer = new DispatcherTimer();

        TestViewModel objTest = new TestViewModel();
        ChildrenViewModel objChildrenViewModel = null;
        RegisterChild objRegChild = null;
        DateTime objDate = System.DateTime.Now;

        public NewTestPage()
        {
            this.InitializeComponent();
            btnSubmitAnswer.IsEnabled = false;
            btnCancelTest.IsEnabled = false;
            btnBack.IsEnabled = true;
            txtEnterAnswer.IsEnabled = false;

            Random rnd = new Random();
            int num = (int)rnd.Next(1, 13);

            cbTestDifficulty.Items.Add("");
            cbTestDifficulty.Items.Add("Biginner");
            cbTestDifficulty.Items.Add("Intermediate");
            cbTestDifficulty.Items.Add("Advanced");


            timer.Tick += Each_Tick;
            
        }

        

        //Retrive random questions from the xml file
        public int getRandomQuestion()
        {
            Random rnd = new Random();
            int numQuestion = (int)rnd.Next(1, 11);

            return numQuestion;
        }


        //Generate first random number
        public int getRandomNum1()
        {


            Random rnd = new Random();
            int numGen1 = (int)rnd.Next(1, 13);

            return numGen1;
        }

        //Generate second random number
        public int getRandomNum2()
        {


            Random rnd2 = new Random();
            int numGen2 = (int)rnd2.Next(1, 13);

            return numGen2;
        }

        //Choose operand
        public int getOperand()
        {
            Random rnd = new Random();
            int numGen3 = (int)rnd.Next(1, 4);

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

                objRegChild = new RegisterChild();
                objChildrenViewModel = new ChildrenViewModel();

                objRegChild = objChildrenViewModel.getChildDetails(childID, parentID);

                base.OnNavigatedTo(e);

            }
            catch (Exception)
            {

            }


        }

        public void Each_Tick(object sender, object e)
        {
            s = s - 1;
            if(s == -1)
            {
                m = m - 1;
                s = 59;
            }


            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }

            if ((h == 0) &&(m == 0) && (s == 0))
            {
                timer.Stop();
                outOfTime = true;
            }

            if (outOfTime == true)
            {
                int autoWrong = 10 - rightAnswer;
                int getInsertResult = objTest.insertTestResults(childID, rightAnswer, autoWrong, objDate.ToString());


                this.Frame.Navigate(typeof(MenuPage), parentID);
                msg = "Sorry!" +
                      "\nYou ran out of time..." + 
                      "\nNavigate to test results to view score.";
                messageBox(msg);
            }

            lblTimeRemaining.Text = h + "min " + m + "sec";
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
            timer.Stop();
            msg = "You have cancelled the test!" +
                  "\nYour score for the test will be 0!";

            messageBox(msg);
        }

        //Button to initiate a new test 
        int countIndex = 0;
        int sendAnswer = 0;
        int incrementArray = 0;

        private void btnStartTest_Click(object sender, RoutedEventArgs e)
        {

            if(objRegChild.Grade.Equals("Grade 1"))
            {
                //Allocated time to finish test in minutes
                h = 5;
            }
            else
            {
                h = 3;
            }

            
            m = 0;
            s = 0;

            
            try
            {
                //get the random number to select a random question: Conver the number to a string
                //int getQuest = getRandomQuestion();
                //string getQuestString = getQuest.ToString();

                //get the childs grade
                string childGrade = objRegChild.Grade;

                if (childGrade.Equals("Grade 1"))
                {
                    //Get the selected test difficulty
                    string getTestDifficulty = "" + cbTestDifficulty.SelectedItem;

                    if (getTestDifficulty.Equals(""))
                    {
                        btnSubmitAnswer.IsEnabled = false;
                        btnCancelTest.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        txtEnterAnswer.IsEnabled = false;

                       

                        string msg = "Please select a difficulty level first before proceeding with the test!";
                        messageBox(msg);
                    }
                    else
                    {
                        timer.Start();

                        //Put this block of code in the ELSE BLOCK
                        if (getTestDifficulty.Equals("Biginner"))
                        {
                            btnSubmitAnswer.IsEnabled = true;
                            btnCancelTest.IsEnabled = true;
                            btnBack.IsEnabled = false;
                            txtEnterAnswer.IsEnabled = true;
                            cbTestDifficulty.IsEnabled = false;
                            btnStartTest.IsEnabled = false;


                            XDocument doc = XDocument.Load(@"Grade1QuestionsXML\Beginner.xml");
                            var number1 = doc.Descendants("Number");
                            var answer = doc.Descendants("Answer");

                            foreach (var numberOne in number1)
                            {
                                string id = "";
                                string equation1 = "";
                                string answer1 = "";


                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                int convertXMLid = Convert.ToInt32(id);

                                equation1 = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                listEquations.Add(equation1); 
                                listAnswer.Add(answer1);
                                
                                countIndex = countIndex + 1;
                            }

                            storeAnswer = "" + listAnswer.ElementAt(0);
                            lblEquation.Text = "" + listEquations.ElementAt(0);
                        }
                        else if (getTestDifficulty.Equals("Intermediate"))
                        {
                            XDocument doc = XDocument.Load(@"Grade1QuestionsXML2\Medium.xml");
                            var number2 = doc.Descendants("Number");
                            var answer = doc.Descendants("Answer");

                            btnSubmitAnswer.IsEnabled = true;
                            btnCancelTest.IsEnabled = true;
                            btnBack.IsEnabled = false;
                            txtEnterAnswer.IsEnabled = true;
                            cbTestDifficulty.IsEnabled = false;
                            btnStartTest.IsEnabled = false;

                            foreach (var numberOne in number2)
                            {
                                string id = "";
                                string equation1 = "";
                                string answer1 = "";


                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                int convertXMLid = Convert.ToInt32(id);

                                equation1 = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                listEquations.Add(equation1);
                                listAnswer.Add(answer1);

                                countIndex = countIndex + 1;

                            }

                            storeAnswer = "" + listAnswer.ElementAt(0);
                            lblEquation.Text = "" + listEquations.ElementAt(0);


                        }
                        else if (getTestDifficulty.Equals("Advanced"))
                        {
                            XDocument doc = XDocument.Load(@"Grade1QuestionsXML3\Advanced.xml");
                            var number3 = doc.Descendants("Number");
                            var answer = doc.Descendants("Answer");

                            btnSubmitAnswer.IsEnabled = true;
                            btnCancelTest.IsEnabled = true;
                            btnBack.IsEnabled = false;
                            txtEnterAnswer.IsEnabled = true;
                            cbTestDifficulty.IsEnabled = false;
                            btnStartTest.IsEnabled = false;

                            foreach (var numberOne in number3)
                            {
                                string id = "";
                                string equation1 = "";
                                string answer1 = "";


                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                int convertXMLid = Convert.ToInt32(id);

                                equation1 = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                listEquations.Add(equation1);
                                listAnswer.Add(answer1);

                                countIndex = countIndex + 1;

                            }

                            storeAnswer = "" + listAnswer.ElementAt(0);
                            lblEquation.Text = "" + listEquations.ElementAt(0);

                        }


                        


                    }

                }
                else if (childGrade.Equals("Grade 2"))
                {
                    //Get the selected test difficulty
                    string getTestDifficulty = "" + cbTestDifficulty.SelectedItem;

                    if (getTestDifficulty.Equals(""))
                    {
                        btnSubmitAnswer.IsEnabled = false;
                        btnCancelTest.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        txtEnterAnswer.IsEnabled = false;

                        string msg = "Please select a difficulty level first before proceeding!";
                        messageBox(msg);
                    }
                    else
                    {
                        timer.Start();

                        //Put this block of code in the ELSE BLOCK
                        if (getTestDifficulty.Equals("Biginner"))
                        {
                            btnSubmitAnswer.IsEnabled = true;
                            btnCancelTest.IsEnabled = true;
                            btnBack.IsEnabled = false;
                            txtEnterAnswer.IsEnabled = true;
                            cbTestDifficulty.IsEnabled = false;
                            btnStartTest.IsEnabled = false;


                            XDocument doc = XDocument.Load(@"Grade2QuestionsXML\Beginner.xml");
                            var number1 = doc.Descendants("Number");
                            var answer = doc.Descendants("Answer");

                            foreach (var numberOne in number1)
                            {
                                string id = "";
                                string equation1 = "";
                                string answer1 = "";


                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                int convertXMLid = Convert.ToInt32(id);

                                equation1 = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                listEquations.Add(equation1);
                                listAnswer.Add(answer1);

                                countIndex = countIndex + 1;

                            }

                            storeAnswer = "" + listAnswer.ElementAt(0);
                            lblEquation.Text = "" + listEquations.ElementAt(0);



                        }
                        else if (getTestDifficulty.Equals("Intermediate"))
                        {
                            XDocument doc = XDocument.Load(@"Grade2QuestionsXML2\Medium.xml");
                            var number2 = doc.Descendants("Number");
                            var answer = doc.Descendants("Answer");

                            btnSubmitAnswer.IsEnabled = true;
                            btnCancelTest.IsEnabled = true;
                            btnBack.IsEnabled = false;
                            txtEnterAnswer.IsEnabled = true;
                            cbTestDifficulty.IsEnabled = false;
                            btnStartTest.IsEnabled = false;

                            foreach (var numberOne in number2)
                            {
                                string id = "";
                                string equation1 = "";
                                string answer1 = "";


                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                int convertXMLid = Convert.ToInt32(id);

                                equation1 = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                listEquations.Add(equation1);
                                listAnswer.Add(answer1);

                                countIndex = countIndex + 1;

                            }

                            storeAnswer = "" + listAnswer.ElementAt(0);
                            lblEquation.Text = "" + listEquations.ElementAt(0);

                        }
                        else if (getTestDifficulty.Equals("Advanced"))
                        {
                            XDocument doc = XDocument.Load(@"Grade2QuestionsXML3\Advanced.xml");
                            var number3 = doc.Descendants("Number");
                            var answer = doc.Descendants("Answer");

                            btnSubmitAnswer.IsEnabled = true;
                            btnCancelTest.IsEnabled = true;
                            btnBack.IsEnabled = false;
                            txtEnterAnswer.IsEnabled = true;
                            cbTestDifficulty.IsEnabled = false;
                            btnStartTest.IsEnabled = false;

                            foreach (var numberOne in number3)
                            {
                                string id = "";
                                string equation1 = "";
                                string answer1 = "";


                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                int convertXMLid = Convert.ToInt32(id);

                                equation1 = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                listEquations.Add(equation1);
                                listAnswer.Add(answer1);

                                countIndex = countIndex + 1;

                            }

                            storeAnswer = "" + listAnswer.ElementAt(0);
                            lblEquation.Text = "" + listEquations.ElementAt(0);



                        }


                       


                    }
                }




            }
            catch (Exception)
            {

            }


        }


        int nextQuestionCount = 0;
        //Button to submit the answer
        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string getUserAnswer = txtEnterAnswer.Text;

                //Check whether input is numeric 
                int verifyNum;
                bool isNumerical = int.TryParse(getUserAnswer, out verifyNum);

                //check if user answer is entered
                if(!getUserAnswer.Equals(""))
                {
                    if (isNumerical == true)
                    {
                        int convUserAnswer = Convert.ToInt32(getUserAnswer);

                        int convSystemAnswer = Convert.ToInt32(storeAnswer);

                        if (convUserAnswer == convSystemAnswer)
                        {
                            txtRight.Text = "Correct Answers: " + (rightAnswer = rightAnswer + 1) ;

                        }
                        else
                        {
                            txtWrong.Text = "Wrong Answers: " + (wrongAnswers = wrongAnswers + 1);
                        }


                        completedQuestions = completedQuestions + 1;
                        lblCount.Text = "" + completedQuestions;

                        if (completedQuestions >= 10)
                        {
                            int getInsertResult = objTest.insertTestResults(childID, rightAnswer, wrongAnswers, objDate.ToString());

                            timer.Stop();
                            this.Frame.Navigate(typeof(MenuPage), parentID);
                            listAnswer = new List<string>();
                            listEquations = new List<string>();
                            msg = "You have completed all questions for the test!" +
                                  "\nNavigate to view results to display the score...";
                            messageBox(msg);

                        }
                        else
                        {
                            incrementArray = incrementArray + 1;
                            countIndex = countIndex + 1;
                            nextQuestionCount = nextQuestionCount + 1;
                            txtEnterAnswer.Text = "";
                            doCalculation();
                        }

                        
                    }
                    else
                    {
                        msg = "Please ensure that the answer entered is numeric!";
                        messageBox(msg);
                    }
                }
                else
                {
                    msg = "Please enter an answer before proceeding!";
                    messageBox(msg);
                }
               
            }
            catch(Exception ex)
            {
                
            }
            


        }


        //Method to retrieve the remaining question
        public void doCalculation()
        {
            try
            {
                //get the random number to select a random question: Conver the number to a string
                //int getQuest = getRandomQuestion();
                //string getQuestString = getQuest.ToString();

                //get the childs grade
                string childGrade = objRegChild.Grade;

                if (childGrade.Equals("Grade 1"))
                {
                    //Get the selected test difficulty
                    string getTestDifficulty = "" + cbTestDifficulty.SelectedItem;

                    if (getTestDifficulty.Equals(""))
                    {
                        btnSubmitAnswer.IsEnabled = false;
                        btnCancelTest.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        txtEnterAnswer.IsEnabled = false;

                        string msg = "Please select a difficulty level first before proceeding with the test!";
                        messageBox(msg);
                    }
                    else
                    {
                        //Put this block of code in the ELSE BLOCK
                        if (getTestDifficulty.Equals("Biginner"))
                        {
                                storeAnswer = "" + listAnswer.ElementAt(nextQuestionCount);

                                lblEquation.Text = "" + listEquations.ElementAt(nextQuestionCount);
                            
                        }
                        else if (getTestDifficulty.Equals("Intermediate"))
                        {
                            storeAnswer = "" + listAnswer.ElementAt(nextQuestionCount);

                            lblEquation.Text = "" + listEquations.ElementAt(nextQuestionCount);

                        }
                        else if (getTestDifficulty.Equals("Advanced"))
                        {
                            storeAnswer = "" + listAnswer.ElementAt(nextQuestionCount);

                            lblEquation.Text = "" + listEquations.ElementAt(nextQuestionCount);

                        }


                        


                    }




                }
                else if (childGrade.Equals("Grade 2"))
                {
                    //Get the selected test difficulty
                    string getTestDifficulty = "" + cbTestDifficulty.SelectedItem;

                    if (getTestDifficulty.Equals(""))
                    {
                        btnSubmitAnswer.IsEnabled = false;
                        btnCancelTest.IsEnabled = false;
                        btnBack.IsEnabled = true;
                        txtEnterAnswer.IsEnabled = false;

                        string msg = "Please select a difficulty level first before proceeding!";
                        messageBox(msg);
                    }
                    else
                    {
                        //Put this block of code in the ELSE BLOCK
                        if (getTestDifficulty.Equals("Biginner"))
                        {
                            storeAnswer = "" + listAnswer.ElementAt(nextQuestionCount);

                            lblEquation.Text = "" + listEquations.ElementAt(nextQuestionCount);

                        }
                        else if (getTestDifficulty.Equals("Intermediate"))
                        {
                            storeAnswer = "" + listAnswer.ElementAt(nextQuestionCount);

                            lblEquation.Text = "" + listEquations.ElementAt(nextQuestionCount);

                        }
                        else if (getTestDifficulty.Equals("Advanced"))
                        {
                            storeAnswer = "" + listAnswer.ElementAt(nextQuestionCount);

                            lblEquation.Text = "" + listEquations.ElementAt(nextQuestionCount);
                        }


                        


                    }
                }




            }
            catch (Exception ex)
            {
                messageBox("Error found: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectChildToTakeTestPage), parentID);
            
        }

        
    }
}