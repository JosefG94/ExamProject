using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieJournalDAL.Context
{
    public class MovieDBInitialize : DropCreateDatabaseAlways<MovieContext>
    {
    }
}
