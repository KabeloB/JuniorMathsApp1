using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.ParentClasses
{
    public class ParentViewModel : ViewModelBase
    {
        #region Properties

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
                RaisePropertyChanged("Id");
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
                RaisePropertyChanged("Name");
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
                RaisePropertyChanged("Surname");
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
                RaisePropertyChanged("Email");
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
                RaisePropertyChanged("PhoneNo");
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
                RaisePropertyChanged("Password");
            }
        }

        #endregion "Properties"

        private JuniorMathsApp1.App app = (Application.Current as App);

        public Register GetCustomer(string email, string password)
        {
            //var register = new ParentViewModel();
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                //var _register
                var _register = db.Query<Register>("select * from Parents where Email='" +email+ "' and Password='" +password+ "'");
                return _register;
            }

        }


        /*
        public ParentViewModel GetCustomer(int customerId)
        {
            var register = new ParentViewModel();
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var _register = (db.Table<Register>().Where(
                    c => c.Id == customerId)).Single();
                register.Id = _register.Id;
                register.Name = _register.Name;
                register.Surname = _register.Surname;
                register.Email = _register.Email;
                register.PhoneNo = _register.PhoneNo;
                register.Password = _register.Password;
            }
            return register;
        }

         */
        public string GetParentName(int parentId)
        {
            string parentName = "Unknown";
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var register = (db.Table<Register>().Where(
                    c => c.Id == parentId)).Single();
                parentName = register.Name;
            }
            return parentName;
        }

        public string SaveCustomer(ParentViewModel register)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                string change = string.Empty;
                try
                {
                    var existingParent = (db.Table<Register>().Where(
                        c => c.Id == register.Id)).SingleOrDefault();

                    if (existingParent != null)
                    {
                        existingParent.Name = register.Name;
                        existingParent.Surname = register.Surname;
                        existingParent.Email = register.Email;
                        existingParent.PhoneNo = register.PhoneNo;
                        existingParent.Password = register.Password;
                        int success = db.Update(existingParent);
                    }
                    else
                    {
                        int success = db.Insert(new Register()
                        {
                            Id = register.id,
                            Name = register.Name,
                            Surname = register.Surname,
                            Email = register.Email,
                            PhoneNo = register.PhoneNo,
                            Password = register.Password
                        });
                    }
                    result = "Success";
                }
                catch (Exception ex)
                {
                    result = "This customer was not saved.";
                }
            }
            return result;
        }

        public string DeleteChild(int parentId)
        {
            string result = string.Empty;
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var children = db.Table<AddChild>().Where(
                    p => p.ParentId == parentId);
                foreach (AddChild project in children)
                {
                    db.Delete(project);
                }
                var existingChild = (db.Table<AddChild>().Where(
                    c => c.Id == parentId)).Single();

                if (db.Delete(existingChild) > 0)
                {
                    result = "Success";
                }
                else
                {
                    result = "This customer was not removed";
                }
            }
            return result;
        }

        public int GetNewCustomerId()
        {
            int customerId = 0;
            using (var db = new SQLite.SQLiteConnection(app.DBPath))
            {
                var customers = db.Table<Register>();
                if (customers.Count() > 0)
                {
                    customerId = (from c in db.Table<Register>()
                                  select c.Id).Max();
                    customerId += 1;
                }
                else
                {
                    customerId = 1;
                }
            }
            return customerId;
        }
    }
}
