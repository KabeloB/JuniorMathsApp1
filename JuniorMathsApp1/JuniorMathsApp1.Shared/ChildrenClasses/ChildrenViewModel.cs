using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.ChildrenClasses
{
    class ChildrenViewModel
    {

        RegisterChild reg = null;

        //Child Id
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

        

        //Parent Id
        private string parentid = string.Empty;
        public string ParentId
        {
            get
            { return parentid; }

            set
            {
                if (parentid == value)
                { return; }

                parentid = value;

            }
        }


        //Name
        private string name = string.Empty;
        public string Name
        {
            get
            { return name; }

            set
            {
                if (name == value)
                { return; }

                name = value;

            }
        }

        //Surname
        private string surname = string.Empty;
        public string Surname
        {
            get
            { return surname; }

            set
            {
                if (surname == value)
                { return; }

                surname = value;

            }
        }

        //Age
        private string age = string.Empty;
        public string Age
        {
            get
            { return age; }

            set
            {
                if (age == value)
                { return; }

                age = value;

            }
        }

        //Grade
        private string grade = string.Empty;
        public string Grade
        {
            get
            { return grade; }

            set
            {
                if (grade == value)
                { return; }

                grade = value;

            }
        }

        

        private JuniorMathsApp1.App app = (Application.Current as App);


        //Retrive all Parent details from the database where email and password match user inputs
        public RegisterChild getChildDetails(int id, int parentId, string childName)
        {
           reg = new RegisterChild();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                reg = db.Query<RegisterChild>("Select * from Child where Id =" + id + " and ParentId = '"+ parentId+"  and Name ='" + name + "'").FirstOrDefault();
               
            }
             return reg;
        }

        public string getMessage()
        {
            string msg = "There's communication!";
            return msg;
        }

        //Method for saving child details into the database
        public int registerNewChild(string parentId, string name, string surname, string age, string grade)
        {
            int success = 0;
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {

                try
                {
                    
                    success = db.Insert(new RegisterChild()
                    {
                        Id = 0,
                        ParentId = parentId,
                        Name = name,
                        Surname = surname,
                        Age = age,
                        Grade = grade
                    });
                }
                catch (Exception)
                {

                }
            }
            return success;
        }




    }
}
