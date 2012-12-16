using System;
using NDatabase2.Odb.Core.Query.Criteria;
using NUnit.Framework;
using Test.NDatabase.Odb.Test.VO.Login;

namespace Test.NDatabase.Odb.Test.Defragment
{
    [TestFixture]
    public class TestDefragment : ODBTest
    {
        /// <summary>
        ///   The name of the database file
        /// </summary>
        public static readonly string OdbFileName1 = "defrag3.neodatis";

        public static readonly string OdbFileName2 = "defrag3-bis.neodatis";

        [Test]
        public virtual void Test1()
        {
            DeleteBase(OdbFileName1);
            DeleteBase(OdbFileName2);
            var odb = Open(OdbFileName1);
            var user = new User("olivier", "olivier@neodatis.com", null);
            odb.Store(user);
            odb.Close();

            odb = Open(OdbFileName1);
            odb.DefragmentTo(OdbFileName2);
            var newOdb = Open(OdbFileName2);

            Decimal nbUser = odb.CreateCriteriaQuery<User>().Count();
            Decimal nbNewUser = odb.CreateCriteriaQuery<User>().Count();
            AssertEquals(nbUser, nbNewUser);
            AssertEquals(odb.CreateCriteriaQuery<Profile>().Count(),
                         odb.CreateCriteriaQuery<Profile>().Count());
            odb.Close();
            newOdb.Close();
            DeleteBase(OdbFileName1);
            DeleteBase(OdbFileName2);
        }

        [Test]
        public virtual void Test2()
        {
            DeleteBase(OdbFileName1);
            DeleteBase(OdbFileName2);
            var odb = Open(OdbFileName1);
            var p = new Profile("profile");
            for (var i = 0; i < 500; i++)
            {
                var user = new User("olivier " + i, "olivier@neodatis.com " + i, p);
                odb.Store(user);
            }
            odb.Close();
            odb = Open(OdbFileName1);
            odb.DefragmentTo(OdbFileName2);
            var newOdb = Open(OdbFileName2);
            AssertEquals(odb.CreateCriteriaQuery<User>().Count(), odb.CreateCriteriaQuery<User>().Count());
            AssertEquals(odb.CreateCriteriaQuery<Profile>().Count(),
                         odb.CreateCriteriaQuery<Profile>().Count());
            odb.Close();
            newOdb.Close();
            DeleteBase(OdbFileName1);
            DeleteBase(OdbFileName2);
        }

        [Test]
        public virtual void Test3()
        {
            DeleteBase(OdbFileName1);
            DeleteBase(OdbFileName2);
            
            var odb = Open(OdbFileName1);
            for (var i = 0; i < 1500; i++)
            {
                var user = new User("olivier " + i, "olivier@neodatis.com " + i, new Profile("profile" + i));
                odb.Store(user);
            }
            odb.Close();
            odb = Open(OdbFileName1);
            odb.DefragmentTo(OdbFileName2);
            var newOdb = Open(OdbFileName2);
            AssertEquals(odb.CreateCriteriaQuery<User>().Count(), odb.CreateCriteriaQuery<User>().Count());
            odb.Close();
            newOdb.Close();
            DeleteBase(OdbFileName1);
            DeleteBase(OdbFileName2);
        }
    }
}
