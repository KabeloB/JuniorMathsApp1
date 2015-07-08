using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JuniorMathsApp1.Model
{
    [Table("Children")]
    class AddChild
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Age { get; set; }

        public string Grade { get; set; }
    }
}
