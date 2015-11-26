﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieJournalDAL.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool isAdmin { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }


    }
}
