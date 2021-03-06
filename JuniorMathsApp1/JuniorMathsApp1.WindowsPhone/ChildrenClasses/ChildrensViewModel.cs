﻿using JuniorMathsApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml;

namespace JuniorMathsApp1.ChildrenClasses
{
    class ChildrensViewModel
    {
        private ObservableCollection<ChildrenViewModel> parents;
        public ObservableCollection<ChildrenViewModel> Parents
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

        public ObservableCollection<ChildrenViewModel> GetChildren()
        {
            parents = new ObservableCollection<ChildrenViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                var query = db.Query<RegisterChild>("select * from Child");
                foreach (var _register in query)
                {
                    var register = new ChildrenViewModel()
                    {
                        Id = _register.Id,
                        ParentId = _register.ParentId,
                        Name = _register.Name,
                        Surname = _register.Surname,
                        Age = _register.Age,
                        Grade = _register.Grade,

                    };
                    parents.Add(register);
                }
            }
            return parents;
        }


        public ObservableCollection<ChildrenViewModel> GetChildren(int parentId)
        {
            parents = new ObservableCollection<ChildrenViewModel>();
            using (var db = new SQLite.SQLiteConnection(app.dbPath))
            {
                string pId = "" + parentId;
                var query = db.Query<RegisterChild>("select * from Child where parentId='" +pId+ "'" );
                foreach (var _register in query)
                {
                    var register = new ChildrenViewModel()
                    {
                        Id = _register.Id,
                        ParentId = _register.ParentId,
                        Name = _register.Name,
                        Surname = _register.Surname,
                        Age = _register.Age,
                        Grade = _register.Grade,

                    };
                    parents.Add(register);
                }
            }
            return parents;
        }
    }
}
