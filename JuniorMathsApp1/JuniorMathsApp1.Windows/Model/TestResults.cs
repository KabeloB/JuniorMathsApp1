using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JuniorMathsApp1.Model
{
     [Table("TestResults")]
    class TestResults
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ChildId { get; set; }

        public int NoRightAnswers { get; set; }

        public int NoWrongAnswers { get; set; }

        public string Date { get; set; }
    }
}
