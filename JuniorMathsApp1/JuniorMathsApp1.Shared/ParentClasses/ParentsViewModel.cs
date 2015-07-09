using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.ParentClasses
{
    class ParentsViewModel
    {
        private ObservableCollection<ParentViewModel> parents;
        public ObservableCollection<ParentViewModel> Parents
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

        public ObservableCollection<ParentViewModel> GetParents()
        {
            parents = new ObservableCollection<ParentViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Table<Register>().OrderBy(c => c.Name);
                foreach (var _register in query)
                {
                    var register = new ParentViewModel()
                    {
                        Id = _register.Id,
                        Name = _register.Name,
                        Surname = _register.Surname,
                        Email = _register.Email,
                        PhoneNo = _register.PhoneNo,
                        Password = _register.Password
                         
                    };
                    parents.Add(register);
                }
            }
            return parents;
        }
    }
}
