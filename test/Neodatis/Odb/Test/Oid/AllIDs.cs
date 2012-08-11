using NDatabase.Odb;
using NDatabase.Odb.Core.Layers.Layer3;
using NUnit.Framework;

namespace Test.Odb.Test.Oid
{
    public class AllIDs : ODBTest
    {
        public static string FileName = "ids.neodatis";

        [Test]
        public virtual void Test1()
        {
            DeleteBase(FileName);

            IBaseIdentification parameter = new IOFileParameter(FileName, true);

            var engine = OdbConfiguration.GetCoreProvider().GetStorageEngine(parameter);
            var function1 = new VO.Login.Function("login");
            engine.Store(function1);

            var function2 = new VO.Login.Function("login2");
            engine.Store(function2);

            engine.Commit();
            engine.Close();

            engine = OdbConfiguration.GetCoreProvider().GetStorageEngine(parameter);
            var l = engine.GetAllObjectIds();
            AssertEquals(2, l.Count);
            engine.Close();
            DeleteBase(FileName);
        }
    }
}
