using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace lab3unit
{
    [TestFixture]
    class UTest
    {
        [Test]
        public void Test1()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsTrue(triangle.TriangleCheck(2, 2, 2));
        }

        [Test]
        public void Test2()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsTrue(triangle.TriangleCheck(3, 4, 5));
        }

        [Test]
        public void Test3()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(0, 0, 0));
        }

        [Test]
        public void Test4()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(4, 5, 0));
        }

        [Test]
        public void Test5()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(4, 0, 5));
        }

        [Test]
        public void Test6()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(0, 4, 5));
        }

        [Test]
        public void Test7()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(-3, 4, 5));
        }

        [Test]
        public void Test8()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(-3, -3, -3));
        }

        [Test]
        public void Test9()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(new Double(), 4, 5));
        }

        [Test]
        public void Test10()
        {
            TriangleHelper triangle = new TriangleHelper();
            Assert.IsFalse(triangle.TriangleCheck(new Double(), new Double(), new Double()));
        }
    }
}
