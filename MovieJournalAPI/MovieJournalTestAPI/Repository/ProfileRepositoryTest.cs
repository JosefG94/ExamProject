using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieJournalDAL;
using MovieJournalDAL.Model;
using NUnit.Framework;

namespace MovieJournalTestAPI.Repository
{
    [TestFixture]
    public class ProfileRepositoryTest
    {
        //Facade facade;

        //[SetUp]
        //public void SetUp()
        //{
        //    facade = new Facade();
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    facade = null;
        //}

        //[Test]
        //public void Test_Get_Profile()
        //{

        //    var pro = facade.GetProfileRepository().Get(1);

        //    Assert.AreEqual(pro.Id, 4);
        //    Assert.AreEqual(pro.Name, "Obiwan Kenobi");
        //}

        //[Test]
        //public void Profile_is_updated__from_db_after_update()
        //{
        //    IEnumerable<Profile> profile = facade.GetProfileRepository().ReadAll();
        //    Assert.IsTrue(profile.Count() > 0, "We need atleast one movie to do the test");
        //    Profile profileToUpdate = profile[0];
        //    Profile profileUpdated = facade.GetProfileRepository().Edit(Profile);
        //    Assert.AreSame(profileToUpdate, profileToUpdate);
        //    Assert.IsNull(profileUpdated);
        //}
    }
}
