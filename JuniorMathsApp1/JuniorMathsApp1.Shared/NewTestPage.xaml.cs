
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
        int incrementQuestions = 0;


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

        //Button to initiate a new test 
        private void btnStartTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                incrementQuestions = incrementQuestions + 1;
                count = (count + 1);
                int systemAnswer = 0;

                //get the random number to select a random question: Conver the number to a string
                int getQuest = getRandomQuestion();
                string getQuestString = getQuest.ToString();

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

                        string msg = "Please select a difficulty level first before proceeding!";
                        messageBox(msg);
                    }
                    else
                    {
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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = "" + answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;
                                        

                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;
                                        

                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;

                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

                        }


                        lblCompletedQuestion.Text = "" + count;


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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = "" + answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;


                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;


                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;

                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

                        }


                        lblCompletedQuestion.Text = "" + count;


                    }
                }




            }
            catch (Exception)
            {

            }


        }

        //Button to submit the answer
        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            countResult = doCalculation();

            lblCompletedQuestion.Text = "" + countResult;

            if (countResult >= 10)
            {
                int getInsertResult = objTest.insertTestResults(childID, rightAnswer, wrongAnswers, objDate.ToString());


                this.Frame.Navigate(typeof(MenuPage), parentID);
                msg = "You have completed all questions for the test!" +
                      "\nGo to view results button to seee the score...";
                messageBox(msg);

            }


        }


        //Method to decide the type of question to be presented to the child
        public int doCalculation()
        {
            try
            {
                incrementQuestions = incrementQuestions + 1;
                count = (count + 1);
                //get the random number to select a random question: Conver the number to a string
                int getQuest = getRandomQuestion();
                string getQuestString = getQuest.ToString();

                //get the childs grade
                string childGrade = objRegChild.Grade;

                if (childGrade.Equals("Grade 1"))
                {
                    //Get the selected test difficulty
                    string getTestDifficulty = "" + cbTestDifficulty.SelectedItem;

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
                            string equation = "";
                            string answer1 = "";
                            string childsAnswer1 = "";

                            int fullLength = numberOne.Value.Length;
                            id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                            equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("=") - 1);
                            answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                            //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                            if (id.Equals("" + incrementQuestions))
                            {

                                try
                                {
                                    //Display the equation and allow user to enter the answer
                                    lblEquation.Text = equation;
                                    txtEnterAnswer.Text = "" + answer1;
                                    childsAnswer1 = txtEnterAnswer.Text;

                                    int convertSysterAnswer = Convert.ToInt32(answer1);
                                    int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                    //Code for checking whether the answer is correct
                                    if (convertSysterAnswer == convertChildAnswer)
                                    {
                                        rightAnswer = rightAnswer + 1;
                                    }
                                    else
                                    {
                                        wrongAnswers = wrongAnswers + 1;
                                    }
                                    txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                    txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                }
                                catch (Exception)
                                {

                                }


                            }

                        }

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
                            string equation = "";
                            string answer1 = "";
                            string childsAnswer1 = "";

                            int fullLength = numberOne.Value.Length;
                            id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                            equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                            answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                            //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                            if (id.Equals("" + incrementQuestions))
                            {

                                try
                                {
                                    //Display the equation and allow user to enter the answer
                                    lblEquation.Text = equation;
                                    txtEnterAnswer.Text = answer1;
                                    childsAnswer1 = txtEnterAnswer.Text;
                                    

                                    int convertSysterAnswer = Convert.ToInt32(answer1);
                                    int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                    //Code for checking whether the answer is correct
                                    if (convertSysterAnswer == convertChildAnswer)
                                    {
                                        rightAnswer = rightAnswer + 1;
                                    }
                                    else
                                    {
                                        wrongAnswers = wrongAnswers + 1;
                                    }
                                    txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                    txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                }
                                catch (Exception)
                                {

                                }


                            }

                        }

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
                            string equation = "";
                            string answer1 = "";
                            string childsAnswer1 = "";

                            int fullLength = numberOne.Value.Length;
                            id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                            equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                            answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                            //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                            if (id.Equals("" + incrementQuestions))
                            {

                                try
                                {
                                    //Display the equation and allow user to enter the answer
                                    lblEquation.Text = equation;
                                    txtEnterAnswer.Text = answer1;
                                    childsAnswer1 = txtEnterAnswer.Text;
                                    

                                    int convertSysterAnswer = Convert.ToInt32(answer1);
                                    int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                    //Code for checking whether the answer is correct
                                    if (convertSysterAnswer == convertChildAnswer)
                                    {
                                        rightAnswer = rightAnswer + 1;
                                    }
                                    else
                                    {
                                        wrongAnswers = wrongAnswers + 1;
                                    }

                                    txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                    txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";

                                }
                                catch (Exception)
                                {

                                }


                            }

                        }

                    }



                    lblCompletedQuestion.Text = "" + count;







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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = "" + answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;


                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;


                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

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
                                string equation = "";
                                string answer1 = "";
                                string childsAnswer1 = "";

                                int fullLength = numberOne.Value.Length;
                                id = numberOne.Value.Substring(0, numberOne.Value.IndexOf("."));
                                equation = numberOne.Value.Substring(numberOne.Value.IndexOf(".") + 1, numberOne.Value.IndexOf("="));
                                answer1 = numberOne.Value.Substring(numberOne.Value.IndexOf("=") + 1);

                                //lstTeams.Items.Add(id +"*" + num1 + " Last number is:"+ num2);


                                if (id.Equals("" + incrementQuestions))
                                {

                                    try
                                    {
                                        //Display the equation and allow user to enter the answer
                                        lblEquation.Text = equation;
                                        txtEnterAnswer.Text = answer1;
                                        childsAnswer1 = txtEnterAnswer.Text;

                                        int convertSysterAnswer = Convert.ToInt32(answer1);
                                        int convertChildAnswer = Convert.ToInt32(childsAnswer1);

                                        //Code for checking whether the answer is correct
                                        if (convertSysterAnswer == convertChildAnswer)
                                        {
                                            rightAnswer = rightAnswer + 1;
                                        }
                                        else
                                        {
                                            wrongAnswers = wrongAnswers + 1;
                                        }
                                        txtRight.Text = "Number Of Correct Answers: (" + rightAnswer + ")";
                                        txtWrong.Text = "Number Of Wrong Answers: (" + wrongAnswers + ")";


                                    }
                                    catch (Exception)
                                    {

                                    }


                                }

                            }

                        }


                        lblCompletedQuestion.Text = "" + count;


                    }
                }


            }
            catch (Exception)
            {

            }

            return count;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SelectChildToTakeTestPage), parentID);
        }




    }
}