using MovieJournalDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MovieJournalTest
{
    [TestFixture]
    public class ProfileTest
    {
        Facade facade = new Facade();


        [Test]
        public void Test_Get_Profile()
        {

            var pro = facade.GetProfileRepository().Get(1);

            Assert.AreEqual(pro.Id, "1");
            Assert.AreEqual(pro.Name, "Abdirahman");
            Assert.AreEqual(pro.MovieOnList, "102");

        }
    }
}
