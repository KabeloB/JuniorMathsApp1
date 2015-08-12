using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.TestClasses
{
    class TestViewModel
    {
        TestResults test = null;

        //Id
        private int id = 0;
        public int Id
        {
            get
            { return id; }

            set
            {
                if (id == value)
                { return; }

                id = value;

            }
        }

        //Child Id
        private int childId = 0;
        public int ChildId
        {
            get
            { return childId; }

            set
            {
                if (childId == value)
                { return; }

                childId = value;

            }
        }

        //Number of right answers
        private int rightsAnswers = 0;
        public int RightAnswers
        {
            get
            { return rightsAnswers; }

            set
            {
                if (rightsAnswers == value)
                { return; }

                rightsAnswers = value;

            }
        }

        //Number of wrong answers
        private int wrongAnswers = 0;
        public int WrongAnswers
        {
            get
            { return wrongAnswers; }

            set
            {
                if (wrongAnswers == value)
                { return; }

                wrongAnswers = value;

            }
        }

        //Date and Time of test
        private string date = string.Empty;
        public string Date
        {
            get
            { return date; }

            set
            {
                if (date == value)
                { return; }

                date = value;

            }
        }

       


        private JuniorMathsApp1.App app = (Application.Current as App);


        //Retrive all Parent details from the database where email and password match user inputs
        public TestResults getChildResults(int childId)
        {
            test = new TestResults();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                test = db.Query<TestResults>("Select * from TestResults where ChildId =" + childId).FirstOrDefault();

            }
            return test;
        }

        

        //Method for saving child details into the database
        public int insertTestResults(int childID, int rightAnswers, int wrongAnswers, string date)
        {
            int success = 0;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {

                try
                {

                    success = db.Insert(new TestResults()
                    {
                        Id = 0,
                        ChildId = childID,
                        NoRightAnswers = rightAnswers,
                        NoWrongAnswers = wrongAnswers,
                        Date = date
                    });
                }
                catch (Exception)
                {

                }
            }
            return success;
        }

        //Delete all child test records from the Test Table
        public void deleteChildTestRecords(int childid)
        {

            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var result = db.Query<TestResults>("Delete from TestResults where Childid =" + childid);

            }
        }
    }
}
