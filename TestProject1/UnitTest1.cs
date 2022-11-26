using multi;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void CharSequenceConstructorTest()
        {
            char[] chars = new char[] { 'a', 'a', 'a', 'a', 'c', 'c', 'c', 'd', 'b' };
            MultiSet<char> multiset = new MultiSet<char>(chars);
            Assert.AreEqual(9, multiset.Count);
        }


        [TestMethod]
        public void AddTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            Assert.AreEqual(9, multiset.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            multiset.Remove('a');
            Assert.AreEqual(8, multiset.Count);
        }

        //create tests for MultiSet
        [TestMethod]

        public void ContainsTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            Assert.AreEqual(true, multiset.Contains('a'));
        }

        //create tests for MultiSet
        [TestMethod]
        public void ClearTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            multiset.Clear();
            Assert.AreEqual(0, multiset.Count);
        }

        //create tests for MultiSet
        [TestMethod]

        public void CountTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            Assert.AreEqual(9, multiset.Count);
        }

        //create tests for MultiSet
        [TestMethod]
        public void IsReadOnlyTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            Assert.AreEqual(false, multiset.IsReadOnly);
        }

        //create tests for MultiSet

        [TestMethod]
        public void CopyToTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            char[] array = new char[9];
            multiset.CopyTo(array, 0);
            Assert.AreEqual('a', array[0]);
        }

        //create tests for MultiSet

        [TestMethod]
        public void GetEnumeratorTest()
        {
            MultiSet<char> multiset = new MultiSet<char>();
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('a');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('c');
            multiset.Add('d');
            multiset.Add('b');
            IEnumerator<char> enumerator = multiset.GetEnumerator();
            Assert.AreEqual(true, enumerator.MoveNext());
        }

        [TestMethod]
        public void IsSubsetTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(true, multiset1.IsSubsetOf(multiset2));
        }


        [TestMethod]
        public void IsSupersetTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(true, multiset1.IsSupersetOf(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]
        public void IsProperSubsetTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(false, multiset1.IsProperSubsetOf(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]
        public void IsProperSupersetTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(false, multiset1.IsProperSupersetOf(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]
        public void OverlapsTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(true, multiset1.Overlaps(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]
        public void SetEqualsTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(true, multiset1.MultiSetEquals(multiset2));
        }

        [TestMethod]

        public void IntersectWithTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            multiset1.IntersectWith(multiset2);
            Assert.AreEqual(9, multiset1.Count);
        }


        [TestMethod]

        public void ExceptWithTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            multiset1.ExceptWith(multiset2);
            Assert.AreEqual(0, multiset1.Count);
        }

        [TestMethod]

        public void IsProperSubsetOfTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(false, multiset1.IsProperSubsetOf(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]

        public void IsProperSupersetOfTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(false, multiset1.IsProperSupersetOf(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]

        public void IsSubsetOfTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(true, multiset1.IsSubsetOf(multiset2));
        }

        //create tests for MultiSet

        [TestMethod]

        public void IsSupersetOfTest()
        {
            MultiSet<char> multiset1 = new MultiSet<char>();
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('a');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('c');
            multiset1.Add('d');
            multiset1.Add('b');
            MultiSet<char> multiset2 = new MultiSet<char>();
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('a');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('c');
            multiset2.Add('d');
            multiset2.Add('b');
            Assert.AreEqual(true, multiset1.IsSupersetOf(multiset2));
        }

      

  
        
        

    }
}