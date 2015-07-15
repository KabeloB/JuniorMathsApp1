using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.ParentClasses
{
    class ParentViewModel
    {
        //Id

        Register reg = null;
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

        //Email
        private string email = string.Empty;
        public string Email
        {
            get
            { return email; }

            set
            {
                if (email == value)
                { return; }

                email = value;
                
            }
        }

        //PhoneNumber
        private string phoneNo = string.Empty;
        public string PhoneNo
        {
            get
            { return phoneNo; }

            set
            {
                if (phoneNo == value)
                { return; }

                phoneNo = value;
                
            }
        }

        //Password
        private string password = string.Empty;
        public string Password
        {
            get
            { return password; }

            set
            {
                if (password == value)
                { return; }

                password = value;
                
            }
        }

        private JuniorMathsApp1.App app = (Application.Current as App);


        //Retrive all Parent details from the database where email and password match user inputs
        public Register getParent(string email, string password)
        {
            reg = new Register();
            using(var db = new SQLite.SQLiteConnection(app.dbPath))
            {

                reg = db.Query<Register>("Select * from Parents where Email ='" +email+ "' and Password ='" +password+ "'").FirstOrDefault();

                /*
                  var _register = db.Query<Register>("Select * from Parents where Email ='" + email + "' and Password ='" + password + "'").FirstOrDefault;
                  return reg;
                */

            }
            return reg;
        }



        //Method for saving parent details into the database
        public void SaveCustomer(string name, string surname, string email, string phoneNo, string password)
        {
            
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
               
                try
                {
                    //var existingParent = (db.Table<Register>().Where(
                    // c => c.Id == register.Id)).SingleOrDefault();

                    int success = db.Insert(new Register()
                    {
                        Id = 0,
                        Name = name,
                        Surname = surname,
                        Email = email,
                        PhoneNo = phoneNo,
                        Password = password
                    });

                }
                catch (Exception)
                {
                   
                }
            }
        }





        //End of Methods

    }
}
