using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.TestClasses
{
    class TestsViewModel
    {
        private ObservableCollection<TestViewModel> parents;
        public ObservableCollection<TestViewModel> Parents
        {
            get
            {
                return parents;
            }

            set
            {
                parents = value;
            }
        }
        private JuniorMathsApp1.App app = (Application.Current as App);

        //Retrive all test for children in your account
        public ObservableCollection<TestViewModel> GetTest()
        {
            parents = new ObservableCollection<TestViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<TestResults>("select * from TestResults");
                foreach (var _register in query)
                {
                    var register = new TestViewModel()
                    {
                        Id = _register.Id,
                        ChildId = _register.ChildId,
                        RightAnswers = _register.NoRightAnswers,
                        WrongAnswers = _register.NoWrongAnswers,
                        Date = _register.Date

                    };
                    parents.Add(register);
                }
            }
            return parents;
        }

        //Retrive all test for a particular child IdS
        public ObservableCollection<TestViewModel> GetTests(int childId)
        {
            parents = new ObservableCollection<TestViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                
                var query = db.Query<TestResults>("select * from TestResults where ChildId=" + childId);
                foreach (var _register in query)
                {
                    var register = new TestViewModel()
                    {
                        Id = _register.Id,
                        ChildId = _register.ChildId,
                        RightAnswers = _register.NoRightAnswers,
                        WrongAnswers = _register.NoWrongAnswers,
                        Date = _register.Date

                    };
                    parents.Add(register);
                }
            }
            return parents;
        }
    }
}
