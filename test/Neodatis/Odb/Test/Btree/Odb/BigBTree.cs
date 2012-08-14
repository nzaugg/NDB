using System;
using System.Collections;
using IO;
using NDatabase.Btree;
using NDatabase.Btree.Impl.Multiplevalue;
using NDatabase.Odb;
using NDatabase.Odb.Core;
using NDatabase.Odb.Impl.Core.Btree;
using NUnit.Framework;
using NeoDatis.Test.Btree.Impl.Singlevalue;
using Test.Odb.Test;

namespace Btree.Odb
{
    public class BigBTree : ODBTest
    {
        [Test]
        public virtual void Test1()
        {
            const string bigbtreeTest1DbName = "bigbtree.test1.db";
            DeleteBase(bigbtreeTest1DbName);

            using (var odb = OdbFactory.Open(bigbtreeTest1DbName))
            {
                var size = 10000;
                IBTree tree = new OdbBtreeSingle("test1", 50, new LazyOdbBtreePersister(odb));
                for (var i = 0; i < size; i++)
                {
                    if (i % 1000 == 0)
                        Println(i);
                    tree.Insert(i + 1, "value " + (i + 1));
                }
                AssertEquals(size, tree.GetSize());
                IEnumerator iterator = new BTreeIteratorSingleValuePerKey<object>(tree, OrderByConstants.OrderByAsc);
                var j = 0;
                while (iterator.MoveNext())
                {
                    var o = iterator.Current;
                    // println(o);
                    j++;
                    if (j == size)
                        AssertEquals("value " + size, o);
                }
            }
        }

        [Test]
        public virtual void Test2()
        {
            var size = 10000;
            IBTree tree = new InMemoryBTreeMultipleValuesPerKey("test1", 50);
            for (var i = 0; i < size; i++)
            {
                if (i % 1000 == 0)
                    Println(i);
                tree.Insert(i + 1, "value " + (i + 1));
            }
            AssertEquals(size, tree.GetSize());
            IEnumerator iterator = new BTreeIteratorMultipleValuesPerKey<object>(tree, OrderByConstants.OrderByAsc);
            
            var j = 0;
            while (iterator.MoveNext())
            {
                var o = iterator.Current;
                Console.WriteLine(o);
                j++;
                if (j == size)
                    AssertEquals("value " + size, o);
            }
        }
    }
}
