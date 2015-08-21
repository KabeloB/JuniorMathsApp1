﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace JuniorMathsApp1.Model
{
    [Table("Parents")]
    class Register
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Password { get; set; }



    }
}
